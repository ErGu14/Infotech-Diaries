using ECommerce.Businnes.Abstract;
using ECommerce.Shared.DTOs;
using ECommerce.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productService.GetAllAsync();
            return CreateResponse(response);
        }
        [HttpGet("{isActive}")]
        public async Task<IActionResult> GetAll(bool isActive)
        {
            var response = await _productService.GetAllAsync(isActive);
            return CreateResponse(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _productService.GetAsync(id);
            return CreateResponse(response);
        }
        [HttpGet("withcategories")]
        public async Task<IActionResult> GetWithCategories()
        {
            var response = await _productService.GetAllWithCategoriesAsync();
            return CreateResponse(response);
        }
        [HttpGet("bycategory/{id}")]
        public async Task<IActionResult> GetByCategory(int id)
        {
            var response = await _productService.GetByCategoryAsync(id);
            return CreateResponse(response);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductCreateDTO productCreateDTO)
        {
            var response = await _productService.AddAsync(productCreateDTO);
            return CreateResponse(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDTO productUpdate)
        {
            var response = await _productService.UpdateAsync(productUpdate);
            return CreateResponse(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _productService.DeleteAsync(id);
            return CreateResponse(response);
        }
        [HttpGet("count")]
        public async Task<IActionResult> Count()
        {
            var response = await _productService.GetCountAsync();
            return CreateResponse(response);
        }
        [HttpGet("count/{isActive}")]
        public async Task<IActionResult> Count(bool isActive)
        {
            var response = await _productService.GetCountAsync(isActive);
            return CreateResponse(response);
        }
        [HttpGet("countbycategory/{categoryId}")]
        public async Task<IActionResult> CountByCategory(int categoryId)
        {
            var response = await _productService.GetCountByCategoryAsync(categoryId);
            return CreateResponse(response);
        }
        [HttpGet("updateisactive/{id}")]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            var response = await _productService.UpdateIsActiveAsync(id);
            return CreateResponse(response);
        }


    }
}
