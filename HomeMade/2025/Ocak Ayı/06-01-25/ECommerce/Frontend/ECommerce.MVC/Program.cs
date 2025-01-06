using ECommerce.MVC.Abstract;
using ECommerce.MVC.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

//k���k site bildirimleri
builder.Services.AddControllersWithViews().AddNToastNotifyToastr(new ToastrOptions { 
    ProgressBar = true,
    PositionClass = ToastPositions.TopRight,
    CloseButton = true,
    TimeOut = 5000,
    ShowDuration = 1000,
    HideDuration = 1000,
    ShowEasing = "swing",
    HideEasing = "linear",
    ShowMethod = "fadeIn",
    HideMethod = "fadeOut"

});
//http client nesnesne ihtiyac�m var ��nk� veri g�nderme ve veri �ekme i�lemleri i�in  . Her bir istek i�in program.cs e nesneyi 1 kere yarat�caz , burda ayarlicaz ve kullan�ca��z.
builder.Services.AddHttpClient(
    "ECommerceAPI", //client ad�
    client => client.BaseAddress = new Uri("http://localhost:5050/api/") // her bir iste�imin adresi yani http://localhost:5050/api  i�te bunu ya�caz. 
    );

//kimliklendirme
// auth ayarlar�n� buda yap�caz . bir kullan�c� her bir sayfaya ge�ti�inde tokeni s�rekli kullans�n diye bir ayar yani Cookie ayarlar�n� yap�caz
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option => {

    option.Cookie.Name = "ECommerce.Auth"; //cookie ad�m 
    option.LoginPath = "/Auth/Login"; // kullan�c�n�n bir i�levi kullanabilmesi i�in ilk �nce giri� sayfas�na atmas� laz�m ise bu metodu kullanaca��z
    option.AccessDeniedPath = "/Auth/AccessDenied"; // kullan�c� e�er yetkisi olmayan bir yere girmeye kalkarsa d�nece�i yer
    option.ExpireTimeSpan = TimeSpan.FromMinutes(60); //cookinin kullan�m s�resi
    option.Cookie.HttpOnly = true; //ba�ka protokollerden ba�lamas�n� bir nebzede olsa g�venlik �nlemi al�yoruz


    
});


builder.Services.AddScoped<IAuthService, AuthService>();


// Yetkilendirme yani nerelere eri�mek istiyorum
//kolayl�kla apideki authorization yani yetkilerime eri�mek istiyorum
builder.Services.AddAuthorization();

//amac�m� cookiyi bile �ifreli hale getirmek ayn� api  gibi s�resini hangi keyi kullanacak vs vs gibi bilgilerimizi yaz�yoruz
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine
    (builder.Environment.ContentRootPath, "keys"))) // hangi keyi kullanacak
    .SetApplicationName("ECommerce.MVC") //hangi uygulama kullanacak
    .SetDefaultKeyLifetime(TimeSpan.FromDays(14)); //ne kadar s�re kullanacak

builder.Services.AddDistributedMemoryCache(); //�st taraf� �al��t�rmak i�in

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseNToastNotify(); //toast yani k���k sistem bildirimlerini kullan 

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}",
    defaults: new { area = "Admin" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
