using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Dtos
{
    public class BasketItemRemoveDTO
    {
        public int BasketId { get; set; } // hangi sepet olacağı
        public int ProductId { get; set; } //hangi sepetteki ÜRÜNÜN silineceği

    }
}
