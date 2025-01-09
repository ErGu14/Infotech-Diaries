using ECommerce.MVC.Models;

namespace ECommerce.MVC.Abstract
{
    public interface IAuthService
    {
        Task<ResponseModel<string>> RegisterAsync(RegisterModel registerModel); // kullanıcı kayıt olduğunda herhangi bir şekilde ona token vs vermicem sadece veri tabanında onu kaydedicem bu kadar o yüzden string diyerek boş döndürcem

        Task<ResponseModel<TokenModel>> LoginAsync(LoginModel loginModel);

    }
}
