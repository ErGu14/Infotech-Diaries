using ECommerce.Businnes.Abstract;
using ECommerce.Businnes.Concrete;
using ECommerce.Shared.Dtos;
using ECommerce.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : CustomControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookCreateDTO bookCreateDTO)
        {
            var response = await _bookService.AddAsync(bookCreateDTO);
            return CreateResponse(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _bookService.GetAllAsync();
            return CreateResponse(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _bookService.GetAsync(id);
            return CreateResponse(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _bookService.DeleteAsync(id);
            return CreateResponse(response);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateAsync(BookUpdateDTO bookUpdateDTO)
        {
            var response = await _bookService.UpdateAsync(bookUpdateDTO);
            return CreateResponse(response);
        }
        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
        {
            var response = await _bookService.CountAsync();
            return CreateResponse(response);

        }
    }
}
