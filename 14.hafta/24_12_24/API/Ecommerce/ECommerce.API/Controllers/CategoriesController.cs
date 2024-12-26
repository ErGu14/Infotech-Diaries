using ECommerce.Businnes.Abstract;
using ECommerce.Shared.DTOs;
using ECommerce.Shared.Helpers;
using ECommerce.Shared.ResponseDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDTO categoryCreateDTO) //dışardan gelecek isteiğin bana bir T bilgisi gerekli
        {
            var response = await _categoryService.AddAsync(categoryCreateDTO);
            return CreateResponse<CategoryDTO>(response);
           

        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryService.GetAllAsync();
            return CreateResponse(response);
        }
        // site/api/categories/getall/Parametre 
        [HttpGet("getall/{isActive?}")]
        public async Task<IActionResult> GetAll(bool? isActive = null)
        {

            var response = isActive == null ? await _categoryService.GetAllAsync() : await _categoryService.GetAllAsync(isActive); // eğer null ise parametresiz şekilde getAll yap eğer parametre alırsa true veya false o zaman parametreye göre getir
            return CreateResponse(response);
        }
        // site/api/categories/Parametre 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _categoryService.GetAsync(id);
            return CreateResponse(response);
        }
        [HttpGet("count/{isActive?}")]
        public async Task<IActionResult> Count(bool? isActive)
        {
            var response = isActive == null ? await _categoryService.CountAsync() : await _categoryService.CountAsync(isActive);
            return CreateResponse(response);

        }
        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateDTO categoryUpdateDTO)
        {
            var response = await _categoryService.UpdateAsync(categoryUpdateDTO);
            return CreateResponse(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _categoryService.DeleteAsync(id);
            return CreateResponse(response);
        }
        [HttpGet("updateisactive/{id}")]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            var response = await _categoryService.UpdateIsActiveAsync(id);
            return CreateResponse(response);
        }


    }
}
