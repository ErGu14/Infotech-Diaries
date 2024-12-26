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
builder.Services.AddScoped<IRoleSevice,RoleService>();
builder.Services.AddScoped<IAuthService,AuthService>();

//options pattern kullanarak jwt config bilgilerini appsettings.json dosyas�ndan okuyoruz
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig")); //jsondaki her bir {} li �eyler varya onu se� diyoruz ve appsetting art�k okunabilir

JwtConfig? jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>(); //art�k i�indekileri okuyabilir sonuna get diyerek �ncekileri i�in yukarda getir demem laz�m

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8; //minimum �u kadar karakter olmal�d�r diyorum

    options.User.RequireUniqueEmail = true; // ayn� email ile kay�t olmas�n
    options.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvwxyz0123456789-_.@";

}).AddEntityFrameworkStores<ECommerceDbContext>().AddDefaultTokenProviders(); //BU �LEMLER �LK HANG� db yi kullan�cka onu s�yl�yoruz sonra ona bir default token g�ndericem yani �rnek e posta i�in onay laz�m o onay linkine tokeni g�mmek i�in kullan�can bu sondaki adddefaulttokenprovider �

//JWT Ayarlar� (authentication ayarlar�)
builder.Services.AddAuthentication(options =>
{
    // hangi standartlara g�re kullan�lacak   yani jwt �ablonunu s�ylicez
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; //jwt nin auth. �emas�n� varsay�lan olarak kullan   yap�m�z
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // jwt 
}).AddJwtBearer(o => {
    o.TokenValidationParameters = new TokenValidationParameters {

        ValidateIssuer = true, //Issuer kontrol et
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true, //secret key ile imzalanm�� olsun mu
        ValidIssuer = jwtConfig?.Issuer, //kontrol edece�in Issuer bu
        ValidAudience = jwtConfig?.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig?.Secret ?? "")) // e�er nullsa sa�dakini kullan diyor  secreti �ifrelemi� oluyoruz

    };  //tokenin do�rulanmas�n� sa�licak yani buraya gelen bilgiyi yani tokeni kontrol edip do�rulama i�lemi
});



var app = builder.Build();

using (var scope = app.Services.CreateScope()) {
// yaratt���m�z roleService yi alaca��   ve i�indeki role eklememetodunu �a��raca��z

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
