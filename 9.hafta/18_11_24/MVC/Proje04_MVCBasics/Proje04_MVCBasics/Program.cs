// bu satýrda bir web uygulama oluþturucu yaratýlýyor
var builder = WebApplication.CreateBuilder(args); // 1- WebApplication = http pipeline(webden baþlangýçtan sonra doðru istek iþlemleri) ve routes(gelen isteklerin nasýl karþýlanýr yani rota-navigasyon) web uygulamasý için gerekli nesne yani web oluþturma nesnesi 

// Bu satýr projemizin mvc özelliklerini taþýmasýný saðlar.
builder.Services.AddControllersWithViews(); 


//bu satýrda ise yaratýlan uygulama oluþturucu ile bir uyguluma oluþturuluyor
var app = builder.Build(); // 2 - Builder.build = build et yani iþle (webi oluþtur)

// burada çaðrýlan metodlar/uygulamalar middleware olarak adlandýrýlýr (ara yazýlým)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
}

app.UseHttpsRedirection();
app.UseStaticFiles(); //wwwroots a eriþim saðlamak için

app.UseRouting(); // gelen istekle ilgili rotalama becerilerini kullan 

app.UseAuthorization(); // yetkilendirme



//Localhost:5200/Home/Index
//Localhost:5200/Home
//Localhost:5200
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); //var sayýlan sayfaya gitme

app.Run(); // 3 - uygulamayý çalýþtýr 
