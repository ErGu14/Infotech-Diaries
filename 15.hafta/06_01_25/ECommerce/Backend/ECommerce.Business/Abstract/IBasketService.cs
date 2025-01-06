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
        Task<ResponseDTO<BasketDTO>> GetBasketAsync(string applicationUserId);
        Task<ResponseDTO<IEnumerable<BasketDTO>>> GetBasketsAsync();
        Task<ResponseDTO<BasketDTO>> CreateBasketAsync(BasketCreateDTO basketCreateDTO); 
        Task<ResponseDTO<NoContent>> ClearBasketAsync(string applicationUserId);
        Task<ResponseDTO<BasketItemDTO>> AddProductToBasketAsync(BasketItemCreateDTO basketItemCreateDTO);
        Task<ResponseDTO<NoContent>> RemoveProductFromBasketAsync(int basketItemId);
        Task<ResponseDTO<NoContent>> ChangeProductQuantityAsync(BasketItemChangeQuantityDTO basketItemChangeQuantityDTO);

    }
}
