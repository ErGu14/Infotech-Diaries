using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs
{
    public class OrderUpdateDTO
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
        public decimal TotalAmount => OrderItems.Sum(x => x.UnitPrice * x.Quantity); // toplam tutar oluştur türü decimal olucak Sum metoduyla order Itemlara işlem yapıcam diyorum sonra içine x lambda diyerek fonksiyonlarımı yazıyorum   sipariş ürünlerinin birim fiyatıylar    sipraiş ürünlerinin adet bilgisini çarpıyorum ve toplam fiyatı buluyorum
    }
}
