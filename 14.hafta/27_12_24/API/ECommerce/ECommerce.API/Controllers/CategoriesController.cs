using ECommerce.Business.Abstract;
using ECommerce.Shared.DTOs;
using ECommerce.Shared.Helpers;
using ECommerce.Shared.ResponseDTOs;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles ="Admin")] // cretae işlemini sadece admin yetkisine sahip kişi yapabilir dedik
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDTO categoryCreateDTO)
        {
            var response = await _categoryService.AddAsync(categoryCreateDTO);
            return CreateResponse(response);
        }

        //site/api/categories/getall/true
        [HttpGet("getall/{isActive?}")]
        
        public async Task<IActionResult> GetAll(bool? isActive=null)
        {
            var response = isActive==null 
                                ? await _categoryService.GetAllAsync()
                                : await _categoryService.GetAllAsync(isActive);
            return CreateResponse(response);
        }

        //site/api/categories/4
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _categoryService.GetAsync(id);
            return CreateResponse(response);
        }

        [Authorize(Roles ="Admin")]
        [HttpGet("count/{isActive?}")]
        public async Task<IActionResult> Count(bool? isActive)
        {
            var response = isActive==null
                            ? await _categoryService.CountAsync()
                            : await _categoryService.CountAsync(isActive);
            return CreateResponse(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateDTO categoryUpdateDTO)
        {
            var response = await _categoryService.UpdateAsync(categoryUpdateDTO);
            return CreateResponse(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _categoryService.DeleteAsync(id);
            return CreateResponse(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("updateisactive/{id}")]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            var response = await _categoryService.UpdateIsActiveAsync(id);
            return CreateResponse(response);
        }
    }
}
