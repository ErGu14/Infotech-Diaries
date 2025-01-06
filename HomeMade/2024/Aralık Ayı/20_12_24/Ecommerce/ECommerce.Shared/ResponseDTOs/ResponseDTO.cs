using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerce.Shared.ResponseDTOs
{
    public class ResponseDTO<T> // amacımız kullanıcıya cevapları döndürmek yani hata varsa hata mesajı başarılımı değilmi veya başarılıysa bilgileri döndürücez
    {
        public T? Data { get; set; }
        public List<string> Errors { get; set; } // hata birden fazlaysa diye listeye aldık

        [JsonIgnore]
        public bool IsSucceded { get; set; }
        [JsonIgnore] // ben bunu uygulamam içerisinde kullanıcam ama dışarıya cevap yollarken bunları kullanmicam bunları es geç
        public int StatusCode { get; set; } // cevap olarak 404 202 vb gibi cevapları döndürmek


        //Geriye veri döndüren başarılı cevap
        public static ResponseDTO<T> Success(T data,int statusCode)
        {
            return new ResponseDTO<T> { Data = data, 
                                        StatusCode = statusCode,
                                        IsSucceded = true
            }; // başarılıysa bunu yolla dicez

        }

        // geriye veri döndürmeyen başarılı cevap

        public static ResponseDTO<T> Success(int statusCode)
        {
            return new ResponseDTO<T> { Data = default(T),
                                        StatusCode = statusCode,
                                        IsSucceded = true
            };
        }

        //Tek Hata dödüren başarısız cevap
        public static ResponseDTO<T> Fail(string error,int statusCode)
        {
            return new ResponseDTO<T> { 
                                        Errors = new List<string> { error },
                                        StatusCode = statusCode,
                                        IsSucceded = false
            
            };
        }

        // Birden fazla hata döndüren başarısız cevap

        public static ResponseDTO<T> Fail(List<string> errors, int statusCode)
        {
            return new ResponseDTO<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSucceded = false

            };
        }
    }
}
