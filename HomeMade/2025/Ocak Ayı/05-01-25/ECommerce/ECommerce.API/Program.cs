using ECommerce.Business.Abstract;
using ECommerce.Business.Concrete;
using ECommerce.Business.Configuration;
using ECommerce.Business.Mapping;
using ECommerce.Data.Abstract;
using ECommerce.Data.Concrete;
using ECommerce.Data.Concrete.Contexts;
using ECommerce.Data.Concrete.Repositories;
using ECommerce.Entity.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ECommerceDbContext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IOrderService, OrderService>();  

builder.Services.AddAutoMapper(typeof(MappingProfile));

// tokenlar�m�z�n i�indeki kullan�c� bilgilerini burda ayarlad�k
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequireDigit = true; //�ifrede say�lar�n ge�erli oldu�unu s�yledik
    options.Password.RequireUppercase = true; // 1 b�y�k harf iste�i
    options.Password.RequireLowercase = true; //1 k���k harf iste�i
    options.Password.RequireNonAlphanumeric = true; // �zel karakterlerin olmas�n� istemi�iz
    options.Password.RequiredLength = 8; // �ifreniz minimum i�ermesi gereken karakter say�s�

    options.User.RequireUniqueEmail = true; // Id sini email olarak kabul etmi�iz
    options.User.AllowedUserNameCharacters = "abcdefghijklmnoqprstuvxyz0123456789-_.@"; // kullan�c�n�n ad�nda izin verilen karakterleri tan�mlar

}).AddEntityFrameworkStores<ECommerceDbContext>().AddDefaultTokenProviders(); // ilk �nce hangi databasedimizi kullanca��m�z� s�yl�yoruz sonras�nda iste .josandaki verilerimizi okutuyoruz (�ifre s�f�rlama gibi i�lemler i�in gerekli)  ayn� zamanda farkl� bir token i�lemi varsa onuda buraya yazabiliriz


// .json bilgilerini getirme
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

//.json bilgilerini elle tutulur bir �ekilde almak 
var jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>();

//JWT(Authentication) Ayarlar�
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme= JwtBearerDefaults.AuthenticationScheme; // hangi token t�r�n� kullnaca��n� belirtir
    options.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme; // kimlik do�rulama ba�ar�s�z oldu�unda hangi �emalar� kullanca��m�z� demi�iz
    
}).AddJwtBearer(options =>
{
    
    options.TokenValidationParameters = new TokenValidationParameters // verdi�imiz tokenin kontrol�n� sa�lamak i�in 
    {
        //app.jsonda yaz�lanlar� kontrol ediyor
        ValidateIssuer=true, // yarat�c� kontrol
        ValidateAudience=true, // kullan�c� kontrol
        ValidateLifetime=true, // s�re kontrol
        ValidateIssuerSigningKey=true, //secret kontrol�
        ValidIssuer= jwtConfig?.Issuer, // ge�erli olu�turucu kontrol�
        ValidAudience= jwtConfig?.Audience, // kimlerin kullanaca�� bilgisi
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig?.Secret ?? "")) // secret �ifreleme
    };
});
//buraya kadar ekledi�imiz her�eyin ad� optionPattern i�lemidir

builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();