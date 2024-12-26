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
builder.Services.AddScoped<IRoleSevice,RoleService>();
builder.Services.AddScoped<IAuthService,AuthService>();

//options pattern kullanarak jwt config bilgilerini appsettings.json dosyasýndan okuyoruz
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig")); //jsondaki her bir {} li þeyler varya onu seç diyoruz ve appsetting artýk okunabilir

JwtConfig? jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>(); //artýk içindekileri okuyabilir sonuna get diyerek öncekileri için yukarda getir demem lazým

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8; //minimum þu kadar karakter olmalýdýr diyorum

    options.User.RequireUniqueEmail = true; // ayný email ile kayýt olmasýn
    options.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvwxyz0123456789-_.@";

}).AddEntityFrameworkStores<ECommerceDbContext>().AddDefaultTokenProviders(); //BU ÝLEMLER ÝLK HANGÝ db yi kullanýcka onu söylüyoruz sonra ona bir default token göndericem yani örnek e posta için onay lazým o onay linkine tokeni gömmek için kullanýcan bu sondaki adddefaulttokenprovider ý

//JWT Ayarlarý (authentication ayarlarý)
builder.Services.AddAuthentication(options =>
{
    // hangi standartlara göre kullanýlacak   yani jwt þablonunu söylicez
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; //jwt nin auth. þemasýný varsayýlan olarak kullan   yapýmýz
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // jwt 
}).AddJwtBearer(o => {
    o.TokenValidationParameters = new TokenValidationParameters {

        ValidateIssuer = true, //Issuer kontrol et
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true, //secret key ile imzalanmýþ olsun mu
        ValidIssuer = jwtConfig?.Issuer, //kontrol edeceðin Issuer bu
        ValidAudience = jwtConfig?.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig?.Secret ?? "")) // eðer nullsa saðdakini kullan diyor  secreti þifrelemiþ oluyoruz

    };  //tokenin doðrulanmasýný saðlicak yani buraya gelen bilgiyi yani tokeni kontrol edip doðrulama iþlemi
});



var app = builder.Build();

using (var scope = app.Services.CreateScope()) {
// yarattýðýmýz roleService yi alacaðý   ve içindeki role eklememetodunu çaðýracaðýz

    var roleService = scope.ServiceProvider.GetRequiredService<IRoleSevice>();
    await roleService.SeedRolesAsync();

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
