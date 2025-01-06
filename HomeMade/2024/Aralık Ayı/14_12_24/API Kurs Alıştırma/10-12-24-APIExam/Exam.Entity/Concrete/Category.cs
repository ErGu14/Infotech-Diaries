using Exam.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Entity.Concrete
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; } =new HashSet<ProductCategory>();
    }
}
