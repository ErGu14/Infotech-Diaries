using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.Abstract
{
    public abstract class BaseEntity //ortak özellik olucak (atası olucak)
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow; //global saati default olarak almak
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; } = true;


    }
}
