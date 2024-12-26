using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Businnes.Abstract
{
    public interface IRoleSevice
    {
        Task SeedRolesAsync(); //başlangıçta rol bilgilerini gir
    }
}
