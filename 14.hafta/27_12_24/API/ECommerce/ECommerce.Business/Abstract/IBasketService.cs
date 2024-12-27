using ECommerce.Shared.DTOs;
using ECommerce.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    //Data Transfer Object - DTO
    public interface IBasketService
    {
        Task<ResponseDTO<BasketDTO>> GetBasketAsync(string applicationUserId); // kullanıcıya ait 1 sepet getirme
        Task<ResponseDTO<IEnumerable<BasketDTO>>> GetBasketsAsync(); // tüm sepetleri getirme amaçok ihtiyaç yok yani nadir durumlarda olabilir

        Task<ResponseDTO<BasketDTO>> CreateBasketAsync(BasketCreateDTO basketCreateDTO); //kullanıcı kayıt olduktan sonra ona bir sepet oluşturma

        Task<ResponseDTO<NoContent>> ClearBasketAsync(string applicationUserId); //siparişi tamamla dediği anda basket tableyi silicez ama gerekli yerini

        Task<ResponseDTO<BasketItemDTO>> AddProductToBasketAsync(BasketItemCreateDTO basketItemCreateDTO); // sepete ürün ekleme
        Task<ResponseDTO<NoContent>> RemoveProductFromBasketAsync(int basketItemId); //sepetten ürünü kaldırma

        Task<ResponseDTO<NoContent>> ChangeProductQuantityAsync(BasketItemChangeQuantityDTO basketItemChangeQuantityDTO); //sepetteki ürün miktarını değiştirme


    }
}
