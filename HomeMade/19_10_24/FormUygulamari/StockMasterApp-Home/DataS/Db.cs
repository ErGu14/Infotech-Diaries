using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMasterApp_Home.DataS
{
    internal static class Db
    {
        public static SqlConnection Connect { get; set; } = Create();
        private static SqlConnection Create()
        {
            string query = @"Server=ERAY\SQLEXPRESS;
                                    Database=StockMaster;
                                    User=sa;Password=1234;
                                    TrustServerCertificate=True";
            SqlConnection connection = new SqlConnection(query);
            return connection;
        }
        // aç  / kapa işlemleri
        public static void Open()
        {
            if(Connect.State == ConnectionState.Closed)
            {
                Connect.Open();
            }
        }
        public static void Close()
        {
            if (Connect.State == ConnectionState.Open)
            {
                Connect.Close();
            }
        }
    }
}
