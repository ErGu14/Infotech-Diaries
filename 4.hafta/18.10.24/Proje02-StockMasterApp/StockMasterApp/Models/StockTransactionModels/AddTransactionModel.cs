using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StockMasterApp.Models.StockTransactionModels
{
    internal class AddTransactionModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string? TransactionType { get; set; }
    }
}
