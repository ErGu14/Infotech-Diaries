using Microsoft.AspNetCore.Mvc;

namespace Proje04_MVCBasics.Controllers
{
    public class CategorieController : Controller
    {
        public IActionResult Index() { return View(); }
    }
}
