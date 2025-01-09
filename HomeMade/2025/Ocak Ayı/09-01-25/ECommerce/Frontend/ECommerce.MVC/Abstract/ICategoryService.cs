using ECommerce.MVC.Models;

namespace ECommerce.MVC.Abstract
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetCategoriesAsync();
        Task<IEnumerable<CategoryModel>> GetActiveCategoriesAsync();
        Task<IEnumerable<CategoryModel>> GetPassiveCategoriesAsync();
        Task<CategoryModel> GetCategoryAsync(int id);
        Task<int> GetCategoryCountAsync();
        Task<CategoryModel> AddCategoryAsync(CategoryModel category);
        Task UpdateCategoryAsync(CategoryModel category);
        Task DeleteCategoryAsync(int id);

    }
}
