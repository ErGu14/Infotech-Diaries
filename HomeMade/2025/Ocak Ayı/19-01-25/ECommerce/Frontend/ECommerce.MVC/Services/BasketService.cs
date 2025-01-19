using ECommerce.MVC.Abstract;
using ECommerce.MVC.Models;
using System.Text.Json;

namespace ECommerce.MVC.Services
{
    public class BasketService : BaseService, IBasketService
    {
        public BasketService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor)
        {
        }

        public async Task AddToBasketAsync(BasketItemModel basketItemModel)
        {
            try
            {
                var client = GetHttpClient(); 
                var response = await client.PostAsJsonAsync("baskets/addtobasket", basketItemModel); // post işlemi gönderiyoruz

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException("API hata verdi"); // başarılı değilse hata verdiryirotuz
                }
                var jsonString = await response.Content.ReadAsStringAsync(); //okuyup stringe çeviriyoruz
                var result = JsonSerializer.Deserialize<ResponseModel<BasketItemModel>>(jsonString, _jsonSerializerOptions); // sonra somut bir şekilde elimize alıyoruz (json to c#)
                if (result?.Errors != null || result?.Errors?.Count > 0)
                {
                    throw new Exception($"Hata var: {string.Join(",", result.Errors)}"); // eğer errors um null gelmezse veya hata sayacım 0dan büyük gelirse hataları aralarına virgül koyarak gönder diyorum
                }
                if (result.Data == null)
                {
                    throw new Exception("Veri gelmedi"); // eğer resultum içindeki data bull yani boş gelirse hata olarak veri gelmedi diyorum 
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}"); // eğer yukarda ele alamadığım bir şey varsa hata olarak bana onu döndür diyoruz
                throw;
            }
        }

        public Task<bool> ChangeQuantityAsync(int basketItemId, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ClearBasketAsync(string applicationUserId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateBasketAsync(BasketModel basketModel)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketModel> GetBasketAsync(string applicationUserId)
        {
            try
            {
                // burdaki get isteği userId yi dinamik olarak endpointe eklememizi sağlıyor  yani belirli bir şeyi daha dinamik bir şekilde almamızı sağlıyor
                var client = GetHttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"baskets/{applicationUserId}"); // kullanıcı burayı tetikleidği anda kullanıcının ona ait sepetini getiriyoruz

                //client.DefaultRequestHeaders.Authorization
                var response = await client.SendAsync(request); // psotta nasıl jsonstring dediysek get işlemindede sadece send diyerek istenen bilgiyi gönderiyoruz veri tabanına silme updatelme gibi bişi olmadığı için direkt gelen bilgiyi gönderiyoruz
                if (!response.IsSuccessStatusCode)
                {
                    return new BasketModel(); // eğer kullanıcıya ait sepet yoksa ona ait bir sepet oluşturuyoruz
                }
                var jsonString = await response.Content.ReadAsStringAsync(); // stringe çevirip entere bastırdık
                var result = JsonSerializer.Deserialize<ResponseModel<BasketModel>>(jsonString, _jsonSerializerOptions); // json to c sharp
                //Klasik hata kontrollerini yap
                return result.Data; // kullanıcıya sepetini yada istenen datayı gönderiyoruz
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new BasketModel(); // hata ele alımı ama genellikle sepet bulunamadığındna yada seğetle alakalı bir durum söz konusu olunca yine yeni sepet oluşturup yolluyoruz
            }
        }

        public Task RemoveFromBasketAsync(int basketItemId)
        {
            throw new NotImplementedException();
        }
    }
}


// burda yaptığım her şey apideki gibi küçük küçük parçalara ayır ilk clientı getir sonra get se get işlemi yaptır postsa post delete ise delete  read diyip deserialize et sonra hataları ele al eğer kullanıcıya  bişi döndürüceksem result.data yı döndürcem döndürmiceksem eğer zaten void tanımlamışımdır hataları döndürürüm sadece