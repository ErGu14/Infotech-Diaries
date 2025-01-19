using ECommerce.MVC.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllByCategory(int id, string category)
        {
            var products = await _productService.GetAllByCategoryAsync(id);
            ViewData["CategoryName"] = category;
            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetAsync(id);
            return View(product);
        }
    }
}
