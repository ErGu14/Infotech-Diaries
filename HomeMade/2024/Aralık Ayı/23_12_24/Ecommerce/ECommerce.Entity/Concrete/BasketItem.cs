using ECommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.Concrete
{
    public class BasketItem :BaseEntity
    {
        public int BasketId { get; set; } //hangi sepet
        public Basket Basket { get; set; } //navigation prop
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; } =  1;


    }
}
