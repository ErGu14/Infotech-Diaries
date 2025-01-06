using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMasterApp_Home.Models.StockTransactionModels
{
    internal class StockTransactionModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string TransactionType { get; set; }
        public int Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
