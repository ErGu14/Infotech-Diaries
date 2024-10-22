using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson18_Miras_Inheritance.Eshop
{
    // product sınıfı commonProperties sınıfındna miras almış.
    // Product sınıfı CommonProperties sınıfından türetilmiştir.
    //CommonProperties sınıfı tüm özellik ve sınıfları (public) Product sınıfına devretmiştir.
    internal class Product : CommonProperties
    {
        public decimal Price { get; set; }
        public decimal TaxRate { get; set; }
        public string Properties { get; set; }
        public string ImageUrl { get; set; }
        public int BrandId { get; set; }
    }
}
