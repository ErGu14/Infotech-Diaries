using System;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.ViewComponents;

public class OrderMenuViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var currentAction = ViewContext.RouteData.Values["action"]?.ToString(); // buras� ge�erli i�lemin route versini al�r 
        ViewBag.CurrentAction = currentAction; // ge�erli routu vievde kullanmak i�in �atlar ve returnleriz
        return View();
    }
}

/*
 
 Neden Yaz�yoruz ?

    amac�m�z ge�erli eylemi almak ve bu bilgiyi bir view de kullanmak i�in ama birka� nedeni daha var :

    ge�erli eylem ad�na g�re g�r�n�mde dinamik i�erik g�stermek isteyebiliriz. �rne�in , men�deki belirli bir ��eyi vurgulamak veya sayfa ba�l���n� ge�erli eylem ad�na g�re ayarlamak

  yani telefona t�klad�ysam sayfan�n ba�l���n� telefon yapmak i�in k�sa yoldan
 
 
 */