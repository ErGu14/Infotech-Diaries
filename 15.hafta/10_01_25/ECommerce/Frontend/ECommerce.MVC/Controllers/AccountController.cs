using ECommerce.MVC.Abstract;
using ECommerce.MVC.Models.ComplexTypes;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.MVC.Controllers
{
    public class AccountController : Controller
    {
       

      

        public IActionResult Index()
        {
            return View();
        }
       
    }
}
