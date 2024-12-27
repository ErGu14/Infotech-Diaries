using ECommerce.Shared.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUserDTO ApplicationUser { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; } //siparişteki ürünler
        public OrderStatus OrderStatus { get; set; } //SİPARİŞ DURUMU
        public DateTime CreatedDate { get; set; } //sipariş oluşma tarihi

        public decimal TotalAmount => OrderItems.Sum(item => item.UnitPrice * item.Quantity); //sipariş oluşacağından dolayı item bilgisi değiştiği anda işleme koysun diğerlerinde yapmama sebebim onlara sadece siparişi güncellicem ne bileyim status bilgisini vs


    }
}
