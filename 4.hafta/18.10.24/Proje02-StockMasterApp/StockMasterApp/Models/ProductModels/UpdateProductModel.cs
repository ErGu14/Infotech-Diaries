using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMasterApp.Models.ProductModels
{
    internal class UpdateProductModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public bool Discounted { get; set; }
        public int ReorderLevel { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}
