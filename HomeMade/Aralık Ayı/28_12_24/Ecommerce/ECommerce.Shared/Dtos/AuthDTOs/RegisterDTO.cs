using ECommerce.Shared.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Dtos.AuthDTOs
{
    public class RegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public GenderType Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string Role { get; set; } = "User"; // kullanıcı kayıt olurken varsayılan olarak user rolünü alıcak dedik
    }
}
