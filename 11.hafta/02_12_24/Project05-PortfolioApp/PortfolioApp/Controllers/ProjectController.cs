using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Models.Repositories;

namespace PortfolioApp.Controllers
{
    public class ProjectController : Controller
    {
      private readonly CategoryRepository _categoryRepository; //field
        public ProjectController(CategoryRepository categoryRepository) //ctor
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<ActionResult> Index()
        {
            var categories = await _categoryRepository.GetAllAsync(false);
            return View();
        }

    }
}
