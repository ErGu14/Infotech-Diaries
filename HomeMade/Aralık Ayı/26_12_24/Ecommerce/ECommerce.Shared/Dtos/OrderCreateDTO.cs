using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs
{
    public class OrderCreateDTO
    {
        public string ApplicationUserId { get; set; }
        public int MyProperty { get; set; }
        public IEnumerable<OrderItemCreateDTO> orderItemCreates { get; set; }

    }
}
