using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace ECommerce.MVC.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        return View();
    }
}
