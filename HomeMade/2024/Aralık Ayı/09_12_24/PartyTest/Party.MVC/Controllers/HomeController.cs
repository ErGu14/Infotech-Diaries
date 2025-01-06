using Microsoft.AspNetCore.Mvc;
using Party.Business.Concrete;
using System.Diagnostics;

namespace Party.MVC.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly InvitationService _invitationService;
        

        public HomeController(InvitationService invitationService)
        {
            _invitationService = invitationService;
        }

        public IActionResult Index()
        {
            var i = _invitationService.GetAll();
            return View(i);
        }

        
    }
}
