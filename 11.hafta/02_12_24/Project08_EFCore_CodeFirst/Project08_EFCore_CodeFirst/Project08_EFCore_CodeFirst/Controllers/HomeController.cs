using Microsoft.AspNetCore.Mvc;
using Project08_EFCore_CodeFirst.Models;
using System.Diagnostics;
namespace Project08_EFCore_CodeFirst.Controllers { 
    public class HomeController : Controller {
        private readonly AppDbContext _context; 
        public HomeController(AppDbContext context) { 
            _context = context; 
        } 
        public IActionResult Index() { 
            return View(); 
        } 
        public IActionResult Create() {
            return View(); 
        } 
        [HttpPost] 
        public IActionResult Create(Student student) {
            if (ModelState.IsValid) { 
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index"); 
            } 
            return View(student); 
        }
    }
}