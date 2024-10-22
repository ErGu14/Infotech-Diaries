using Microsoft.Data.SqlClient;
using StockMasterApp.Models.CategoryModels;
using StockMasterApp.Models.SupplierModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMasterApp.Data.Dal
{
    internal class SupplierDal
    {
        public bool Create(AddSupplierModel model)
        {
            string query = $@"
                                INSERT INTO Suppliers(Name,ContactName,Phone,Address)
                                VALUES (@p1,@p2,@p3,@p4)
                           ";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Db.Connection);

            sqlCommand.Parameters.AddWithValue("@p1", model.Name);
            sqlCommand.Parameters.AddWithValue("@p2", model.ContactName);
            sqlCommand.Parameters.AddWithValue("@p3", model.Phone);
            sqlCommand.Parameters.AddWithValue("@p4", model.Address);

            var rowsAffected = sqlCommand.ExecuteNonQuery();
            Db.Close();
            return rowsAffected > 0;
        }
        public bool Update(UpdateSupplierModel model)
        {
            string query = $@"
                                UPDATE Suppliers SET
	                                Name=@p1,
	                                ContactName=@p2,
                                    Phone=@p3,
                                    Address=@p4
                                WHERE Id=@p5
                           ";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Db.Connection);

            sqlCommand.Parameters.AddWithValue("@p1", model.Name);
            sqlCommand.Parameters.AddWithValue("@p2", model.ContactName);
            sqlCommand.Parameters.AddWithValue("@p3", model.Phone);
            sqlCommand.Parameters.AddWithValue("@p4", model.Address);
            sqlCommand.Parameters.AddWithValue("@p5", model.Id);

            var rowsAffected = sqlCommand.ExecuteNonQuery();
            Db.Close();
            return rowsAffected > 0;
        }
        public bool Delete(int id)
        {
            string query = $"DELETE Suppliers WHERE Id=@p1";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Db.Connection);
            sqlCommand.Parameters.AddWithValue("@p1", id);
            var rowsAffected = sqlCommand.ExecuteNonQuery();
            Db.Close();
            return rowsAffected > 0;
        }
        public SupplierModel GetById(int id) 
        {
            string query = $"SELECT * Suppliers WHERE Id=@p1";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Db.Connection);
            sqlCommand.Parameters.AddWithValue("@p1", id);

            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            SupplierModel supplierModel = new()
            {
                Id = (int)reader[0],
                Name = (string)reader[1],
                ContactName = (string)reader[2],
                Phone = (string)reader[3],
                Address = (string)reader[4]
            };
            Db.Close();
            return supplierModel;
        }
        public List<SupplierModel> GetAll() 
        {
            string query = "SELECT * FROM Suppliers";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Db.Connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<SupplierModel> supplierList = [];
            SupplierModel supplierModel;
            while (reader.Read())
            {
                supplierModel = new SupplierModel
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    ContactName = (string)reader[2],
                    Phone = (string)reader[3],
                    Address = (string)reader[4]
                };
                supplierList.Add(supplierModel);
            }
            Db.Close();
            return supplierList;
        }
    }
}
