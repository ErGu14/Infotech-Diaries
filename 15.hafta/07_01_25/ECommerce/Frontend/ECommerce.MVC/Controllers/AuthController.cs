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

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }
            try
            {
                var response = await _authService.LoginAsync(loginModel);
                if (response.Errors == null)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(response.Data.AccessToken);
                    //Debug işlemi için token içindeki claimsleri loglayalım
                    foreach(var claim in token.Claims)
                    {
                        Console.WriteLine($"Claim: {claim.Type} => {claim.Value} ");
                    }
                    var userName = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? token.Claims.FirstOrDefault(c=>c.Type=="email")?.Value;
                    var userId = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                    var role = token.Claims.FirstOrDefault(c=>c.Type==ClaimTypes.Role)?.Value;
                    if (userName != null)
                    {
                        var claims = new List<Claim>
                         {
                             new Claim(ClaimTypes.Email, userName),
                             new Claim(ClaimTypes.Name, userName),
                             new Claim(ClaimTypes.NameIdentifier, userId),
                             new Claim(ClaimTypes.Role,role),
                             new Claim("AccessToken",response.Data.AccessToken)
                         };
                        var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            principal,
                            new AuthenticationProperties
                            {
                                ExpiresUtc= response.Data.ExpirationDate,
                                IsPersistent= true
                            });
                    }
                    //Sepete ekleme ile ilgili bir çalışmayı burada daha sonra yapacağız.
                    _toaster.AddSuccessToastMessage("Giriş işlemi başarıyla tamamlandı");
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Giriş hatası");
                return View(loginModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Giriş hatası: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Bir hata oluştu, daha sonra yeniden deneyiniz.");
                return View(loginModel);
            }
            return View();
        }
    
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _toaster.AddSuccessToastMessage("Çıkış işlemi başarıyla tamamlandı");
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
