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
// UI kýsmýnda dediðim gibi hangi areaya ait bir kontroller olduðunu ve hangi yetkili kiþiler buraya girebilir onu söylemiþ olduk