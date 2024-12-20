﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Dtos
{
    public class BookUpdateDTO
    {
        public int Id { get; set; }
        public string PublishingHouse { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
    }
}
