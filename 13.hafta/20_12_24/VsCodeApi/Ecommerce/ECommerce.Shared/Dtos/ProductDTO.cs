﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Properties { get; set; }
        public Decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<CategoryDTO> Categories { get; set; }

    }
}