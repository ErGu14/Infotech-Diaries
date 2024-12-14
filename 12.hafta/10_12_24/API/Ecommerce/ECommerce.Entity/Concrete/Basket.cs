using ECommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.Concrete
{
    public class Basket :BaseEntity
    {
        public string UserId { get; set; } // hangi kullanıcının sepeti olduğunu bilmemiz için çoka çok gibi bir ilişki veya benzeri bil ilişki kurmamız gerek yok

    }
}
