using ECommerce.Shared.DTOs;
using ECommerce.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IBasketService
    {
        Task<ResponseDTO<BasketDTO>> GetBasketAsync(string applicationUserId); // kullanıcıya göre sepet
        Task<ResponseDTO<IEnumerable<BasketDTO>>> GetBasketsAsync(); // tüm sepetler
        Task<ResponseDTO<BasketDTO>> CreateBasketAsync(BasketCreateDTO basketCreateDTO);  // kayıt olduğunda sepet oluşturma
        Task<ResponseDTO<NoContent>> ClearBasketAsync(string applicationUserId); //  kullanıcının sepetini temizlemesi
        Task<ResponseDTO<BasketItemDTO>> AddProductToBasketAsync(BasketItemCreateDTO basketItemCreateDTO); //sepete ürün ekleme
        Task<ResponseDTO<NoContent>> RemoveProductFromBasketAsync(int basketItemId); // seçili ürünü sepetten kaldırma
        Task<ResponseDTO<NoContent>> ChangeProductQuantityAsync(BasketItemChangeQuantityDTO basketItemChangeQuantityDTO); // ürün miktarını değiştirme
    }
}
