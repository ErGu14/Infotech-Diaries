using ECommerce.MVC.Abstract;
using ECommerce.MVC.Models;
using ECommerce.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Security.Claims;

namespace ECommerce.MVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IToastNotification _toaster;
        private readonly IProductService _productService;

        public BasketController(IBasketService basketService, IToastNotification toaster, IProductService productService)
        {
            _basketService = basketService;
            _toaster = toaster;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddToBasket(int productId,int quantity)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {

                    _toaster.AddInfoToastMessage("Sepete Ürün Eklemek İçin İlk Önce Giriş Yapmalısınız", new ToastrOptions { TimeOut = 3000 });
                    return RedirectToAction("Login", "Auth");
                }
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var product = await _productService.GetAsync(productId);
                if (product == null)
                {
                    return NotFound();
                }
                var basket = await _basketService.GetBasketAsync(userId);
                if (basket == null) { _toaster.AddErrorToastMessage("Profilinizde Bir Sorun Var, Sepete Ekleme Yapılamıyor, Lütfen Yönetim İle İletişime geçiniz"); return RedirectToAction("Index", "Home"); }
                BasketItemModel basketItemModel = new BasketItemModel() { BasketId = basket.Id, ProductId = productId, Quantity = quantity };
                await _basketService.AddToBasketAsync(basketItemModel);
                _toaster.AddSuccessToastMessage($"{quantity} adet {product.Name} sepete eklenmiştir.");
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata Var : {ex.Message}");
                _toaster.AddErrorToastMessage(ex.Message);

                return RedirectToAction("Index","Home");
            }
        }
    }
}
