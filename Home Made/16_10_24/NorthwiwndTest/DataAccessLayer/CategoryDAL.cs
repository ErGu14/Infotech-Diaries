using NorthwiwndTest.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwiwndTest.DataAccessLayer
{
    internal class CategoryDAL
    {
        public LinkedList<Category> GetAll(){

            string query = $@"

                  select 

                      c.CategoryID [KategoriId],
                      c.CategoryName [Kategori],
	                  c.Description [Description]

                  from Categories c
";
            SqlCommand sqlCommand = new SqlCommand(query,Database.Connection);
            Database.ConnectDb();
            SqlDataReader reader = sqlCommand.ExecuteReader();

            LinkedList<Category> list = new LinkedList<Category>();
            Category category;
            while (reader.Read())
            {
                category = new Category { 
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    Description = (string)reader[2],

                };
                list.AddLast(category);
            }
            Database.DisconnectDb();
            return list;
            


    
        }
    }
}
