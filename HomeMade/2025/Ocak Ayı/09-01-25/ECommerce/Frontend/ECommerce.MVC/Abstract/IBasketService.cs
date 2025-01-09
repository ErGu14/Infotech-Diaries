using ECommerce.MVC.Models;

namespace ECommerce.MVC.Abstract
{
    public interface IBasketService
    {
        Task<BasketModel> GetBasketAsync(string applicationUserId);
        Task AddToBasketAsync(BasketItemModel basketItemModel);
        Task RemoveFromBasketAsync(int basketItemId);
        Task<bool> ClearBasketAsync(string applicationUserId);
        Task<bool> ChangeQuantityAsync(int basketItemId, int quantity);
        Task<bool> CreateBasketAsync(BasketModel basketModel);
    }
}
