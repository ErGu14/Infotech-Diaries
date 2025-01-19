using ECommerce.MVC.Models;
using ECommerce.MVC.Models.ComplexTypes;

namespace ECommerce.MVC.Abstract
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderModel>> GetByUserAsync(string userId); // ilgili kullanıcı siparişleri

        Task<OrderModel> GetAsync(int id);

        Task AddAsync(OrderModel orderModel);

        Task DeleteAsync(int id);

        Task UpdateAsync(OrderModel orderModel);

        Task<IEnumerable<OrderModel>> GetByStatusAsync(OrderStatus status,string? userId = null);
        Task<IEnumerable<OrderModel>> GetByDateRangeAsync(DateTime startDate,DateTime endDate,string userId);
    }
}
