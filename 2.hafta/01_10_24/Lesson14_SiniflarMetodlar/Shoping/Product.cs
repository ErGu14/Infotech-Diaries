using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson14_SiniflarMetodlar.Shoping
{
    internal class Product
    {
        public Product()
        {
            
        }
       public Product(int id)
        {
            Id = id;
        }
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }

        public int? CategoryId { get; set; } = 1;

    }
}
