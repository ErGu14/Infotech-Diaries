using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace ECommerce.MVC.Abstract
{
    // şimdi burda amacımız abstract diyerek her service mizin temel alacağı biryer olacağını belirtiyoruz  burdaki protected dediğimiz şey  bu classı sadece miras alan veya bu classı türeten bir dosya kullanabilir diyirouz (birden fazlada olabilir sadece açıklama gereği yazdım)
    public abstract class BaseService
    {
        protected readonly IHttpClientFactory _httpClientFactory; // http istemcisi oluşturmak için
        protected readonly IHttpContextAccessor _httpContextAccessor; // buda oluşan http ye bağlanmak için oluşturduk 
        protected readonly JsonSerializerOptions _jsonSerializerOptions; // burasıda jsonu serileştirme yani json to c# gibi işlemleri elimize alırız

        protected BaseService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _jsonSerializerOptions = new JsonSerializerOptions // yeni bir serializer oluşturmamızı sağlıyor
            {
                 PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // adlandırma politikasını yani adlandırma şeklini camel case şeklinde yapar yani tüm baş harfler büyük diğer harfler küçük
                 PropertyNameCaseInsensitive = true // büyük küçük harf duyarlılığını algılamamıza yarar şimdi şey diyebilrisin zaten yukarda camel case kullandık buna ne gerek var ? bel kide isticeğimiz dosya adı MeRhaBa  gibi karışık yazılan birşey de olabilir
            };
        }

        protected HttpClient GetHttpClient() // burda ise koruma bir http isteği oluşturucam yani bunu çağırınca hangi tokeni kullanacağımızı  ve hangi clientı kullanacağız gibi bilgileri alır ve işleyip ona göre apiye istekte  bulunabilirz ve şuda var buluncağımız apinin adres ve özelliklerini zaten program.cs de tanımladık şimdi işleme sırasına geldik
        {
            var client = _httpClientFactory.CreateClient("ECommerceAPI"); // Ecommerce adında bir client oluşturuyoruz  hatırladıysan bu yazı program.cs de de aynı olan ad program.cs de alacağımız apinin adres adını yazıyorduk şimdi ise burda ordan gelicek adres + buraya düşen adresi birleştirerek apiden istek yapıyoruz bak farkındaysak herşey parçalı şekilde ben aynı api üzerinden istek yapacağım için her taraf kullanabilsin diye program.cs e kaydettim burası iste isteğe bağlı bir durum yani ben nerde isticeksem api kullanmayı orda burayı kullancam
            var token = _httpContextAccessor?.HttpContext?.User.FindFirstValue("AccessToken"); // burda iste mevcut http bağlamında kullanıcının erişim belirtecini yani tokenini alır 
            if (!string.IsNullOrEmpty(token))  // eğer token boş veya null gelirse ;
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);  // clientın içine varsayılan bir istek ekle ama bu isteğin türü yetkilendirme isteği ve yeni bir yetkilendirme başlığı değeri ekliyorsun . içine ise hangi yetkilendirme kullanılacağı ve hangi bilgileri girceğini yazıcaz yani postmandeki bir update işleminde nasıl authentication bilgisi yaz dediğimde value kısmına oluşan tokeni yazıp bu tokenin işleme türünü bearer olarak seçiyorsam burda da aynısını yapıyorum
            }
            return client; // en sonda ise clientı döndürücem yani bir istekde bulunduğumda bana tüm sonuçları diğer kodum için döndürecek
        }
    }
}
