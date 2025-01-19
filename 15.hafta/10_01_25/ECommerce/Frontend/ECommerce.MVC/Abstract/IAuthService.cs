using ECommerce.MVC.Models;

namespace ECommerce.MVC.Abstract
{
    public interface IAuthService
    {
        Task<ResponseModel<string>> RegisterAsync(RegisterModel registerModel);
        Task<ResponseModel<TokenModel>> LoginAsync(LoginModel loginModel);

    }
}
