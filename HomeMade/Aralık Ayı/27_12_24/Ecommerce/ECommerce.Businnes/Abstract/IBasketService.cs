using ECommerce.Entity.Concrete;
using ECommerce.Shared.Dtos;
using ECommerce.Shared.DTOs;
using ECommerce.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Businnes.Abstract
{
    //Data Transfer Object - DTO   Amaç servisten bir veriyi dto larla dataya yollamak 

    public interface IBasketService
    {
        //DTO Tanımlamaya gidiyoruz


        //sepet işlemleri
        Task<ResponseDTO<BasketDTO>> GetBasketAsync(string appUserId); // user id si örnek 1 olanın sepetini getirme
        Task<ResponseDTO<IEnumerable<BasketDTO>>> GetBasketAsync(); // sistemdeki tüm sepetleri getir

        Task<ResponseDTO<BasketDTO>> CreateBasketDTO(BasketCreateDTO basketCreateDTO); //kullanıcı giriş yaptıktan veya kayıt olduktan sonra ona bir sepet vericez

        Task<ResponseDTO<NoContent>> ClearBasketAsync(string appUserId); // seçili Id li kullanıcının sepetini temizleme işlemi bunu kullanıcı siparişi verdiği anda sepetini temizlemek için kullanıcaz

        // buraya kadar sepet oluşturma sepetleri geitrme işlemleri yaptık şimdi ise sepetteki ürünlere yani Itemlere müdahale edicez

        Task<ResponseDTO<BasketItemDTO>> AddProductFromBasketAsync(BasketItemCreateDTO basketItemCreateDTO); //sepete ürünler kısmından ürün ekleme
        Task<ResponseDTO<NoContent>> RemoveProductFromBasketAsync(int basketItemId); // ben sepetimden BİR ürünü silmek istediğimde ilgili ürünün id sini alıp sepette ekliyse silmek
        Task<ResponseDTO<NoContent>> ChangeProductQuantityAsync(BasketItemChangeQuantityDTO basketItemChangeQuantityDTO); //sepetimdeki ürünün miktarını değiştirme



        // şimdi farkettiysen hepsi senaryoya göre yani sepette neler olabilir tek tek düşünüp işleme alıcaksın tabi daha çok şey de ekleye bilirsin ama senaryona göre tabi hepsi

    }
}
