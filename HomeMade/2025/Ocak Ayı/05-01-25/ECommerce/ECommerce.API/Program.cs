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

// tokenlarýmýzýn içindeki kullanýcý bilgilerini burda ayarladýk
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequireDigit = true; //þifrede sayýlarýn geçerli olduðunu söyledik
    options.Password.RequireUppercase = true; // 1 büyük harf isteði
    options.Password.RequireLowercase = true; //1 küçük harf isteði
    options.Password.RequireNonAlphanumeric = true; // özel karakterlerin olmasýný istemiþiz
    options.Password.RequiredLength = 8; // þifreniz minimum içermesi gereken karakter sayýsý

    options.User.RequireUniqueEmail = true; // Id sini email olarak kabul etmiþiz
    options.User.AllowedUserNameCharacters = "abcdefghijklmnoqprstuvxyz0123456789-_.@"; // kullanýcýnýn adýnda izin verilen karakterleri tanýmlar

}).AddEntityFrameworkStores<ECommerceDbContext>().AddDefaultTokenProviders(); // ilk önce hangi databasedimizi kullancaðýmýzý söylüyoruz sonrasýnda iste .josandaki verilerimizi okutuyoruz (þifre sýfýrlama gibi iþlemler için gerekli)  ayný zamanda farklý bir token iþlemi varsa onuda buraya yazabiliriz


// .json bilgilerini getirme
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

//.json bilgilerini elle tutulur bir þekilde almak 
var jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>();

//JWT(Authentication) Ayarlarý
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme= JwtBearerDefaults.AuthenticationScheme; // hangi token türünü kullnacaðýný belirtir
    options.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme; // kimlik doðrulama baþarýsýz olduðunda hangi þemalarý kullancaðýmýzý demiþiz
    
}).AddJwtBearer(options =>
{
    
    options.TokenValidationParameters = new TokenValidationParameters // verdiðimiz tokenin kontrolünü saðlamak için 
    {
        //app.jsonda yazýlanlarý kontrol ediyor
        ValidateIssuer=true, // yaratýcý kontrol
        ValidateAudience=true, // kullanýcý kontrol
        ValidateLifetime=true, // süre kontrol
        ValidateIssuerSigningKey=true, //secret kontrolü
        ValidIssuer= jwtConfig?.Issuer, // geçerli oluþturucu kontrolü
        ValidAudience= jwtConfig?.Audience, // kimlerin kullanacaðý bilgisi
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig?.Secret ?? "")) // secret þifreleme
    };
});
//buraya kadar eklediðimiz herþeyin adý optionPattern iþlemidir

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