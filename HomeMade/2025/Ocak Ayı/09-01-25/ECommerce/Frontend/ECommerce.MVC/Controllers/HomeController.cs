using System.Diagnostics;
using ECommerce.MVC.Abstract;
using ECommerce.MVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace ECommerce.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;

    public HomeController(ICategoryService categoryService, IProductService productService)
    {
        _categoryService = categoryService;
        _productService = productService;
    }

    public async Task<IActionResult> Index() 
    {
        var categories = await _categoryService.GetActiveCategoriesAsync(); // aktif kategorileri getiriyorum
        var products = await _productService.GetAllActiveAsync(); // aktif �r�nleri getiriyorum
        var model = new HomeIndexModel
        {
            Categories = categories,
            Products = products
        }; // hepsini ben viewde g�sterice�im i�in index modele at�yorum ��nk� viewde kodu yazarken arada bir k�pr� olu�turuyorum
        return View(model); // modellerle g�steriyoruz yani yeni bir home index olu�turup �r�nleri ve kategorileri g�steriyoruz
    }
}
