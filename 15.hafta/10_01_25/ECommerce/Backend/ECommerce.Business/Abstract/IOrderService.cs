using ECommerce.Shared.ComplexTypes;
using ECommerce.Shared.DTOs;
using ECommerce.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IOrderService
    {
        Task<ResponseDTO<OrderDTO>> GetOrderAsync(int id);
        Task<ResponseDTO<IEnumerable<OrderDTO>>> GetOrdersAsync();
        Task<ResponseDTO<IEnumerable<OrderDTO>>> GetOrdersAsync(OrderStatus orderStatus);
        Task<ResponseDTO<IEnumerable<OrderDTO>>> GetOrdersAsync(string applicationUserId);
        Task<ResponseDTO<IEnumerable<OrderDTO>>> GetOrdersAsync(DateTime startDate, DateTime endDate);
        Task<ResponseDTO<OrderDTO>> CreateOrderAsync(OrderCreateDTO orderCreateDTO);
        Task<ResponseDTO<NoContent>> UpdateOrderAsync(OrderUpdateDTO orderUpdateDTO);
        Task<ResponseDTO<NoContent>> DeleteOrderAsync(int id);
        Task<ResponseDTO<string>> GetOrderStatusAsync(int id);
        Task<ResponseDTO<NoContent>> UpdateOrderStatusAsync(int orderId, OrderStatus orderStatus);

    }
}
