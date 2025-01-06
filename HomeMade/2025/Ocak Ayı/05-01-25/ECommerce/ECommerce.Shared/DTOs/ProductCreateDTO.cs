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
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int[] CategoryIds { get; set; }
    }
}

/*
    {
        name: 'Iphone 15',
        properties: 'Harika bir telefon',
        price:50000,
        imageUrl:'iphone15.png',
        categoryIds:[4,7,12]
*/

/*
 * Yeni Product'ın Id değeri : 13
 13-4
13-7
13-12
*/