using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Shared.DTOs
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }
        public string Properties { get; set; }
        public decimal Price { get; set; }
        public int[] CategoryIds { get; set; } = [];
        public IFormFile Image { get; set; }
    }
}
