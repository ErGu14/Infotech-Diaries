using ECommerce.Businnes.Abstract;
using ECommerce.Businnes.Concrete;
using ECommerce.Businnes.Configuration;
using ECommerce.Businnes.Mapping;
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

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ECommerceDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>(); //sen bana 2. olan� yarat ama sana ben bunu 1. yi s�ylerek burdaki yap�y� getirceksin
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IRoleService,RoleService>();
builder.Services.AddScoped<IAuthService,AuthService>();

builder.Services.Configure<JWTConfig>(builder.Configuration.GetSection("JwtConfig"));
JWTConfig? jWTConfig = builder.Configuration.GetSection("JwtConfig").Get<JWTConfig>(); // gelen .json u class a �evirerek a�a��da yazca��m d�zenlemelerde kullanabilece�im yani appsettings bir soyutsa jwt config benim somut halim ve somutu kodkar�mda kullanmam daha uygun  gibi bir �rnek verilebilir IproductService ile product service gibi

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(x =>
{

    //user bilgileri
    x.User.RequireUniqueEmail = true; // sistemde ayn� adrese ait bir eposta bilgisi olmas�n 
    x.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuwvyzABCDEFGIJKLMNOPRSTUWVYZ1234567890*.@_-";

    //�ifre Ayarlar�
    x.Password.RequireNonAlphanumeric = true; // �zel karakter i�ersin mi
    x.Password.RequireDigit = true; //�ifrede 0-9 say�lar�n� alabilir mi
    x.Password.RequiredLength = 8; // en az 8 karakterli olmal�
    x.Password.RequireUppercase = true;
    x.Password.RequireLowercase = true; // k���k ve b�y�k harflere izin vermek (bu sat�rdaki k���k, b�y�klere izin verme 1 sat�r �stte)

    //�oklu ayar yapaca��mdan yani �oklu atama yaparken s�sl� parantez {} i�erisine almal�y�m sanki new diyomu�umcas�na
}).AddEntityFrameworkStores<ECommerceDbContext>().AddDefaultTokenProviders(); //hangi ef sunucu bilgilerini i�erice�ini belirtiyoruz ve di�er provider ile olu�an bu bilgileri tokenlere g�mmemizi sa�l�yor buda bir g�venlik  kontrol� 


// ilk �emalar�m�z� y�kl�yoruz yani authentication ekliyoruz ve �emalardan sonra angi auth k�t�phanesini kullancaksak add diyerek ekliyoruz . Lambda fonk. ile ise {} i�erisinde gerekli i�lemleri yap�yoruz i�te secret life time vs vs gibibilgileri kontrol et ve gerekli bilgileri nereden alca��n� s�yl�yoruz fakat secreti sadee �ifreliyoruz  Issuerkey = secret demek bir nevi yani olu�turucu anahtar�
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {

        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = jWTConfig?.Issuer,
        ValidAudience = jWTConfig?.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jWTConfig?.Secret ?? "")) //secret key ile do�rulama a��k iken secret keyi kontrol et ve bu secret keyi �ifrelicem 


    };
}); // burada �emalar y�klenicek sonra sunucu token oldu�unu anlicak ve token bilgilerini kontrol et dicem 


var app = builder.Build();
// roleri otomatik seedle
using (var scope = app.Services.CreateScope())
{
    var seed = scope.ServiceProvider.GetRequiredService<IRoleService>();
    await seed.SeedRolesAsync();
}

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
