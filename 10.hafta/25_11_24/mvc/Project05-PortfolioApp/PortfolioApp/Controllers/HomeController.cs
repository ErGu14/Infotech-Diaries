using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Models;

namespace PortfolioApp.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {

        var categories = _context.Categories.ToList(); //categories i liste olarak sql veritabanından çek (execute etmek)

        return View();
    }



}

