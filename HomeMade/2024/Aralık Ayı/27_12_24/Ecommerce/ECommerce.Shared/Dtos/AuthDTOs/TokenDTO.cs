using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Dtos.AuthDTOs
{
    public class TokenDTO
    {
        public string AccessToken { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
