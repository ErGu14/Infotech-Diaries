using ECommerce.MVC.Models;

namespace ECommerce.MVC.Abstract
{
    public interface IProductService
    {

        Task<IEnumerable<ProductModel>> GetAllAsync();
        Task<IEnumerable<ProductModel>> GetAllActiveAsync();
        Task<IEnumerable<ProductModel>> GetAllPassiveAsync();
        Task<IEnumerable<ProductModel>> GetAllByCategoriesAsync(int categoryId);
        Task<ProductModel> GetAsync(int id);
        Task<int> CountAsync(int id);
        Task<int> CountByCategoryAsync(int id);

        Task<ProductModel> AddAsync();
        Task UpdateAsync(ProductModel productModel);
        Task DeleteAsync(int id);

    }
}
