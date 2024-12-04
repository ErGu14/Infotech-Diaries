using Microsoft.AspNetCore.Mvc;
using Proje05_AspNetCoreEmpty.Models;
using System.ComponentModel.DataAnnotations;

namespace Proje05_AspNetCoreEmpty.Controllers
{
   
        
    
    public class ContactController : Controller
    {
        private readonly List<contact> _Contacts;

        public ContactController()
        {
            _Contacts = [
                new(){Phone="0555-555-55-55",Email="eray@contact.com",Adress="asdasd Caddesi jhjhj Sokak no 1 daire 5",GoogleMap="<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d48157.31952460709!2d28.971621940575666!3d41.02892101471938!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14cab7913b7b9b3f%3A0x154c9d69c759851e!2zSW5mb3RlY2ggQWNhZGVteSBZYXrEsWzEsW0gS3Vyc3UgKMWeacWfbGkvTWVjaWRpeWVrw7Z5IMWedWJlKQ!5e0!3m2!1str!2str!4v1732015215755!5m2!1str!2str\" width=\"600\" height=\"450\" style=\"border:0;\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>"}
                ];

        }

        public IActionResult Index()
        {
            ViewBag.contaxt = _Contacts;
            return View();
        }
    }
}
