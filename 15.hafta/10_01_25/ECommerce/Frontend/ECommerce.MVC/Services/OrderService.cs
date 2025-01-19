using ECommerce.MVC.Abstract;
using ECommerce.MVC.Models;
using ECommerce.MVC.Models.ComplexTypes;
using System.Text.Json;

namespace ECommerce.MVC.Services
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor)
        {
        }

        public async Task AddAsync(OrderModel orderModel)
        {
            var client = GetHttpClient();
            var response = await client.PostAsJsonAsync("orders",orderModel);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<OrderModel>(jsonString,_jsonSerializerOptions);
            // if diyerek hata varsa hata döndür bu kadar
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderModel> GetAsync(int id)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"orders/{id}");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ResponseModel<OrderModel>>(jsonString, _jsonSerializerOptions);
            //ifle hata kontrolü
            return result.Data;
        }

        public async Task<IEnumerable<OrderModel>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, string userId)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"orders/daterange?startdate={startDate:yyyy-mm-dd}&enddate={endDate:yyyy-mm-dd}");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ResponseModel<IEnumerable<OrderModel>>>(jsonString, _jsonSerializerOptions);
            //ifle hata kontrolü

            var orders = result.Data;
            IEnumerable<OrderModel> ordersOfUser = orders.Where(x => x.ApplicationUserId == userId ).ToList();
            return ordersOfUser;
        }

        public async Task<IEnumerable<OrderModel>> GetByStatusAsync(OrderStatus status, string? userId = null)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"orders/user/{userId}");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ResponseModel<IEnumerable<OrderModel>>>(jsonString, _jsonSerializerOptions);
            //ifle hata kontrolü
            var ordersOfUser = result.Data;
            IEnumerable<OrderModel> ordersOfUserByStatus = ordersOfUser.Where(x => x.OrderStatus == status).ToList();
            return ordersOfUserByStatus;
        }

        public async Task<IEnumerable<OrderModel>> GetByUserAsync(string userId)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"orders/user/{userId}");
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ResponseModel<IEnumerable<OrderModel>>>(jsonString, _jsonSerializerOptions);
            //ifle hata kontrolü
            
            return result.Data;
        }

        public Task UpdateAsync(OrderModel orderModel)
        {
            throw new NotImplementedException();
        }
    }
}
