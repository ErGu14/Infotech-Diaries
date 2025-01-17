var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // mvc ekledik

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name:"default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
