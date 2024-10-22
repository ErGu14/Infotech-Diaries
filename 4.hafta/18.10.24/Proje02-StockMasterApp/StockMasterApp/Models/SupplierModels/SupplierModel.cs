using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMasterApp.Models.SupplierModels
{
    internal class SupplierModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ContactName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
