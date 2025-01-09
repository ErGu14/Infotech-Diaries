using ECommerce.Business.Abstract;
using ECommerce.Shared.ComplexTypes;
using ECommerce.Shared.DTOs;
using ECommerce.Shared.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : CustomControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var response = await _orderService.GetOrderAsync(id);
            return CreateResponse(response);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var response = await _orderService.GetOrdersAsync();
            return CreateResponse(response);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDTO orderCreateDTO)
        {
            var response = await _orderService.CreateOrderAsync(orderCreateDTO);
            return CreateResponse(response);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var response = await _orderService.DeleteOrderAsync(id);
            return CreateResponse(response);
        }

        [Authorize]
        [HttpPut("{orderId}")]
        public async Task<IActionResult> UpdateOrdersStatus(int orderId, [FromBody] OrderStatus status)
        {
            var response = await _orderService.UpdateOrderStatusAsync(orderId, status);
            return CreateResponse(response);
        }

        [Authorize]
        [HttpGet("daterange")]
        public async Task<IActionResult> GetOrdersByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var response = await _orderService.GetOrdersAsync(startDate, endDate);
            return CreateResponse(response);
        }

        [Authorize]
        [HttpGet("status")]
        public async Task<IActionResult> GetOrdersByStatus([FromQuery] OrderStatus orderStatus)
        {
            var response = await _orderService.GetOrdersAsync(orderStatus);
            return CreateResponse(response);
        }

        [Authorize]
        [HttpGet("user/{applicationUserId}")]
        public async Task<IActionResult> GetOrdersByUser(string applicationUserId)
        {
            var response = await _orderService.GetOrdersAsync(applicationUserId);
            return CreateResponse(response);
        }
    }
}
