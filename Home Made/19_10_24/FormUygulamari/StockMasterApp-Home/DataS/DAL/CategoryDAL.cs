using Microsoft.Data.SqlClient;
using StockMasterApp_Home.Models.CategoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMasterApp_Home.DataS.DAL
{
    internal class CategoryDAL
    {
        public void Create(AddCategoryModel model)
        {
            string query = $@"
                        insert into Categories(Name,Description)
                        values
	                        (@p1,@p2)";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query,Db.Connect);
            sqlCommand.Parameters.AddWithValue("@p1",model.Name);
            sqlCommand.Parameters.AddWithValue("@p2",model.Description);
            sqlCommand.ExecuteNonQuery();
            Db.Close();

        }
        public void Update(UpdateCategoryModel model)
        {
            string query = @$"update Categories set
	                                Name = @p1,
	                                Description = @p2
                                where Id = @p3";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query,Db.Connect);
            sqlCommand.Parameters.AddWithValue("@p1", model.Name);
            sqlCommand.Parameters.AddWithValue("@p2", model.Description);
            if(model.Id != 0) sqlCommand.Parameters.AddWithValue("@p3",model.Id);
            sqlCommand.ExecuteNonQuery();
            Db.Close();
        }
        public void Delete(int id)
        {
            string query = $@"delete Categories where Id = @p1";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query,Db.Connect);
            sqlCommand.Parameters.AddWithValue("@p1", id);
            sqlCommand.ExecuteNonQuery();
            Db.Close();
        }
        public List<CategoryModel> GetAll()
        {
            string query = $@"select * from Categories";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query,Db.Connect);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<CategoryModel> list = [];
            CategoryModel category;
            while (reader.Read())
            {
                category = new CategoryModel 
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    Description = (string)reader[2],

                };
                list.Add(category);
            }
            Db.Close();
            return list;
        }

        }

    }

