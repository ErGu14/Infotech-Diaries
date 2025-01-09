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
        var products = await _productService.GetAllActiveAsync(); // aktif ürünleri getiriyorum
        var model = new HomeIndexModel
        {
            Categories = categories,
            Products = products
        }; // hepsini ben viewde göstericeðim için index modele atýyorum çünkü viewde kodu yazarken arada bir köprü oluþturuyorum
        return View(model); // modellerle gösteriyoruz yani yeni bir home index oluþturup ürünleri ve kategorileri gösteriyoruz
    }
}
