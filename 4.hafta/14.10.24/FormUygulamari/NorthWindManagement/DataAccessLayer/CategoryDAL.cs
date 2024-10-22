using NorthWindManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindManagement.DataAccessLayer
{
    internal class CategoryDAL
    {
            public LinkedList<Category> GetAll()
        {
            string query = @"select 
	                                c.CategoryID [Id],
	                                c.CategoryName [Name],
	                                c.Description [Açıklama]
                             from Categories c";
             SqlCommand sqlCommand = new SqlCommand(query,Database.Connection);
             Database.connectDb();
             SqlDataReader reader = sqlCommand.ExecuteReader();

            LinkedList<Category> categoryList = new LinkedList<Category>();
            Category category;
            while (reader.Read())
            {

                category = new Category()
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    Description = (string)reader[2]
                };
                categoryList.AddLast(category);
                
            }
            Database.DisconnectDb();
            return categoryList;

        }
    }
}
