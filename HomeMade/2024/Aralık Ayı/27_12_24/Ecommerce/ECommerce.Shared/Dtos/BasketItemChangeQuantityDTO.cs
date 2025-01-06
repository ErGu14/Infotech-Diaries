using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Dtos
{
    public class BasketItemChangeQuantityDTO
    {
        public int BasketItemId { get; set; } //sepetteki ürün Id si
        public int Quantity { get; set; } // azalttığım zaman azalsın arttırınca artsın diye mikta bilgisi alıyoz
    }
}
