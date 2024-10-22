using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NorthwiwndTest.DataAccessLayer
{
    internal static class Database
    {
        public static SqlConnection Connection { get; set; } = CreateConnection();
        private static SqlConnection CreateConnection() {
            string connectionString = $@"Server=ERAY\SQLEXPRESS;
                                         Database=Northwind;
                                         User=sa;
                                         Password=1234;
                                         TrustServerCertificate=True";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;




        }
        public static void ConnectDb() {

            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }

        }
        public static void DisconnectDb() {
            if(Connection.State == ConnectionState.Open) {
                Connection.Close();
        }

        }
    }
}
