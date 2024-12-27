using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs
{
    // kullanıcı kayıt olurken sepet oluşturma
    public class BasketCreateDTO
    {
        public string ApplictionUserId { get; set; } // kullanıcı kayıt olduğunda veya giriş yaptığında direkt sepet oluştur dicez

    }
}
