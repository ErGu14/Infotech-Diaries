using Exam.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Entity.Concrete
{
    public class Order :BaseEntity
    {
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
