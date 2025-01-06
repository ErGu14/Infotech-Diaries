using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerce.Shared.ResponseDTOs
{
    public class ResponseDTO<T> // şimdi bunlar ben api işlemlerinde görüncek yapıyı oluşturuyorum burda datamız veriyi göstericek -erros çekme kısmında hata varken mesajı göstercek issucceded veriyi gönderdimi herhangi bir sorun varmı onu döndürcek   status code ise veri alıp göndermede herhangi bir sorun varmı yok mu onu döndürüyoruz   ama bu senaryoda IsSucceded ve status code u karşı tarafa göndermek istemiyorum lakin c# kodu olarak işlem yapmak için [JsonIgnore]  DİYEREK BUNLARI JSON TİPİNE DÖNÜŞTÜRÜP karşı tarafa atma demek istiyorum
    {
        public T? Data { get; set; }
        public List<string> Errors { get; set; }
        [JsonIgnore]
        public bool IsSucceded { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }

        // şimdi işlemlerimizi yapıcaz işlem dediğimiz başarılıysa bunu döndür  değilse bunu göster gibi işlemlerimiz yapıcaz ama bunları yaparken DTO olarak çağırıcam verileri dtolarıda MAPPİNG ile datadaki tabloları dto lara çeviricem ve veriyi gönderirken gelen dtoları dataya benzeterek gönder dicem bu işlemleri ilk mapping olarak yapıcaz ama burda şuan bu işe girmicez


        // başarılı olduğu zaman veriyi ve durum kodunu döndürcez işte başarılıysa 200 gibi
        public static ResponseDTO<T> Success(T data, int statusCode)
        {

            return new ResponseDTO<T>
            {
                Data = data,  // datamın içerisine dışardan datayı at
                StatusCode = statusCode, // burdaki statıs koda dışardan gelen status kodu at
                IsSucceded = true // eğer bu çağrılmış ise başarılı mı (IsSucceded) ya true yani evet yanıyı yolla
            };
        }

        // şimdi ise  işlem başarılıysa ve içinde boş bir değer döndürmek gerekiyorsa sadece içine status code göndermek istiyorum şimdi o meto yapıcaz  Succes metoduna overload yapıcaz  bu tür işlemlerde overload kullanılır (genellikle)

        public static ResponseDTO<T> Success(int statusCode)
        {
            return new ResponseDTO<T>
            {
                Data = default(T), // eğer boş bir değer yollicaksam T tipindeki verinin varsayılan değerini atıcam örnek listeyse list bu dicem int se int dicem 
                StatusCode = statusCode,
                IsSucceded = true
            };
        }

        // şimdi ise  TEK BİR hata mesajına sahip bir hatalı geri bildiriö yapıcaz

        public static ResponseDTO<T> Fail(string error,int statusCode) {

            return new ResponseDTO<T> { 
                Errors = new List<string> { error }, // bunu neden list demeden alamıyorum çünkü propertie yi list olarak tanımlamışım o yüzden
                StatusCode = statusCode,
                IsSucceded = false

            };
        }
        // şimdi ise BİRDEN ÇOK HATA MESAJI döndüren bir fail yazıcaz neden bunu yapıyoruz çünkü bir işlemin eror mesajı birden fazla olabilir bunu da ele almak istiyoruz 
        public static ResponseDTO<T> Fail(List<string> errors,int statusCode)
        {
            return new ResponseDTO<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSucceded = false
            };
        }

        // şimdi burdan mappin metodumuzu yazmaya gidiyoruz peki bu ne işe yaricak :  ben verileri dışardan dto olarak almak ve döndürmek istiyorum fakat databasemizde dto ile veri alıp gönderemiyorum o yüzden tek tek yok yeni nesne oluştur ona bunun içindekileri at dememk için nuget paketlerimizdekii auto mapper için ayrı bir dosya ve içine bu verileri döndüreceğim bir 

    }
}
