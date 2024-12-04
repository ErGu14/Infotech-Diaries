using Microsoft.EntityFrameworkCore;
using PortfolioApp.Areas.Admin.Models;
using PortfolioApp.Models.Entities;

namespace PortfolioApp.Models.Repositories
{
    // categories tablosunda yapılacak tüm işlemler burda yapılacak(kategori ekleme silme vb işler) form uygulamalarındaki gibi
    public class CategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetAllAsync()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            // select * from categories
            
            return categories;
        }
        public async Task<List<Category>> GetAllAsync(bool isDeleted) // lise döndürülceği zaman return edilir
        {
            List<Category> categories = await _context
                .Categories
                .Where(c=> c.IsDeleted==isDeleted)
                .ToListAsync();
            //select * from categories where isdeleted=1
            return categories;
        }


        public async Task<Category?> GetByIdAsync(int id,bool isDeleted)
        {
            Category? category = await _context
                .Categories
                .Where(c => c.IsDeleted==isDeleted && c.Id ==id)
                .FirstOrDefaultAsync();
            return category;
        }
        public async Task<Category> GetByIdAsync(int id)
        {
            Category? category = await _context.Categories.FindAsync(id);
            return category;
        }
        public async Task CreateAsync(AddCategoryViewModel addCategoryViewModel) // yap geç mantığı uygulanacağından return kullanılmaz
        {
            Category category = new()
            {
               Name = addCategoryViewModel.Name,
               Description = addCategoryViewModel.Description
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(UpdateCategoryViewModel updateCategoryViewModel)
        {
            Category? updatedCategory= await GetByIdAsync(updateCategoryViewModel.Id);
            updatedCategory.Name = updateCategoryViewModel.Name;
            updatedCategory.Description = updateCategoryViewModel.Description;
            updatedCategory.UpdatedAt = DateTime.Now;
            _context.Update(updatedCategory);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            Category? category = await GetByIdAsync(id);
            category.IsDeleted = !category.IsDeleted;
            _context.Update(category);
            await _context.SaveChangesAsync();

        }
        public async Task HardDeleteAsync(int id)
        {
            Category? category = await GetByIdAsync(id);
            _context.Remove(category);
            await _context.SaveChangesAsync();

        }

    }
}
