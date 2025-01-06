using ECommerce.Shared.Dtos.AuthDTOs;
using ECommerce.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Businnes.Abstract
{
    public interface IAuthService
    {
        Task<ResponseDTO<TokenDTO>> Login(LoginDTO loginDTO); // KULLANICIYA giriş yaptıktan sonra kullanabileceği bir token bilgisi döndürücem
        Task<ResponseDTO<NoContent>> Register(RegisterDTO registerDTO); // adam zaten kayıt olucak adama kayıt bilgilerini döndürmeme ne gerek var direk sisteme kaydolsun ve login diyip tokenini orda alıcak zaten
    }
}
