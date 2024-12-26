using ECommerce.Shared.Dtos.Auth;
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
        Task<ResponseDTO<TokenDTO>> LoginAsync(LoginDTO loginDTO);
        Task<ResponseDTO<NoContent>> RegisterAsync(RegisterDTO registerDTO);

    }
}
