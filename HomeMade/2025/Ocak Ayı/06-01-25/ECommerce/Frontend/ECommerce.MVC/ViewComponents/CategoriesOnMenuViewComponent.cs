using System;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.ViewComponents;

public class CategoriesOnMenuViewComponent : ViewComponent
{

    public async Task<IViewComponentResult> InvokeAsync()
    {

        return View();
    }
}
