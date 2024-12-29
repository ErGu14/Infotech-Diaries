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
        public string ApplicationUserId { get; set; } // hangi kullanıcının sepeti olduğunu bilmemiz için çoka çok gibi bir ilişki veya benzeri bil ilişki kurmamız gerek yok
        public ApplicationUser ApplicationUser { get; set; }
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>(); //başlangıça boş bir basket ıtems ver diyorum

    }
}
