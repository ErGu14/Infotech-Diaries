using ECommerce.Shared.ComplexTypes;
using ECommerce.Shared.DTOs;
using ECommerce.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Businnes.Abstract
{
    public interface IOrderService
    {
        // ilgili sipariş id sine göre sipariş getirme
        Task<ResponseDTO<OrderDTO>> GetOrderAsync(int id);

        // tüm siparişleri getirme
        Task<ResponseDTO<IEnumerable<OrderDTO>>> GetAllOrderAsync();

        // sipariş durumuna göre sipariş getirme
        Task<ResponseDTO<IEnumerable<OrderDTO>>> GetAllOrderAsync(OrderStatus orderStatus);

        // Kullanıcı Id sine göre sipariş getirme
        Task<ResponseDTO<IEnumerable<OrderDTO>>> GetAllOrderAsync(string AppUserId);

        // sipariş oluşturma ve tahmini teslim edilme tarihine göre sipariş getirme
        Task<ResponseDTO<IEnumerable<OrderDTO>>> GetAllOrderAsync(DateTime startTime,DateTime endTime );


        // sipariş oluşturma yani kullanıcı alışverişini tamamlayınca yeni bir sipariş oluşacak
        Task<ResponseDTO<OrderDTO>> CreateOrderAsync(OrderCreateDTO orderCreateDTO);

        //siparişi güncelleme (çok tercih edilmez fakat ufak bir sorun olursa siparişde örnek veriyorum adres değişikliği misali bir sorun olursa burdan yönetilebilisin)
        Task<ResponseDTO<NoContent>> UpdateOrderAsync(OrderUpdateDTO orderUpdateDTO);

        // siparişi silme (sipariş Id sine göre silme işlemi yapacak ben zaten frontende ilgili kodları yazacağım)
        Task<ResponseDTO<NoContent>> DeleteOrderAsync(int id);

        // İlgili siparişin , Sipariş durumunu getirme
        Task<ResponseDTO<string>> GetOrderStatusAsync(int id);

        // ilgili sipraişin , sipariş durumunu DEĞİŞTİRME
        Task<ResponseDTO<NoContent>> UpdateOrderStatusAsync(int orderId,OrderStatus orderStatusı);
    }
}
