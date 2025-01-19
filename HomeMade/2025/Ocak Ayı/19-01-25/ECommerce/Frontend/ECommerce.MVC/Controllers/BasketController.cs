using ECommerce.MVC.Abstract;
using ECommerce.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Security.Claims;

namespace ECommerce.MVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;
        private readonly IToastNotification _toaster;

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
        // burası ise sepete ekleme adında bir şey belirlenirse çalışacak
        public async Task<IActionResult> AddToBasket(int productId, int quantity) // dışardan eklencek ürün ve adetini alıyoruz
        {
            try
            {
                if (!User.Identity.IsAuthenticated)  // eğer kullanıcı giriş yapmadıysa
                {

                    // Login öncesi ürün bilgilerini TempData'ya kaydet

                    // yani eğer kullanıcı giriş yapmamışsa login sayfasına atmadan önce eklediği ürünleri kaydediyoruz
                    TempData["PendingProductId"] = productId; // datata ürünün ıd sini
                    TempData["PendingQuantity"] = quantity; // geçerli adetini
                    TempData["ReturnController"] = "Basket";// geri götürceği sayfanın controleri
                    TempData["ReturnAction"] = "AddToBasket"; // geri götüreceği actionı
                    
                    _toaster.AddInfoToastMessage("Sepete ekleme işlemi için giriş sayfasına yönlendirildiniz!", new ToastrOptions { TimeOut = 3000 }); // toaster ekleyip
                    return RedirectToAction("Login", "Auth"); // login sayfasına gönderiyoruz
                }
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // girişini yaptı burayı tetiklediyse kullanıcının Idsini alıyoruz
                var product = await _productService.GetAsync(productId); // ürünü getirirken ki ürünId sine göre getimreyi çağırıyoruz
                if (product == null) // eğer ürünümüz sistemde yoksa bulunamadı diye özel hazırlanmış metodu çağırıyoruz
                {
                    return NotFound();
                }
                var basket = await _basketService.GetBasketAsync(userId); // diyelim ürün var şimdi ise kullanıcıya ait sepeti getiriyoruz
                if (basket == null) // eğer sepet gelmiyorsa hata gönderip ana sayfaya yolluyoruz
                {
                    _toaster.AddErrorToastMessage("Profilinizde bir sorun var, sepete ekleme işlemi yapılamıyor, lütfen yönetim ile iletişime geçiniz!");
                    return RedirectToAction("Index", "Home");
                }
                BasketItemModel basketItemModel = new() // baktık sepet var kullanıcıda var üründe var şimdi ilgili sepete ilgili kişinin eklediği ürünleri getiricez . yeni bir sepetitem oluştur diyoruz
                {
                    BasketId = basket.Id, // ilgili sepeti burdan aldırıyoruz
                    ProductId = productId, // ilgili ürünü dışardan alıyoruz
                    Quantity = quantity // ilgili ürün adetini dışardan alıyoruz
                };
                await _basketService.AddToBasketAsync(basketItemModel); // sonra ise sepete eklenicek ürün modelimizi sepete ekle metodumuzla sepete ekliyoruz
                _toaster.AddSuccessToastMessage($"{quantity} adet {product.Name} sepete eklenmiştir."); // mesajımızı iletiyoruz
                return RedirectToAction("Index", "Home"); // ürünü ekle dediği anda an sayfaya yolluyoruz
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _toaster.AddErrorToastMessage(ex.Message);
                return RedirectToAction("Index", "Home"); // hata varsa mesaj verip ana sayfaya yolluyoruz
            }
        }
    }
}
