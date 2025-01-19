using ECommerce.Shared.DTOs.Auth;
using ECommerce.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IAuthService
    {
        Task<ResponseDTO<TokenDTO>> LoginAsync(LoginDTO loginDTO);
        Task<ResponseDTO<NoContent>> RegisterAsync(RegisterDTO registerDTO);
        Task<ResponseDTO<NoContent>> ForgotPasswordAsync(ForgotPasswordDTO forgotPasswordDTO);
        Task<ResponseDTO<NoContent>> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO);
    }
}
