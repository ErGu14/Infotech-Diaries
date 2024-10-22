using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMasterApp.Data
{
    internal static class Db
    {
        public static SqlConnection Connection { get; set; }= CreateConnection();
        private static SqlConnection CreateConnection()
        {
            string serverName = "DESKTOP-O3KR7G2\\SQLEXPRESS";
            string databaseName = "StockMaster";
            string userName = "sa";
            string password = "1234";
            bool trustServerCertificate = true;

            string connectionString = $"Server={serverName};Database={databaseName};User={userName};Password={password};TrustServerCertificate={trustServerCertificate}";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;

        }
        public static void Open()
        {
            try
            {
                if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }

        }

        public static void Close()
        {
            try
            {
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }

        }
     
    }
}
