using ECommerce.MVC.Abstract;
using ECommerce.MVC.Models;
using ECommerce.MVC.Models.ComplexTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Security.Claims;

namespace ECommerce.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IToastNotification _toaster;
        private readonly IBasketService _basketservice;

        public OrderController(IOrderService orderService, IToastNotification toaster, IBasketService basketservice)
        {
            this.orderService = orderService;
            _toaster = toaster;
            _basketservice = basketservice;
        }
        [Authorize]

        public async Task<IActionResult> Index() // burası kullanıcının kendi siparişlerini görceği yer
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await orderService.GetByUserAsync(userId);
            return View(response);
        }
        [Authorize]
        public async Task<IActionResult> GetOrdersByStatus(OrderStatus id) {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await orderService.GetByStatusAsync(id,userId);
            return View(response);
        }
        [Authorize]
        public  async Task<IActionResult> GetOrdersByDateRange(DateTime start, DateTime end)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await orderService.GetByDateRangeAsync(start,end,userId);
            return View(response);
                
         }
        [Authorize]
        public async Task<IActionResult> Checkout() {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var basket = await _basketservice.GetBasketAsync(userId);
            decimal totalPrice = (decimal)basket.BasketItems.Sum(x => x.Quantity * x.Product.Price);
            return View(totalPrice);

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Checkout(OrderModel orderModel) {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var basket = await _basketservice.GetBasketAsync(userId);
            orderModel.ApplicationUserId = userId;
            orderModel.OrderItems = basket.BasketItems.Select(x => new OrderItemModel {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                UnitPrice = x.Product.Price
            }).ToList();
            orderModel.CreatedDate = DateTime.Now;
            await orderService.AddAsync(orderModel);
            await _basketservice.ClearBasketAsync(userId);
            return View(orderModel);
        }
        public async Task<IActionResult> GetShippedOrders()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await orderService.GetByStatusAsync(OrderStatus.Shipped, userId);
            return View(response);

        }

        public async Task<IActionResult> GetDeliveredOrders()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await orderService.GetByStatusAsync(OrderStatus.Delivered, userId);
            return View(response);

        }
    }
}
