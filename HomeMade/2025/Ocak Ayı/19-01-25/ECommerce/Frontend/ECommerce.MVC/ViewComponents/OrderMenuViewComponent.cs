using System;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.ViewComponents;

public class OrderMenuViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var currentAction = ViewContext.RouteData.Values["action"]?.ToString(); // burasý geçerli iþlemin route versini alýr 
        ViewBag.CurrentAction = currentAction; // geçerli routu vievde kullanmak için çatlar ve returnleriz
        return View();
    }
}

/*
 
 Neden Yazýyoruz ?

    amacýmýz geçerli eylemi almak ve bu bilgiyi bir view de kullanmak için ama birkaç nedeni daha var :

    geçerli eylem adýna göre görünümde dinamik içerik göstermek isteyebiliriz. örneðin , menüdeki belirli bir öðeyi vurgulamak veya sayfa baþlýðýný geçerli eylem adýna göre ayarlamak

  yani telefona týkladýysam sayfanýn baþlýðýný telefon yapmak için kýsa yoldan
 
 
 */