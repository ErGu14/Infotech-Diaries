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
    public class BasketsController : CustomControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [Authorize]
        [HttpPost("addtobasket")]
        public async Task<IActionResult> AddProductToBasket(BasketItemCreateDTO basketItemCreateDTO)
        {
            var response = await _basketService.AddProductToBasketAsync(basketItemCreateDTO);
            return CreateResponse(response);
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("createbasket")]
        public async Task<IActionResult> CreateBasket(BasketCreateDTO basketCreateDTO)
        {
            var response = await _basketService.CreateBasketAsync(basketCreateDTO);
            return CreateResponse(response);
        }


        [Authorize(Roles ="Admin, User")]
        [HttpPost("removefrombasket/{basketItemId}")]
        public async Task<IActionResult> RemoveProductFromBasket(int basketItemId)
        {
            var response = await _basketService.RemoveProductFromBasketAsync(basketItemId);
            return CreateResponse(response);
        }

        [Authorize]
        [HttpPost("clearbasket/{applicationUserId}")]
        public async Task<IActionResult> ClearBasket(string applicationUserId)
        {
            var response = await _basketService.ClearBasketAsync(applicationUserId);
            return CreateResponse(response);
        }

        [Authorize]
        [HttpGet("{applicationUserId}")]
        public async Task<IActionResult> GetBasket(string applicationUserId)
        {
            var response = await _basketService.GetBasketAsync(applicationUserId);
            return CreateResponse(response);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> ChangeQuantity(BasketItemChangeQuantityDTO basketItemChangeQuantityDTO)
        {
            var response = await _basketService.ChangeProductQuantityAsync(basketItemChangeQuantityDTO);
            return CreateResponse(response);
        }
    }
}
