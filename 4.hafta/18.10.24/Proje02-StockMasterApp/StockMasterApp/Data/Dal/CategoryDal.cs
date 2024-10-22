using Microsoft.Data.SqlClient;
using StockMasterApp.Models.CategoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMasterApp.Data.Dal
{
    internal class CategoryDal
    {
        public bool CreateOrUpdate(CategoryCreateOrUpdateModel model, int? id=null)
        {
            string query =
                            id == null ?
                                $@"
                                    INSERT INTO Categories(Name,Description)
                                    VALUES (@p1,@p2)
                                " :
                                $@"
                                    UPDATE Categories SET
	                                    Name=@p1,
	                                    Description=@p2
                                    WHERE Id=@p3
                                ";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Db.Connection);

            sqlCommand.Parameters.AddWithValue("@p1",model.Name);
            sqlCommand.Parameters.AddWithValue("@p2",model.Description);
            if(id!=null) sqlCommand.Parameters.AddWithValue("@p3", id);

            var rowsAffected = sqlCommand.ExecuteNonQuery();
            Db.Close();
            return rowsAffected > 0;
        }

        public bool Delete(int id)
        {
            string query = $"DELETE Categories WHERE Id=@p1";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand( query, Db.Connection);
            sqlCommand.Parameters.AddWithValue("@p1", id);
            var rowsAffected = sqlCommand.ExecuteNonQuery();
            Db.Close();
            return rowsAffected > 0;
        }

        public CategoryModel GetById(int id)
        {
            string query = $"SELECT * Categories WHERE Id=@p1";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Db.Connection);
            sqlCommand.Parameters.AddWithValue("@p1", id);

            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            CategoryModel categoryModel = new CategoryModel
            {
                Id = (int)reader[0],
                Name = (string)reader[1],
                Description = (string)reader[2]
            };
            Db.Close();
            return categoryModel;
        }
        
        public List<CategoryModel> GetAll()
        {
            string query = "SELECT * FROM Categories";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query,Db.Connection);    
            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<CategoryModel> categoryList = [];
            CategoryModel categoryModel;
            while (reader.Read())
            {
                categoryModel = new CategoryModel
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    Description = (string)reader[2]
                };
                categoryList.Add(categoryModel);
            }
            Db.Close();
            return categoryList;
        }
    }
}
