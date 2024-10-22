using Microsoft.Data.SqlClient;
using StockMasterApp.Models.StockTransactionModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMasterApp.Data.Dal
{
    internal class StockTransactionDal
    {
        public bool AddTransaction(AddStockTransactionModel model)
        {
            string spName = model.TransactionType == "IN" ? "ProductIn" : "ProductExit";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(spName, Db.Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@productId", model.ProductId);
            sqlCommand.Parameters.AddWithValue("@quantity", model.Quantity);
            var result = sqlCommand.ExecuteScalar();
            return (int)result == 1;
        }
    }
}
