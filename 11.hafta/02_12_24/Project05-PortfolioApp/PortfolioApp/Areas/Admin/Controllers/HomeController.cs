using Microsoft.AspNetCore.Mvc;

namespace PortfolioApp.Areas.Admin.Controllers
{
    [Area("Admin")] //areadaki admine ait demek
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
