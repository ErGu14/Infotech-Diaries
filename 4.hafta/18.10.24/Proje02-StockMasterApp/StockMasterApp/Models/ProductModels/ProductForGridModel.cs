using StockMasterApp.Models.CategoryModels;
using StockMasterApp.Models.SupplierModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMasterApp.Models.ProductModels
{
    internal class ProductForGridModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public string? Category { get; set; }
        public int SupplierId { get; set; }
        public string? Supplier { get; set; }
        public int Reorder { get; set; }
    }
}
