﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs
{
    public class BasketDTO
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        // sepetteki ürünleri göstermek istiyoruz Yani BasketItemsDTO ları eklicez
        public ApplicationUserDTO ApplicationUser { get; set; }
        public IEnumerable<BasketItemDTO> BasketItems { get; set; } = new List<BasketItemDTO>(); // başlangıçta boş bir sepet ver dicez 

    }
}
