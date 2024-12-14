using ECommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.Concrete
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
