using ECommerce.Business.Abstract;
using ECommerce.Business.Configuration;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs.Auth;
using ECommerce.Shared.ResponseDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager; //ef core dan gelen bir yapı ve içerisine benim attığım user bilgilerini koyup burda çalıştırıcaz
        private readonly IConfiguration _configuration; // appsetting.jsondan gelen bilgi
        private readonly JwtConfig _jwtConfig; // spp.jsondaki token bilgilerini burda işlicez 

        //options a IOptions eklemeyi unutma
        public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration, IOptions<JwtConfig> options)
        {
            _userManager = userManager;
            _configuration = configuration;
            _jwtConfig = options.Value; // optionsdaki değerlerimi tke tek ele almaya yarıyor
        }

        public async Task<ResponseDTO<TokenDTO>> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                return ResponseDTO<TokenDTO>.Fail("Böyle bir kullanıcı yok", StatusCodes.Status400BadRequest);
            }
            var isValidPassword = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if (!isValidPassword)
            {
                return ResponseDTO<TokenDTO>.Fail("Hatalı şifre", StatusCodes.Status400BadRequest);
            }
            var tokenDTO = await GenerateJwtToken(user); //buraya kadar geldiyse kullanıcıyı içeriye sok
            return ResponseDTO<TokenDTO>.Success(tokenDTO,StatusCodes.Status200OK);
        }

        public async Task<ResponseDTO<NoContent>> RegisterAsync(RegisterDTO registerDTO)
        {
            var existingUser = await _userManager.FindByEmailAsync(registerDTO.Email);
            if (existingUser != null)
            {
                return ResponseDTO<NoContent>.Fail("Bu mail adresi ile kayıtlı kullanıcı mevcut!", StatusCodes.Status400BadRequest);
            } // buraya kadar eğer email varsa kayıtlı yani hata gönder

            // eğer eposta yoksa bilgileir tek tek doldur
            ApplicationUser applicationUser = new()
            {
                Email= registerDTO.Email,
                FirstName= registerDTO.FirstName,
                LastName= registerDTO.LastName,
                UserName=registerDTO.Email,
                Address=registerDTO.Address,
                City=registerDTO.City,
                Gender=registerDTO.Gender,
                DateOfBirth=registerDTO.DateOfBirth
            };
            // aldığımız bilgileri create diyerek oluşturuyoruz ve şifreyi ayru bir şekilde belirtiyoruz
            var result = await _userManager.CreateAsync(applicationUser,registerDTO.Password);
            // eğer kullanıcı bir şeyi yanlış girerse hatayı döndürücez
            if(!result.Succeeded)
            {
                return ResponseDTO<NoContent>.Fail(result.Errors.Select(x=>x.Description).ToList(), StatusCodes.Status500InternalServerError);
            }
            //rol ekledik
            result = await _userManager.AddToRoleAsync(applicationUser, registerDTO.Role);
            if (!result.Succeeded)
            {
                return ResponseDTO<NoContent>.Fail(result.Errors.Select(x => x.Description).ToList(), StatusCodes.Status500InternalServerError);
            }
            return ResponseDTO<NoContent>.Success(StatusCodes.Status201Created);
        }
    
        private async Task<TokenDTO> GenerateJwtToken(ApplicationUser user) // her bir kullanıcı i.in token oluşturucaz
        {
            var roles = await _userManager.GetRolesAsync(user); // kullanıcın rolleri

            var claims = new[] // neyi taşiyacaksa claim adı altında alıyoruz           token ile alıancak bilgileri altta eşleştiriyoruz
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id), // kullanıcı Id si
                new Claim(ClaimTypes.Email, user.Email), // email
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // adları şifrele diyoruz
            }.Union(roles.Select(r=>new Claim(ClaimTypes.Role,r))); // kullanıcıları tek tek seçip rollerini ekliyoruz

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secret));  //byte tipinde şifreliyoruz
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); // şifrelenmiş keyi daha kapsamlı şifreliyoruz
            var expiry = DateTime.Now.AddMinutes(_jwtConfig.AccessTokenExpiration); //jsonda daki expirationa ulaş ve kullanıcının tokeni kullanacağı süre tipini yani dakikamı saniyemi belirtiyorsun

            var token = new JwtSecurityToken(// güvenli bir jwt token oluşturuyorsun
                issuer: _jwtConfig.Issuer, // tokeni oluşturan kişiyi burdan al
                audience: _jwtConfig.Audience, // kullanıcakları burdan al
                claims: claims, // tokenin kime ait olduğunu belirten yani tokeni oluşturan kişinin bilgilerini burdan al diyoruz
                expires: expiry, // süresini burdan al diyoruz
                signingCredentials: credential //secreti burdan al diyoruz
                );
            var tokenDTO = new TokenDTO // kullanıcıya göstereceğimiz tokeni sadece istediğim şekilde göstericem yani kullanacağı süresi ve tokenin kendisi
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token), // güvenli token ele alıcı ekleyip tokeni yaz diyoruz ama yazacağı token bilgisini üstte yazdığım token varya ordan al diyoruz
                ExpirationDate = expiry, // süreyide yukardan alabilirsin ekstra bişi yazmana gerek yok
            };
            return tokenDTO; //dto tipinde döndürüyoruz
        }
    }
}
