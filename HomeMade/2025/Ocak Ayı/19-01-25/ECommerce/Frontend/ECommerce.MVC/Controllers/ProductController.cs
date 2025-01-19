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

        public async Task<IActionResult> GetAllByCategory(int id, string category) // tüm ürünleri kategorileriyle getiriyoruz   yani adam ayakkabı dediği anda ayakkabı kategorisindeki ayakkabıları getircek
        {
            var products = await _productService.GetAllByCategoryAsync(id); // id ye göre ürünü getiriyoruz hatta ürünleri
            ViewData["CategoryName"] = category; // datamızda bulunanan kategori adını dışardan alacağı kategoriyle eşleştiriyoruz
            return View(products); // ürünleri gösteriyoruz
        }

        public async Task<IActionResult> Details(int id) // ilgili ürünün detay sayfasına götürcez
        {
            var product = await _productService.GetAsync(id); // ilgili ürünü al ve detay sayfasına götür
            return View(product); // gerekli view e product bilgisini alıp döndür
        }
    }
}
