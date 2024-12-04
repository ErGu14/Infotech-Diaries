// bu sat�rda bir web uygulama olu�turucu yarat�l�yor
var builder = WebApplication.CreateBuilder(args); // 1- WebApplication = http pipeline(webden ba�lang��tan sonra do�ru istek i�lemleri) ve routes(gelen isteklerin nas�l kar��lan�r yani rota-navigasyon) web uygulamas� i�in gerekli nesne yani web olu�turma nesnesi 

// Bu sat�r projemizin mvc �zelliklerini ta��mas�n� sa�lar.
builder.Services.AddControllersWithViews(); 


//bu sat�rda ise yarat�lan uygulama olu�turucu ile bir uyguluma olu�turuluyor
var app = builder.Build(); // 2 - Builder.build = build et yani i�le (webi olu�tur)

// burada �a�r�lan metodlar/uygulamalar middleware olarak adland�r�l�r (ara yaz�l�m)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
}

app.UseHttpsRedirection();
app.UseStaticFiles(); //wwwroots a eri�im sa�lamak i�in

app.UseRouting(); // gelen istekle ilgili rotalama becerilerini kullan 

app.UseAuthorization(); // yetkilendirme



//Localhost:5200/Home/Index
//Localhost:5200/Home
//Localhost:5200
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); //var say�lan sayfaya gitme

app.Run(); // 3 - uygulamay� �al��t�r 
