using NorthwiwndTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwiwndTest.DataAccessLayer
{
    internal class ProductDAL
    {
        public DataTable GetAll()
        {
            string query = $@"
                                select 
	                                p.ProductID [Id],
	                                p.ProductName [Ürün],
	                                p.UnitPrice [Fiyat],
	                                p.UnitsInStock [Stok],
	                                p.CategoryID [KategoriId],
	                                c.CategoryName [Kategori]

                                from Products p
	                                join Categories c on c.CategoryID = p.CategoryID

            ";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query,Database.Connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable GetAll(string searchText, bool isWithStarted)
        {
            searchText = isWithStarted ? $"{searchText}%" : $"%{searchText}%";
            

            string query = $@"select 
                              p.ProductID [Id],
                              p.ProductName [Ürün],
                              p.UnitPrice [Fiyat],
                              p.UnitsInStock [Stok],
                              p.CategoryID [KategoriId],
                              c.CategoryName [Kategori]

                          from Products p
                              join Categories c on c.CategoryID = p.CategoryID
                        where p.ProductName like '{searchText}'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter (query,Database.Connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable GetAll(int categoryId)
        {
            string query = $@"
                     SELECT
	                p.ProductID AS [Id],
	                p.ProductName AS [Ürün],
	                p.UnitPrice AS [Fiyat],
	                p.UnitsInStock AS [Stok],
	                p.CategoryID AS [KategoriId],
	                c.CategoryName AS [Kategori]
                FROM Products p JOIN Categories c ON p.CategoryID=c.CategoryID
                WHERE p.CategoryID={categoryId}   
            ";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query,Database.Connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
            
        public void Create(AddProduct model)
        {
            string price = model.Price.ToString().Replace(",",".");
            string query = $@"
                    
                    insert into Products (ProductName,UnitPrice,UnitsInStock,CategoryID)
                    values
	                    ('{model.Name}',{price},{model.Stock},{model.CategoryId})
                    ";
            Database.ConnectDb();
            SqlCommand sqlCommand = new SqlCommand(query,Database.Connection);
            sqlCommand.ExecuteNonQuery();
            Database.DisconnectDb();


        }
    }
}
