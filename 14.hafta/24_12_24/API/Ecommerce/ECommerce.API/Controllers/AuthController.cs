using ECommerce.Businnes.Abstract;
using ECommerce.Shared.Dtos.Auth;
using ECommerce.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : CustomControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
            var response = await _authService.RegisterAsync(register);
            return CreateResponse(response);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var response = await _authService.LoginAsync(login);
            return CreateResponse(response);
        }
    }
}
