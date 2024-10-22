using NorthwindManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindManagement.DataAccessLayer
{
    internal class ProductDAL
    {
        public DataTable GetAll()
        {
            string query = @"
                    SELECT
	                    p.ProductID AS [Id],
	                    p.ProductName AS [Name],
	                    p.UnitPrice AS [Price],
	                    p.UnitsInStock AS [Stock],
	                    p.CategoryID AS [CategoryId],
	                    c.CategoryName AS [Category]
                    FROM Products p JOIN Categories c ON p.CategoryID=c.CategoryID
            ";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query,Database.Connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
    
        public DataTable GetAll(string searchText,bool isWithStart)
        {
            //co, ile başlar=> searchText='co%'
            //co, içerir=>searchTect='%co%'
            searchText = isWithStart
                            ? $"{searchText}%"
                            : $"%{searchText}%";
            string query = $@"
                SELECT
	                p.ProductID AS [Id],
	                p.ProductName AS [Name],
	                p.UnitPrice AS [Price],
	                p.UnitsInStock AS [Stock],
	                p.CategoryID AS [CategoryId],
	                c.CategoryName AS [Category]
                FROM Products p JOIN Categories c ON p.CategoryID=c.CategoryID
                WHERE p.ProductName LIKE '{searchText}'
            ";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Database.Connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
    
        public DataTable GetAll(int categoryId)
        {
            string query = $@"
                SELECT
	                p.ProductID AS [Id],
	                p.ProductName AS [Name],
	                p.UnitPrice AS [Price],
	                p.UnitsInStock AS [Stock],
	                p.CategoryID AS [CategoryId],
	                c.CategoryName AS [Category]
                FROM Products p JOIN Categories c ON p.CategoryID=c.CategoryID
                WHERE p.CategoryID={categoryId}
            ";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Database.Connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
    
        public void Create(AddProductModel model)
        {
            string price = model.Price.ToString().Replace(",", ".");
            string query = $@"
                INSERT INTO Products(ProductName,UnitPrice,UnitsInStock,CategoryID)
                VALUES
	                (@p1,@p2,@p3,@p4)
            ";
            Database.ConnectDb();
            SqlCommand sqlCommand = new SqlCommand(query, Database.Connection);
            sqlCommand.Parameters.AddWithValue("@p1",model.Name);
            sqlCommand.Parameters.AddWithValue("@p2",price);
            sqlCommand.Parameters.AddWithValue("@p3",model.Stock);
            sqlCommand.Parameters.AddWithValue("@p4",model.CategoryId);
            sqlCommand.ExecuteNonQuery();
            Database.DisconnectDb();
        }
    
        public void Update(UpdateProductModel model)
        {
            string price = model.Price.ToString().Replace(",", ".");
            string query = $@"
                UPDATE Products
                SET 
	                ProductName='{model.Name}',
	                UnitPrice={price},
	                UnitsInStock={model.Stock},
	                CategoryID={model.CategoryId}
                WHERE ProductID={model.Id}
            ";
            Database.ConnectDb();
            //SqlCommand sqlCommand = new SqlCommand();
            //sqlCommand.CommandText = query;
            //sqlCommand.Connection = Database.Connection;
            SqlCommand sqlCommand = new SqlCommand(query, Database.Connection);
            sqlCommand.ExecuteNonQuery();
            Database.DisconnectDb();
        }

        public void Delete(int id)
        {
            
            string query = $@"
                        delete Products
                        where ProductID = {id}
              ";

            Database.ConnectDb();
            SqlCommand sqlCommand = new SqlCommand(query,Database.Connection);
            sqlCommand.ExecuteNonQuery();
            Database.DisconnectDb();
        }
    }
}
