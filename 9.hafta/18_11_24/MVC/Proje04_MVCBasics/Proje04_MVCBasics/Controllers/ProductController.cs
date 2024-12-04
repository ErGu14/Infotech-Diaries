using Microsoft.AspNetCore.Mvc;

namespace Proje04_MVCBasics.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
        //çok satan product action controller oluştur

        public IActionResult BestSellers()
        {
            return View();
        }
    }
}
