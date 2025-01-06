using ECommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.Concrete
{
    public class OrderItem : BaseEntity
    {
        public int OrderId { get; set; } //sipariş Id si
        public Order Order { get; set; } //nav prop
        public int ProductId { get; set; }
        public Product Product { get; set; } //nav prop
        public decimal UnitPrice { get; set; } // ürün adet fiyatı
        public int Quantity { get; set; } // kaç adet
    }
}
