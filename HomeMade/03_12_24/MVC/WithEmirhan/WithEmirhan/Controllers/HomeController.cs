using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WithEmirhan.Models;

namespace WithEmirhan.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

    }
}
