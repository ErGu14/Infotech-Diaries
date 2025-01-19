using ECommerce.MVC.Abstract;
using ECommerce.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ECommerce.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IToastNotification _toaster;
        public AuthController(IAuthService authService, IToastNotification toaster)
        {
            _authService = authService;
            _toaster = toaster;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login() // login sayfasını tetiklettim
        {
            return View();
        }

        [HttpPost] // buranın bir post işlemi olduğunu belirtip veri gelceğini söylüyorum
        public async Task<IActionResult> Login(LoginModel loginModel) // dışardan veri tipi ve veri adı
        {
            if (!ModelState.IsValid) // eğer gönderimde bir sorun olursa
            {
                return View(loginModel); // verileri geri göster hani kayıt olurken uygun olanları dolu bıraksın bırakmadıklarıda hatalarımız zaten
            }
            try // yaptığımız programlamada eğer bir veri gönderme getirme veya aklına gelecek tüm işlemlerde profesyonel hayatta try catch yapısını kullanman gerekli çünkü belki senin aklına gelemiyecek hataların yakalanıp daha kolay bir şekilde çözümünü sağlamalısın
            {
                var response = await _authService.LoginAsync(loginModel); // buraya geldiysek eğer dışardaki veriyi alıp loginin içine attık
                if (response.Errors == null) // eğer erros null gelirse yani herşey başarılıysa
                {
                    var handler = new JwtSecurityTokenHandler(); // jwtleri doğrulama oluşturma ve okuma veya ayrıştırma gibi işlemleri yapıcak 
                    var token = handler.ReadJwtToken(response.Data.AccessToken); // tokeni oku ve ayrıştır. token bilgisinide responsda oluşan datanın access tokenını alıcak demek
                    //Debug işlemi için token içindeki claimsleri loglayalım
                    foreach (var claim in token.Claims)
                    {
                        Console.WriteLine($"Claim: {claim.Type} => {claim.Value} "); // burada tektek gelen claimleri oku ve değerlerini karşısına yaz yani logluyoruz kısaca değerler geliyormu gelmiyor mu 
                    }
                    var userName = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? token.Claims.FirstOrDefault(c => c.Type == "email")?.Value; // apiden claimi türü eposta olanı getir ama bulamazsan türü AD Olarak email olan ilk değeri getir diyoruz ama bu sondaki bizim kodumuzda yok sadece hata ele alımı 
                    var userId = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value; // gelen claimdeki user ıd si ilk bulunanaı getir uyuşan tabii ki
                    var role = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value; // rolünü getir
                    if (userName != null) // eğer işlemlerimiz başarılıysa hepsi geldiyse username de null gelmediyse
                    {
                        var claims = new List<Claim> // cookie için bu sefer yeni bir claim oluşturuyoruz  ama şöyle biz varsayılan olarak cookie nin eleman sayılarını bilmediğimiz için liste olarak alıyoruz
                         {
                             new Claim(ClaimTypes.Email, userName), //email türünü usernameden
                             new Claim(ClaimTypes.Name, userName), // name kısmını yine usernameden
                             new Claim(ClaimTypes.NameIdentifier, userId??string.Empty), // ıd sini user ıd den fakat Id kısmı boş gelirse boş bir string alıyoruz 
                             new Claim(ClaimTypes.Role,role??string.Empty), // yukardakinin aynısı şeklinde rolleri alıyoruz
                             new Claim("AccessToken",response.Data.AccessToken) // access token bilgisini gelen claimden alıyorum ve içine dolucak şeyide benim dışardan gelen tokenimden alıyorum
                         };
                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); // yeni bir identity yani kullanıcı ve onun claimlerini oluşturuyorum
                        var principal = new ClaimsPrincipal(identity); //vurda identity i şifreliyorum
                        await HttpContext.SignInAsync( // bizim httpcontexten gelen sign inasync yani giriş yapma metodumuz var bu tabiki indirdiğimiz eklentilerden geliyor
                            CookieAuthenticationDefaults.AuthenticationScheme, // giriş yaparken hangi cookie şemasını kullanacak
                            principal, // hangi bilgileri esas alıcak
                            new AuthenticationProperties // yeni bir kimlik oluşturuyoruz
                            {
                                ExpiresUtc = response.Data.ExpirationDate, // kimliğin UTC türünde ne kadar süre durcağı
                                IsPersistent = true // beni hatırla adlı seçeneğimiz olucağını
                            });
                        // Bekleyen sepet işlemi kontrolü
                        if (TempData["PendingProductId"] != null && TempData["PendingQuantity"] != null)
                        {
                            string returnController = TempData["ReturnController"] as string ?? string.Empty;
                            string returnAction = TempData["ReturnAction"] as string ?? string.Empty;
                            int pendingProductId = TempData["PendingProductId"] as int? ?? 0;
                            int pendingQuantity = TempData["PendingQuantity"] as int? ?? 0;

                            return RedirectToAction(returnAction, returnController, new
                            {
                                productId = pendingProductId,
                                quantity = pendingQuantity
                            });
                        }
                    }
                    //Sepete ekleme ile ilgili bir çalışmayı burada daha sonra yapacağız.
                    _toaster.AddSuccessToastMessage("Giriş işlemi başarıyla tamamlandı"); // yuakrdkai sepet işlemini yarın anlatıcak şuanlık geçelim analtmazsa eğer zaten biz tekrar dönücez buraya  ama burası ise giriş başarılı olduktan sonra toast yolluyoz
                    return RedirectToAction("Index", "Home"); // giriş yaptıktan sonra ana sayfaya atıyoruz
                } 
                ModelState.AddModelError(string.Empty, "Giriş hatası"); // eğer username bilgisi null gelirse hata ekliyoruz    ilk baştağı keyimiz yani hata türümüz onu boş bırakıyoruz çünkü gelicek hatanın türünü bilmiyoruz yani genel bir hata olduğunu söylüyoruz
                return View(loginModel); // klasik giriş bilgirei doğru olanları gösteriyoruz
            }
            catch (Exception ex) // hatamız varsa hataları göster ve returnle
            {
                Console.WriteLine($"Giriş hatası: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Bir hata oluştu, daha sonra yeniden deneyiniz.");
                return View(loginModel);
            }
            return View(); // klasik düz sayfaya returnlemesi
        }

        public async Task<IActionResult> Logout() // kullanıcı bunu tetiklediği anda burası çalışçak
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); // httpcontext.singout dediğimizde yine hangi şemayı kullancağını söyleyip  çıkış yapıyoruz ve bizim sayfada incele diyip application bölümümüzde bulunan cookies kısmında kullanıcının verisinin silinmesini sağlıyoruz
            _toaster.AddSuccessToastMessage("Çıkış işlemi başarıyla tamamlandı"); //toaster mesajı
            return RedirectToAction("Index", "Home"); // ana sayfaya yönlendirme
        }

        public IActionResult AccessDenied() // biz view kısmında eğer kullanıcı yetkisi yetmezse burayı döndür dicez yani yetki yetersizliği hatası
        {
            return View();
        }
    }
}
