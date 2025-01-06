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
		private readonly IToastNotification _toast;

		public AuthController(IAuthService authService, IToastNotification toast)
		{
			_authService = authService;
			_toast = toast;
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
		public async Task<IActionResult> Login(LoginModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			try
			{
				var response = await _authService.LoginAsync(model);
				if (response.Errors == null)
				{
					var handler = new JwtSecurityTokenHandler(); //jwt ile ilgili operasyonları bunun sayesinde yapabilcez 
					var token = handler.ReadJwtToken(response.Data.AccessToken);

					//debug işlemi için token içindekileri claimleri loglama

					foreach (var claim in token.Claims)
					{
						Console.WriteLine($"Claim = {claim.Type} => {claim.Value}");
					}
					var userName = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value ?? token.Claims.FirstOrDefault(c => c.Type == "email")?.Value ;

					var userId = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

					var role = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
					if(userName != null)
					{
						var claims = new List<Claim> {
							new Claim(ClaimTypes.Email,userName),
							new Claim(ClaimTypes.Name,userName),
							new Claim(ClaimTypes.NameIdentifier,userId),
							new Claim(ClaimTypes.Role,role),
							new Claim("AccessToken",response.Data.AccessToken)
						
						};
						var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme); //claimleir bu şema olarak şifrele diyoruz
						var principal = new ClaimsPrincipal(identity); // identity yi de şifrele

						await HttpContext.SignInAsync(
								CookieAuthenticationDefaults.AuthenticationScheme,
								principal,
								new AuthenticationProperties {
									ExpiresUtc = response.Data.ExpirationDate,
									IsPersistent = true //beni hatırla
									
								}
							
							);
					}
					//sepete ekleme ile ilgili bri çalışmayı burada daha sonra yapacağız
					_toast.AddSuccessToastMessage("Giriş İşlemi Başarılı");
					return RedirectToAction("Index","Home");
				}
				ModelState.AddModelError(string.Empty,"Giriş Hatası");
				return View(model);
			}
			catch (Exception ex)
			{

                Console.WriteLine($"Giriş Başarısız: {ex.Message}");
				ModelState.AddModelError(string.Empty,"Bir Hata Oluştu Tekrar Deneyiniz.");
				return View(model);
            }
			return View();
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			_toast.AddSuccessToastMessage("Çıkış İşlemi Başarılı");
			return RedirectToAction("Index", "Home");
		}
	}
}
