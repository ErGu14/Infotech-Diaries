using ECommerce.MVC.Abstract;
using ECommerce.MVC.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using NToastNotify;

// �imdi ba�lamadan �nce burda kendime not almak istiyorum : bu �al��mada amac�m��z bir apiyi bir projeye nas�l dahil edece�imizi ��reniyoruz

// �ncelikle sa� tarfata bildi�in �zere frontend ve backend ad�nda 2 adet dosya var . bakcend yani bizim tabirimizle api yi temsil ediyor yaln�z bir proje yaparken bunu bu forentend k�m�na dahil etmene gerek yok ��nk� ayr� ayr�da �al���labilir ama buda bir �al��ma tekni�i hani kimse sana neden b�yle yapd�n demez nas�l rahat ediyorsan �yle �al�� he tabi bunun bir art� y�n�  var e�er olas� bir durumda backend de bir problem olursa h�zl� bir �ekilde m�dahale etmene olanak sa�lar. �imdi a�a��dada g�r�ce�in gibi bir toasty denilen bir �ey var bu nedir ? toasty dedi�imiz sitelerdeki i�te giri� yap�ld�, sipari� al�nd� veya bir tak�m bildirim i�lerimizi y�r�t�yor bunun i�in bu MVC taraf�m�za NtoastyNotify adl� bir nuget paket indiriyoruz

// indirmemiz gerekenler = Auth..JWTBearer,NtoastNotify ve IdentityModel.TokensJWT  

// Auth..JWTBearer =  bu sistemdede bir kimlik do�rulama i�lemi olaca��ndan dolay� ve apiye veri g�nderirken veya al�rken kimlik �eklinde i�lem yapmas�n� sa�l�yoruz yani kimlik do�rulama k�saca

//IdentityModel.Tokens = jwt olu�turma , okuma i�lemlerini sa�lar .
var builder = WebApplication.CreateBuilder(args);

// bu toast nugetinin d�k�mantasyonunu okudu�un zaman hangi animasyonlar nas�l g�r�n�yor veya daha fazla ayar eklemek istersen hepsi yaz�yor ilerde yapaca��n projelerde e�er toaster kullan�caksan okuman gerekli
builder.Services
    .AddControllersWithViews() // buras� zaten klasik bu projenin bir MVC Oldu�unu s�yl�yoruz
    .AddNToastNotifyToastr(new ToastrOptions // bir toaster sistemi eklice�imizi ve i�ine yeni bir toaster ayar� ekle diyoruz 
    {
        ProgressBar=true, // bildirimlerin alt�nda ilerleme �ubu�u olmas�
        PositionClass=ToastPositions.TopRight, // bildirimklerin ekran�n sa� k��esinde olaca��n� belirtiyoruz 
        CloseButton=true, // kapama tu�u oluca��n� s�yl�yoruz
        TimeOut=5000, // 5 saniye boyunca a��k kalaca��n� belirtiyoruz
        ShowDuration=1000, // bildirimin a��lma animasyon s�resi
        HideDuration=1000, // bildirimlerin kapanma animasyon s�resi
        ShowEasing="swing", //bildirimlerin g�sterilme animasyonu
        HideEasing="linear", //bildirimlerin kapanma animasyonu
        ShowMethod="fadeIn", //bildirimlerin ekranda belirme y�ntemi
        HideMethod="fadeOut" // bildirimlerin ekrandan kaybolma y�ntemi
    });

//her projede oldu�u gibi program.cs ye nesne olu�turuyorsun
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IBasketService, BasketService>();    


builder
    .Services 
    .AddHttpClient(  // bu yazd���m�z kod bir http client olu�turur yani bizim tabirimizle bir api olucak
        "ECommerceAPI", // bu iste�in ad� buran�n ad�n� istedi�in gibi kullanabilirsin sadece dedi�imiz gibi bir ad herhangi bir komut de�il ama biz bir service olu�turucaz ve serviste dicez ki karde�im tama client kullan�caz ama bu client�n ad� ne bana onu s�yle ben bir client a istek yap�ld���nda client� tan�ml�yim  
        client => client.BaseAddress = new Uri("http://localhost:5050/api/") // burda ise lambda func kullanarak bu client�m�z yani iste�imizin hangi adresi kullanaca��n� s�yl�yoruz ve istekler her olu�tu�unda dicez ki bana bu vlient� getirme ve client�n istek adresinin sa��na �u �u yaz�lar� ekle dicez  y�zden buras� �ok �nemli
    );

builder
    .Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme) // �erez dedi�imiz bir kimlik do�rulama sistemi ekler ve i�ine bu �erezin �emas�n� yani ��z�mleme tekni�ini yaz�yoruz hat�rlarsan buray� biz apide de yapm��t�k fakat api �emas� kulland�k tek fark� bu
    .AddCookie(options => // �erek metodunu ekliyoruz �sttekinden fark� �ste bir kimlik do�rulama ekle diyoruz ve �emay� belirtiyoruz burda iste kimlik do�rulaman�n ne olaca��n� ekliyoruz apiyse farkl� cookie yani �erezse farkl� 
    {
        options.Cookie.Name = "ECommerce.Auth"; // �erezimizin ad� 
        options.LoginPath = "/Auth/Login"; // yetkisiz eri�imlerde nereye yollayac���n� belirtir misal bu senaryomuzda kay�t olmam�� kullan�c�lar al��veri� yapamaz diyip giri� sayfas�na at�caz
        options.AccessDeniedPath = "/Auth/AccessDenied"; // bir kullan�c� giri� yaps�n veya yapmas�n e�er rol�n�n yetmedi�i bir yere eri�im sa�lamaya kalakarsa y�nelndirce�imiz sayfa buras�
        options.ExpireTimeSpan = TimeSpan.FromHours(1); // �erezin ge�erlilik s�resi 
        options.Cookie.HttpOnly = true; //�erezin sadece http istekleri ile eri�ilebilir oldu�unu belirtiyoruz yani g�venlik a��s�ndan farkl� bir iste�e cevap vermesini engelliyoruz tabi k���k bir �nlem olsada �nemli bir �nlem
    });

builder.Services.AddAuthorization(); //burda ise yetkilendirme hizmeti ekliyorsun �stte kimlik olu�turma sistemini eklerken burda K�ML�KLEND�RME sistemi eklemi� oluyorsun

#region DataProtection
builder.Services.AddDataProtection() // buras� verilerin korunmas�n� sa�l�yor yani sitede yap�l�cak her bir i�lemin �ifrenelerek yap�lmas�n� sa�lar
    .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(builder.Environment.ContentRootPath, "keys"))) // burdaki ...fileSystem in amac� bu koruman�n dosyas� sistemimde kaydedilmesini sa�lar.   new DirectoryInfo ile di�erleri ise nereye ve hangi adla kaydedilmesi gerekti�iin s�yl�yoruz
    .SetApplicationName("ECommerce.MVC") // uygulama ad�n� belirtmek i�in kullan�yoruz sebebi ise  farkl� uygulamalar ile de payla��labilmesini sa�lamak
    .SetDefaultKeyLifetime(TimeSpan.FromDays(14)); // keyin varl�k s�resini belirler

builder.Services.AddDistributedMemoryCache(); // bu ise bellekte bir yer a�mas�n� ve bu i�lemin bellekte depolanmas�n� sa�lar ve projenin daha performansl� olmas�n� sa�lar
#endregion


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();  // http isteklerini direkt olaarak https e yollamay� sa�lar

app.UseStaticFiles(); //wwwroot un kullan�lmas�n� belirtir

app.UseRouting(); //uygulaman�n y�nlendirme i�levini aktif eder

app.UseAuthentication(); // kimlik do�rulama eklemesini sa�lar

app.UseAuthorization(); // yetkilendirme eklenmesini sa�lar

app.UseNToastNotify(); // toast mesajlar�n�n eklenmesini sa�lar

app.MapAreaControllerRoute(
    name: "admin", // sadece rota tan�mlama ad� 
    areaName: "Admin", // rotan�n ait oldu�u dosya ad�
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}", // rota URL sistemi
    defaults: new { area = "Admin" }); // rotan�n varsay�lan de�erlerini belirtir . burada alan ad� admin olarak  ayarl� 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


// buralar� unutabilirsin ama zamanla oturtacaks�n  ilk olarak toaster vs buna benzer sistemler varsa e�er onlar� ekliyorsun d�k�mantosyonu okuyarak sonra api kullanaca��n i�in addhttpclient ekliceksin he tabiki birden fazla api ekleyebilirsin sonra cookie kullanaca��n i�in bir authentication ekliceksin ve �emas�n� cookie olarak belirtip options ekliceksin i�e �erez ad� y�nlendirmeler �erezin varl�k s�resi ve ne t�r istekleri kar��layaca�� gibi sonra addAuthorization diyerek bir yetkilendirme servisi ekliceksin en sonunda bu verilerin �ifrelenip bir yandan performans a��s�ndan bellekte depolanmas� i�in bir protection ekliceksin en sonunda bellekte depolans�n diye bir adddistributedMemoryCache diyerek bellekde yer a��k diceksin sonra UYGULAMA BU�LD ED�LD�KTEN SONRA  kullanaca�� �eyleri i�te kimlik do�rulama yetkilendirme gibi �eyleri kullan diyoruz



// �imdi her�eyi tamamlad�k vievlerde g�rd���n gibi gerekli i�lemleri yap�p g�r�n�mleri g�zelle�tiriyoruz gerekli verileri getiriyoruz vs

// gerekli admin panelide gezdik ve UI k�sm� tamamlad�k asl�nda i�lemlere bakt���n zaman zor de�il sadece kendine g�ven ve kariyerine odaklan zaten ilerde bunlar�n hepsi tereya��ndan k�l �eker gibi kolay gelicek . Bu hayat senin ve kendine verdi�in s�z�n� tut.