using ECommerce.MVC.Abstract;
using ECommerce.MVC.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

//küçük site bildirimleri
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
//http client nesnesne ihtiyacým var çünkü veri gönderme ve veri çekme iþlemleri için  . Her bir istek için program.cs e nesneyi 1 kere yaratýcaz , burda ayarlicaz ve kullanýcaðýz.
builder.Services.AddHttpClient(
    "ECommerceAPI", //client adý
    client => client.BaseAddress = new Uri("http://localhost:5050/api/") // her bir isteðimin adresi yani http://localhost:5050/api  iþte bunu yaýcaz. 
    );

//kimliklendirme
// auth ayarlarýný buda yapýcaz . bir kullanýcý her bir sayfaya geçtiðinde tokeni sürekli kullansýn diye bir ayar yani Cookie ayarlarýný yapýcaz
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option => {

    option.Cookie.Name = "ECommerce.Auth"; //cookie adým 
    option.LoginPath = "/Auth/Login"; // kullanýcýnýn bir iþlevi kullanabilmesi için ilk önce giriþ sayfasýna atmasý lazým ise bu metodu kullanacaðýz
    option.AccessDeniedPath = "/Auth/AccessDenied"; // kullanýcý eðer yetkisi olmayan bir yere girmeye kalkarsa döneceði yer
    option.ExpireTimeSpan = TimeSpan.FromMinutes(60); //cookinin kullaným süresi
    option.Cookie.HttpOnly = true; //baþka protokollerden baðlamasýný bir nebzede olsa güvenlik önlemi alýyoruz


    
});


builder.Services.AddScoped<IAuthService, AuthService>();


// Yetkilendirme yani nerelere eriþmek istiyorum
//kolaylýkla apideki authorization yani yetkilerime eriþmek istiyorum
builder.Services.AddAuthorization();

//amacýmý cookiyi bile þifreli hale getirmek ayný api  gibi süresini hangi keyi kullanacak vs vs gibi bilgilerimizi yazýyoruz
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine
    (builder.Environment.ContentRootPath, "keys"))) // hangi keyi kullanacak
    .SetApplicationName("ECommerce.MVC") //hangi uygulama kullanacak
    .SetDefaultKeyLifetime(TimeSpan.FromDays(14)); //ne kadar süre kullanacak

builder.Services.AddDistributedMemoryCache(); //üst tarafý çalýþtýrmak için

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseNToastNotify(); //toast yani küçük sistem bildirimlerini kullan 

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
