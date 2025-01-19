using ECommerce.Business.Abstract;
using ECommerce.Shared.DTOs;
using ECommerce.Shared.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDTO productCreateDTO)
        {
            var response = await _productService.AddAsync(productCreateDTO);
            return CreateResponse(response);
        }

        [Authorize(Roles = "Admin")]
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


        [HttpGet("withcategories")]
        public async Task<IActionResult> GetAllWithCategories()
        {
            var response = await _productService.GetAllWithCategoriesAsync();
            return CreateResponse(response);
        }


        [HttpGet("bycategory/{categoryId}")]
        public async Task<IActionResult> GetAllByCategory(int categoryId)
        {
            var response = await _productService.GetByCategoryAsync(categoryId);
            return CreateResponse(response);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _productService.GetAsync(id);
            return CreateResponse(response);
        }


        [HttpGet("getwithcategories/{id}")]
        public async Task<IActionResult> GetByIdWithCategories(int id)
        {
            var response = await _productService.GetWithCategoriesAsync(id);
            return CreateResponse(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("count")]
        public async Task<IActionResult> GetCount()
        {
            var response = await _productService.GetCountAsync();
            return CreateResponse(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("count/{isActive}")]
        public async Task<IActionResult> GetCount(bool isActive)
        {
            var response = await _productService.GetCountAsync(isActive);
            return CreateResponse(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("countbycategory/{categoryId}")]
        public async Task<IActionResult> GetCount(int categoryId)
        {
            var response = await _productService.GetCountByCategory(categoryId);
            return CreateResponse(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateDTO productUpdateDTO)
        {
            var response = await _productService.UpdateAsync(productUpdateDTO);
            return CreateResponse(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("updateisactive/{id}")]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            var response = await _productService.UpdateIsActiveAsync(id);
            return CreateResponse(response);
        }

        [HttpGet("homeproducts/{take}")]
        public async Task<IActionResult> GetAll(int take)
        {
            var response = await _productService.GetAllAsync(true, take);
            return CreateResponse(response);
        }

    }
}
