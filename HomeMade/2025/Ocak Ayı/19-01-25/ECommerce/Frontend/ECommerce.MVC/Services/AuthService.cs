using ECommerce.MVC.Abstract;
using ECommerce.MVC.Models;
using System.Text.Json;

namespace ECommerce.MVC.Services
{
    public class AuthService : BaseService, IAuthService
    {
        public AuthService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor):base(httpClientFactory, httpContextAccessor) { } // burayı yapmamızın sebebi biz backend kısmında db ile projemizi bağlarken o arasındaki bağlantıyı nasıl yapıyorsak burdada apimiz ile frontendimizden gelen bilgileri eşlememiz için gerekli bunu tüm servicelerden kullancaz

        public async Task<ResponseModel<TokenModel>> LoginAsync(LoginModel loginModel)
        {
            var client = GetHttpClient();  // client bilgilerini alıyoruz yani hangi apiyi kullanıcak vs gibi bilgileri alıyoruz
            var response = await client.PostAsJsonAsync("auth/login", loginModel); // hangi adrese post işlemi yapıcam onu seçip ve post yaparken hangi verileri kullancam onu belirtiyorum
            var responseBody = await response.Content.ReadAsStringAsync(); // okuyorum ve stringe çeviriyorum
            var result = JsonSerializer.Deserialize<ResponseModel<TokenModel>>(responseBody, _jsonSerializerOptions); // sonra bu benim stringlediğimiz şeyi  deserialize edip tabi token model türünde içerisinde access token ve expiration bilgim var ona döndürücem ve _jsonSerializerOptions diyerek benim base servicemdeki camelcase gibi kuralları işle diyoruz
            return result; // sadece döndürüyoruz
        }

        public async Task<ResponseModel<string>> RegisterAsync(RegisterModel registerModel)
        {
            var client = GetHttpClient();
            var response = await client.PostAsJsonAsync("auth/register",registerModel);
            var responseBody = await response.Content.ReadAsStringAsync();
            var result= JsonSerializer.Deserialize<ResponseModel<string>>(responseBody,_jsonSerializerOptions);
            return result;
        }

        
    }
}
