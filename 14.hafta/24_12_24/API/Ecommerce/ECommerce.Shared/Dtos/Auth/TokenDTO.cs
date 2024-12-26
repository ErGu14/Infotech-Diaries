using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Dtos.Auth
{
    public class TokenDTO
    {
        public string AccessToken { get; set; } //JWT
        public DateTime ExpirationDate { get; set; } //jwt ömrü
    }
}
