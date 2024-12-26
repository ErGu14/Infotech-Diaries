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

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>(); //sen bana 2. olaný yarat ama sana ben bunu 1. yi söylerek burdaki yapýyý getirceksin
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IRoleService,RoleService>();
builder.Services.AddScoped<IAuthService,AuthService>();

builder.Services.Configure<JWTConfig>(builder.Configuration.GetSection("JwtConfig"));
JWTConfig? jWTConfig = builder.Configuration.GetSection("JwtConfig").Get<JWTConfig>(); // gelen .json u class a çevirerek aþaðýda yazcaðým düzenlemelerde kullanabileceðim yani appsettings bir soyutsa jwt config benim somut halim ve somutu kodkarýmda kullanmam daha uygun  gibi bir örnek verilebilir IproductService ile product service gibi

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(x =>
{

    //user bilgileri
    x.User.RequireUniqueEmail = true; // sistemde ayný adrese ait bir eposta bilgisi olmasýn 
    x.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuwvyzABCDEFGIJKLMNOPRSTUWVYZ1234567890*.@_-";

    //þifre Ayarlarý
    x.Password.RequireNonAlphanumeric = true; // özel karakter içersin mi
    x.Password.RequireDigit = true; //þifrede 0-9 sayýlarýný alabilir mi
    x.Password.RequiredLength = 8; // en az 8 karakterli olmalý
    x.Password.RequireUppercase = true;
    x.Password.RequireLowercase = true; // küçük ve büyük harflere izin vermek (bu satýrdaki küçük, büyüklere izin verme 1 satýr üstte)

    //çoklu ayar yapacaðýmdan yani çoklu atama yaparken süslü parantez {} içerisine almalýyým sanki new diyomuþumcasýna
}).AddEntityFrameworkStores<ECommerceDbContext>().AddDefaultTokenProviders(); //hangi ef sunucu bilgilerini içericeðini belirtiyoruz ve diðer provider ile oluþan bu bilgileri tokenlere gömmemizi saðlýyor buda bir güvenlik  kontrolü 


// ilk þemalarýmýzý yüklüyoruz yani authentication ekliyoruz ve þemalardan sonra angi auth kütüphanesini kullancaksak add diyerek ekliyoruz . Lambda fonk. ile ise {} içerisinde gerekli iþlemleri yapýyoruz iþte secret life time vs vs gibibilgileri kontrol et ve gerekli bilgileri nereden alcaðýný söylüyoruz fakat secreti sadee þifreliyoruz  Issuerkey = secret demek bir nevi yani oluþturucu anahtarý
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
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jWTConfig?.Secret ?? "")) //secret key ile doðrulama açýk iken secret keyi kontrol et ve bu secret keyi þifrelicem 


    };
}); // burada þemalar yüklenicek sonra sunucu token olduðunu anlicak ve token bilgilerini kontrol et dicem 


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
