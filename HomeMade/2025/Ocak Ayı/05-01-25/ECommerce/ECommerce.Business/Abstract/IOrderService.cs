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
        Task<ResponseDTO<OrderDTO>> GetOrderAsync(int id); //ilgili siparişi geitir
        Task<ResponseDTO<IEnumerable<OrderDTO>>> GetOrdersAsync(); //tüm siparişleri getir
        Task<ResponseDTO<IEnumerable<OrderDTO>>> GetOrdersAsync(OrderStatus orderStatus); //  siparişlerin durumlarını getir
        Task<ResponseDTO<IEnumerable<OrderDTO>>> GetOrdersAsync(string applicationUserId); //ilgili kullanıcının tüm siparişlerini getir
        Task<ResponseDTO<IEnumerable<OrderDTO>>> GetOrdersAsync(DateTime startDate, DateTime endDate); //tarihe göre sıralama yap
        Task<ResponseDTO<OrderDTO>> CreateOrderAsync(OrderCreateDTO orderCreateDTO); // sipariş oluştur
        Task<ResponseDTO<NoContent>> UpdateOrderAsync(OrderUpdateDTO orderUpdateDTO); // oluşan siparişi güncelle (.ok spesifik bir durum ama yinede ufak bir detay olduğu için ekledik)
        Task<ResponseDTO<NoContent>> DeleteOrderAsync(int id); // ilgili siparişi silme
        Task<ResponseDTO<string>> GetOrderStatusAsync(int id); //ilgili siparişin durumunu güncelleme
        Task<ResponseDTO<NoContent>> UpdateOrderStatusAsync(int orderId, OrderStatus orderStatus); //ilgili siparişin durumunu değiştirme

    }
}
