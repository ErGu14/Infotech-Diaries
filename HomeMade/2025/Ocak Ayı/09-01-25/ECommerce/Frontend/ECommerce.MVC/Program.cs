using ECommerce.MVC.Abstract;
using ECommerce.MVC.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using NToastNotify;

// þimdi baþlamadan önce burda kendime not almak istiyorum : bu çalýþmada amacýmýýz bir apiyi bir projeye nasýl dahil edeceðimizi öðreniyoruz

// Öncelikle sað tarfata bildiðin üzere frontend ve backend adýnda 2 adet dosya var . bakcend yani bizim tabirimizle api yi temsil ediyor yalnýz bir proje yaparken bunu bu forentend kýmýna dahil etmene gerek yok çünkü ayrý ayrýda çalýþýlabilir ama buda bir çalýþma tekniði hani kimse sana neden böyle yapdýn demez nasýl rahat ediyorsan öyle çalýþ he tabi bunun bir artý yönü  var eðer olasý bir durumda backend de bir problem olursa hýzlý bir þekilde müdahale etmene olanak saðlar. þimdi aþaðýdada görüceðin gibi bir toasty denilen bir þey var bu nedir ? toasty dediðimiz sitelerdeki iþte giriþ yapýldý, sipariþ alýndý veya bir takým bildirim iþlerimizi yürütüyor bunun için bu MVC tarafýmýza NtoastyNotify adlý bir nuget paket indiriyoruz

// indirmemiz gerekenler = Auth..JWTBearer,NtoastNotify ve IdentityModel.TokensJWT  

// Auth..JWTBearer =  bu sistemdede bir kimlik doðrulama iþlemi olacaðýndan dolayý ve apiye veri gönderirken veya alýrken kimlik þeklinde iþlem yapmasýný saðlýyoruz yani kimlik doðrulama kýsaca

//IdentityModel.Tokens = jwt oluþturma , okuma iþlemlerini saðlar .
var builder = WebApplication.CreateBuilder(args);

// bu toast nugetinin dökümantasyonunu okuduðun zaman hangi animasyonlar nasýl görünüyor veya daha fazla ayar eklemek istersen hepsi yazýyor ilerde yapacaðýn projelerde eðer toaster kullanýcaksan okuman gerekli
builder.Services
    .AddControllersWithViews() // burasý zaten klasik bu projenin bir MVC Olduðunu söylüyoruz
    .AddNToastNotifyToastr(new ToastrOptions // bir toaster sistemi ekliceðimizi ve içine yeni bir toaster ayarý ekle diyoruz 
    {
        ProgressBar=true, // bildirimlerin altýnda ilerleme çubuðu olmasý
        PositionClass=ToastPositions.TopRight, // bildirimklerin ekranýn sað köþesinde olacaðýný belirtiyoruz 
        CloseButton=true, // kapama tuþu olucaðýný söylüyoruz
        TimeOut=5000, // 5 saniye boyunca açýk kalacaðýný belirtiyoruz
        ShowDuration=1000, // bildirimin açýlma animasyon süresi
        HideDuration=1000, // bildirimlerin kapanma animasyon süresi
        ShowEasing="swing", //bildirimlerin gösterilme animasyonu
        HideEasing="linear", //bildirimlerin kapanma animasyonu
        ShowMethod="fadeIn", //bildirimlerin ekranda belirme yöntemi
        HideMethod="fadeOut" // bildirimlerin ekrandan kaybolma yöntemi
    });

//her projede olduðu gibi program.cs ye nesne oluþturuyorsun
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IBasketService, BasketService>();    


builder
    .Services 
    .AddHttpClient(  // bu yazdýðýmýz kod bir http client oluþturur yani bizim tabirimizle bir api olucak
        "ECommerceAPI", // bu isteðin adý buranýn adýný istediðin gibi kullanabilirsin sadece dediðimiz gibi bir ad herhangi bir komut deðil ama biz bir service oluþturucaz ve serviste dicez ki kardeþim tama client kullanýcaz ama bu clientýn adý ne bana onu söyle ben bir client a istek yapýldýðýnda clientý tanýmlýyim  
        client => client.BaseAddress = new Uri("http://localhost:5050/api/") // burda ise lambda func kullanarak bu clientýmýz yani isteðimizin hangi adresi kullanacaðýný söylüyoruz ve istekler her oluþtuðunda dicez ki bana bu vlientý getirme ve clientýn istek adresinin saðýna þu þu yazýlarý ekle dicez  yüzden burasý çok önemli
    );

builder
    .Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme) // çerez dediðimiz bir kimlik doðrulama sistemi ekler ve içine bu çerezin þemasýný yani çözümleme tekniðini yazýyoruz hatýrlarsan burayý biz apide de yapmýþtýk fakat api þemasý kullandýk tek farký bu
    .AddCookie(options => // çerek metodunu ekliyoruz üsttekinden farký üste bir kimlik doðrulama ekle diyoruz ve þemayý belirtiyoruz burda iste kimlik doðrulamanýn ne olacaðýný ekliyoruz apiyse farklý cookie yani çerezse farklý 
    {
        options.Cookie.Name = "ECommerce.Auth"; // çerezimizin adý 
        options.LoginPath = "/Auth/Login"; // yetkisiz eriþimlerde nereye yollayacýðýný belirtir misal bu senaryomuzda kayýt olmamýþ kullanýcýlar alýþveriþ yapamaz diyip giriþ sayfasýna atýcaz
        options.AccessDeniedPath = "/Auth/AccessDenied"; // bir kullanýcý giriþ yapsýn veya yapmasýn eðer rolünün yetmediði bir yere eriþim saðlamaya kalakarsa yönelndirceðimiz sayfa burasý
        options.ExpireTimeSpan = TimeSpan.FromHours(1); // çerezin geçerlilik süresi 
        options.Cookie.HttpOnly = true; //çerezin sadece http istekleri ile eriþilebilir olduðunu belirtiyoruz yani güvenlik açýsýndan farklý bir isteðe cevap vermesini engelliyoruz tabi küçük bir önlem olsada önemli bir önlem
    });

builder.Services.AddAuthorization(); //burda ise yetkilendirme hizmeti ekliyorsun üstte kimlik oluþturma sistemini eklerken burda KÝMLÝKLENDÝRME sistemi eklemiþ oluyorsun

#region DataProtection
builder.Services.AddDataProtection() // burasý verilerin korunmasýný saðlýyor yani sitede yapýlýcak her bir iþlemin þifrenelerek yapýlmasýný saðlar
    .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(builder.Environment.ContentRootPath, "keys"))) // burdaki ...fileSystem in amacý bu korumanýn dosyasý sistemimde kaydedilmesini saðlar.   new DirectoryInfo ile diðerleri ise nereye ve hangi adla kaydedilmesi gerektiðiin söylüyoruz
    .SetApplicationName("ECommerce.MVC") // uygulama adýný belirtmek için kullanýyoruz sebebi ise  farklý uygulamalar ile de paylaþýlabilmesini saðlamak
    .SetDefaultKeyLifetime(TimeSpan.FromDays(14)); // keyin varlýk süresini belirler

builder.Services.AddDistributedMemoryCache(); // bu ise bellekte bir yer açmasýný ve bu iþlemin bellekte depolanmasýný saðlar ve projenin daha performanslý olmasýný saðlar
#endregion


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();  // http isteklerini direkt olaarak https e yollamayý saðlar

app.UseStaticFiles(); //wwwroot un kullanýlmasýný belirtir

app.UseRouting(); //uygulamanýn yönlendirme iþlevini aktif eder

app.UseAuthentication(); // kimlik doðrulama eklemesini saðlar

app.UseAuthorization(); // yetkilendirme eklenmesini saðlar

app.UseNToastNotify(); // toast mesajlarýnýn eklenmesini saðlar

app.MapAreaControllerRoute(
    name: "admin", // sadece rota tanýmlama adý 
    areaName: "Admin", // rotanýn ait olduðu dosya adý
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}", // rota URL sistemi
    defaults: new { area = "Admin" }); // rotanýn varsayýlan deðerlerini belirtir . burada alan adý admin olarak  ayarlý 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


// buralarý unutabilirsin ama zamanla oturtacaksýn  ilk olarak toaster vs buna benzer sistemler varsa eðer onlarý ekliyorsun dökümantosyonu okuyarak sonra api kullanacaðýn için addhttpclient ekliceksin he tabiki birden fazla api ekleyebilirsin sonra cookie kullanacaðýn için bir authentication ekliceksin ve þemasýný cookie olarak belirtip options ekliceksin iþe çerez adý yönlendirmeler çerezin varlýk süresi ve ne tür istekleri karþýlayacaðý gibi sonra addAuthorization diyerek bir yetkilendirme servisi ekliceksin en sonunda bu verilerin þifrelenip bir yandan performans açýsýndan bellekte depolanmasý için bir protection ekliceksin en sonunda bellekte depolansýn diye bir adddistributedMemoryCache diyerek bellekde yer açýk diceksin sonra UYGULAMA BUÝLD EDÝLDÝKTEN SONRA  kullanacaðý þeyleri iþte kimlik doðrulama yetkilendirme gibi þeyleri kullan diyoruz



// þimdi herþeyi tamamladýk vievlerde gördüðün gibi gerekli iþlemleri yapýp görünümleri güzelleþtiriyoruz gerekli verileri getiriyoruz vs

// gerekli admin panelide gezdik ve UI kýsmý tamamladýk aslýnda iþlemlere baktýðýn zaman zor deðil sadece kendine güven ve kariyerine odaklan zaten ilerde bunlarýn hepsi tereyaðýndan kýl çeker gibi kolay gelicek . Bu hayat senin ve kendine verdiðin sözünü tut.