using ECommerce.Businnes.Abstract;
using ECommerce.Businnes.Configuration;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.Dtos.Auth;
using ECommerce.Shared.ResponseDTOs;
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

namespace ECommerce.Businnes.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly JwtConfig _jwtConfig;

        public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration, IOptions<JwtConfig> options)
        {
            _userManager = userManager;
            _configuration = configuration;
            _jwtConfig = options.Value; 
        }

        public async Task<ResponseDTO<TokenDTO>> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if(user == null)
            {
                return ResponseDTO<TokenDTO>.Fail("Böyle Bir Kullanıcı Bulunmamaktadı",400);
            }
            var isValidPassword = await _userManager.CheckPasswordAsync(user,loginDTO.Password);
            if(!isValidPassword) {
                return ResponseDTO<TokenDTO>.Fail("Şifre Hatalı", 400);
            }
            var tokenDTO = await GenerateJwtToken(user);
            return ResponseDTO<TokenDTO>.Success(tokenDTO,200);

        }

        public async Task<ResponseDTO<NoContent>> RegisterAsync(RegisterDTO registerDTO)
        {
            var existingUser = await _userManager.FindByEmailAsync(registerDTO.Email); //kullanınıcın verdiği emial varmı yok mu onu kontrol edicek
                
            if (existingUser != null) {
                return ResponseDTO<NoContent>.Fail("Böyle Bir Email Adresine Sahip Kullanıcı Mevcut",400);

            }
            ApplicationUser applicationUser = new (){
                  Email = registerDTO.Email,
                  FirstName = registerDTO.FirstName,
                  LastName = registerDTO.LastName,
                  UserName = registerDTO.Email,
                  Address = registerDTO.Address,
                  City = registerDTO.City,
                  Gender = registerDTO.Gender,
                  DateOfBirth = registerDTO.DateOfBirth

            
            };
          var result =  await _userManager.CreateAsync(applicationUser,registerDTO.Password); //savechanges gibi düşün oluştur diyorum ilk kullanıcı bilgilerini al sonra şifreyede dışardan gelen şifreyi al diyorum bunda ise password u şifrelicek
            if (!result.Succeeded)
            {
                return ResponseDTO<NoContent>.Fail(result.Errors.Select(x => x.Description).ToList(),400);
            }
            result =await _userManager.AddToRoleAsync(applicationUser,registerDTO.Role);
            if (!result.Succeeded)
            {
                return ResponseDTO<NoContent>.Fail(result.Errors.Select(x => x.Description).ToList(), 400);
            }
            return ResponseDTO<NoContent>.Success(201);
        }

        //token yaratacağımız metodumuzu yazmaya gidiyoruz
        private async Task<TokenDTO> GenerateJwtToken(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[] { 
            
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()) //jti = json token id ve rastgele string değerler oluştur dedim

            }.Union(roles.Select(r => new Claim(ClaimTypes.Role,r)));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secret));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddMinutes(_jwtConfig.AccessTokenExpiration);

            var token = new JwtSecurityToken(
                    issuer : _jwtConfig.Issuer,
                    audience : _jwtConfig.Audience,
                    claims : claims,
                    expires :expiry,
                    signingCredentials : credential
                );
            var tokenDTO = new TokenDTO { 
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                ExpirationDate = expiry
            };
            return tokenDTO;
        }
        
    }
}
