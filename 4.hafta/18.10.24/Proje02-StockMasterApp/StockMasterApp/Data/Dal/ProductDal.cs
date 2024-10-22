using Microsoft.Data.SqlClient;
using StockMasterApp.Models.ProductModels;
using StockMasterApp.Models.SupplierModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMasterApp.Data.Dal
{
    internal class ProductDal
    {
        public bool Create(AddProductModel model)
        {
            string query = $@"
                            INSERT INTO Products(Name,QuantityPerUnit,UnitPrice,UnitsInStock,Discounted,ReorderLevel,CategoryId,SupplierId)
                            VALUES
	                            (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)
                           ";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Db.Connection);

            sqlCommand.Parameters.AddWithValue("@p1", model.Name);
            sqlCommand.Parameters.AddWithValue("@p2", model.QuantityPerUnit);
            sqlCommand.Parameters.AddWithValue("@p3", model.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@p4", model.UnitsInStock);
            sqlCommand.Parameters.AddWithValue("@p5", model.Discounted);
            sqlCommand.Parameters.AddWithValue("@p6", model.ReorderLevel);
            sqlCommand.Parameters.AddWithValue("@p7", model.CategoryId);
            sqlCommand.Parameters.AddWithValue("@p8", model.SupplierId);

            var rowsAffected = sqlCommand.ExecuteNonQuery();
            Db.Close();
            return rowsAffected > 0;
        }
        public bool Update(UpdateProductModel model)
        {
            string query = $@"
                            UPDATE Products SET 
	                            Name=@p1,
	                            QuantityPerUnit=@p2,
	                            UnitPrice=@p3,
	                            UnitsInStock=@p4,
	                            Discounted=@p5,
	                            ReorderLevel=@p6,
	                            CategoryId=@p7,
	                            SupplierId=@p8
                            WHERE Id=@p9
                           ";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Db.Connection);

            sqlCommand.Parameters.AddWithValue("@p1", model.Name);
            sqlCommand.Parameters.AddWithValue("@p2", model.QuantityPerUnit);
            sqlCommand.Parameters.AddWithValue("@p3", model.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@p4", model.UnitsInStock);
            sqlCommand.Parameters.AddWithValue("@p5", model.Discounted);
            sqlCommand.Parameters.AddWithValue("@p6", model.ReorderLevel);
            sqlCommand.Parameters.AddWithValue("@p7", model.CategoryId);
            sqlCommand.Parameters.AddWithValue("@p8", model.SupplierId);
            sqlCommand.Parameters.AddWithValue("@p9", model.Id);

            var rowsAffected = sqlCommand.ExecuteNonQuery();
            Db.Close();
            return rowsAffected > 0;
        }
        public bool Delete(int id)
        {
            string query = $"DELETE Products WHERE Id=@p1";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Db.Connection);
            sqlCommand.Parameters.AddWithValue("@p1", id);
            var rowsAffected = sqlCommand.ExecuteNonQuery();
            Db.Close();
            return rowsAffected > 0;
        }
        public ProductModel GetById(int id)
        {
            string query = $"SELECT * FROM Products WHERE Id=@p1";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Db.Connection);
            sqlCommand.Parameters.AddWithValue("@p1", id);

            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            ProductModel productModel = new()
            {
                Id = (int)reader[0],
                Name = (string)reader[1],
                QuantityPerUnit = (string)reader[2],
                UnitPrice = (decimal)reader[3],
                UnitsInStock = (int)reader[4],
                Discounted = (bool)reader[5],
                ReorderLevel = (int)reader[6],
                CategoryId = (int)reader[7],
                SupplierId = (int)reader[8]
            };
            Db.Close();
            return productModel;
        }
        public List<ProductForGridModel> GetAll()
        {
            string query = "SELECT p.Id,p.Name,p.UnitPrice,p.CategoryId,p.SupplierId,c.Name,s.Name,(p.UnitsInStock-p.ReorderLevel) AS [Reorder] FROM Products p JOIN Categories c ON p.CategoryId=c.Id JOIN Suppliers s ON p.SupplierId=s.Id";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Db.Connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<ProductForGridModel> productList = [];
            ProductForGridModel productModel;
            while (reader.Read())
            {
                productModel = new ProductForGridModel
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    UnitPrice = (decimal)reader[2],
                    CategoryId = (int)reader[3],
                    SupplierId = (int)reader[4],
                    Category = (string)reader[5],
                    Supplier = (string)reader[6],
                    Reorder=(int)reader[7]
                };
                productList.Add(productModel);
            }
            Db.Close();
            return productList;
        }

        public int GetCurrentStockById(int id)
        {
            string query = $"SELECT UnitsInStock FROM Products WHERE Id=@p1";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Db.Connection);
            sqlCommand.Parameters.AddWithValue("@p1", id);

            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            int result = (int)reader[0];
            Db.Close();
            return result;
        }

    }
}
