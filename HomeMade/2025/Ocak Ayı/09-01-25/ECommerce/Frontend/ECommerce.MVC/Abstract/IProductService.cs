using ECommerce.MVC.Models;

namespace ECommerce.MVC.Abstract
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllAsync();
        Task<IEnumerable<ProductModel>> GetAllActiveAsync();
        Task<IEnumerable<ProductModel>> GetAllPassiveAsync();
        Task<IEnumerable<ProductModel>> GetAllByCategoryAsync(int categoryId);
        Task<ProductModel> GetAsync(int id);
        Task<int> CountAsync();
        Task<int> CountByCategoryAsync(int categoryId);
        Task<ProductModel> AddAsync(ProductModel product);
        Task UpdateAsync(ProductModel product);
        Task DeleteAsync(int id);


    }
}
