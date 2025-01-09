using ECommerce.MVC.Models;

namespace ECommerce.MVC.Abstract
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetCategoriesAsync();
        Task<IEnumerable<CategoryModel>> GetActiveCategoriesAsync();
        Task<IEnumerable<CategoryModel>> GetPassiveCategoriesAsync();

        Task<CategoryModel> GetCategoryAsynx(int id);
        Task<int> GetCategoryCountAsynx();

        Task<CategoryModel> AddCategoryAsync(CategoryModel categoryModel);
        Task UpdateCategoryAsync(CategoryModel categoryModel);
        Task DeleteCategoryAsync(int id);


    }
}
