using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Models;

namespace PortfolioApp.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

}

