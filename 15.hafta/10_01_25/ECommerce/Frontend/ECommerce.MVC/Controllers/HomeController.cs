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
        var categories = await _categoryService.GetActiveCategoriesAsync();
        var products = await _productService.GetAllActiveAsync();
        var model = new HomeIndexModel
        {
            Categories = categories,
            Products = products
        };
        return View(model);
    }
}
