using System.Net.Http.Headers;
using System.Text.Json;

namespace ECommerce.MVC.Abstract
{
	public abstract class BaseService
	{
		protected readonly IHttpClientFactory _httpClientFactory; //clint nesnesi yaratma ve ayarlarını kullanma
		protected readonly IHttpContextAccessor _HttpContextAccessor; //cookilere vs ulaşım için
		protected readonly JsonSerializerOptions _jsonSerializerOptions; // amacımız jsonu çevirirken vs isimlerin doğruluğunu yani camel case mi büyük küçük uyumlu mu? gibi kontrolleri yapmamız lazım

		protected BaseService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
		{
			_httpClientFactory = httpClientFactory;
			_HttpContextAccessor = httpContextAccessor;
			_jsonSerializerOptions = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase, //camel case kuralını kullan
				PropertyNameCaseInsensitive = true //büyük küçük harf duyarlılığı

			};
		}
		// http isteğinde bulunacağım nesne
		protected HttpClient GetHttpClient()
		{
			// auth bilgileri,token bilgileri gibi 
			
			//client çağırma
			var client = _httpClientFactory.CreateClient("ECommerceAPI");

			//token çağırma ilgili tokeni yani
			var token = _HttpContextAccessor.HttpContext.Request.Cookies["AccessToken"];
			if (!string.IsNullOrEmpty(token))
			{
				//kullanıcı login olursa token ı işler
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
			}
			return client;
		}
	}
}
