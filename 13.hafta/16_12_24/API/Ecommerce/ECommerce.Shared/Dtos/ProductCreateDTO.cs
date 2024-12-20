using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }
        public string Properties { get; set; }
        public Decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int[] CategoryIds { get; set; }

    }
}

/*
 
  {
    name = Iphone 15
    desc = efsane telefon
    price = 50k
    imgurl = iphone15.png
    categoryIds = [4,7,12]   ==>  public int[] CategoryIds { get; set; }
}
 
 */
