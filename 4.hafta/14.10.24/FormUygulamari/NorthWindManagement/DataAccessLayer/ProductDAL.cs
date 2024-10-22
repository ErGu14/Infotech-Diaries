using NorthWindManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindManagement.DataAccessLayer
{
    internal class ProductDAL
    {
        public DataTable GetAll()
        {
            string query = @"select p.ProductId [Id], p.ProductName [Name], p.UnitPrice [Price], p.UnitsInStock [Stock], c.CategoryID [CategoryId], c.CategoryName [CategoryName]
                from Products p
                join Categories c on c.CategoryID = p.CategoryID";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Database.Connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable GetAll(string searchText, bool isWithStarted)
        {
            searchText = isWithStarted ? $"{searchText}%" : $"%{searchText}%";
            string query = $@"select p.ProductId [Id], p.ProductName [Name], p.UnitPrice [Price], p.UnitsInStock [Stock], c.CategoryID [CategoryId], c.CategoryName [Category Name]
                              from Products p
                              join Categories c on c.CategoryID = p.CategoryID
                              where p.ProductName like '{searchText}'";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Database.Connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable GetAll(int categoryId)
        {
            string query = $@"select p.ProductId [Id], p.ProductName [Name], p.UnitPrice [Price], p.UnitsInStock [Stock], p.CategoryID [CategoryId], c.CategoryName [Category]
                              from Products p 
                              join Categories c on p.CategoryID = c.CategoryID
                              where p.CategoryID = {categoryId}";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, Database.Connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
    }
}
