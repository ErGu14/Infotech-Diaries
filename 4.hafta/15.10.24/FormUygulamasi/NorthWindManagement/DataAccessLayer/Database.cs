using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindManagement.DataAccessLayer
{
    internal static class Database
    {
        public static SqlConnection Connection { get; set; }=CreateConnection();
        private static SqlConnection CreateConnection()
        {
            //string connectionString = @"Server=DESKTOP-488APMT\SQLEXPRESS02;Database=Northwind;User=sa;Password=1234;TrustServerCertificate=true";
            string connectionString = "Server=DESKTOP-O3KR7G2\\SQLEXPRESS;";
            connectionString += "Database=Northwind;";
            connectionString += "User=sa;Password=1234;";
            connectionString += "TrustServerCertificate=true;";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        public static void ConnectDb()
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
        }
        public static void DisconnectDb()
        {
            if(Connection.State==ConnectionState.Open)
            {
                Connection.Close();
            }
        }
    }
}
