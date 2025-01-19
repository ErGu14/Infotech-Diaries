using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="AdminUser")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); 
        }
    }
}
// UI k�sm�nda dedi�im gibi hangi areaya ait bir kontroller oldu�unu ve hangi yetkili ki�iler buraya girebilir onu s�ylemi� olduk