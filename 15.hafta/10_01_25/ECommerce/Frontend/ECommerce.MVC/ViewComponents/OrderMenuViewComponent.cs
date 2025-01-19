using System;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.ViewComponents;

public class OrderMenuViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var currentAction = ViewContext.RouteData.Values["action"]?.ToString();
        ViewBag.CurrentAction = currentAction;
        return View();
    }
}
