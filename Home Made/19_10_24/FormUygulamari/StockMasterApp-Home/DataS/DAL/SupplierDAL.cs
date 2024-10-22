using Microsoft.Data.SqlClient;
using StockMasterApp_Home.Models.SupplierModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMasterApp_Home.DataS.DAL
{
    internal class SupplierDAL
    {
        public void Create(AddSupplierModel model) {
            string query = $@"insert into Suppliers (Name,ContactName,Phone,Address)
                              values
	                              (@p1,@p2,@p3,@p4)";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query,Db.Connect);
            sqlCommand.Parameters.AddWithValue("@p1",model.Name);
            sqlCommand.Parameters.AddWithValue("@p2",model.ContactName);
            sqlCommand.Parameters.AddWithValue("@p3",model.Phone);
            sqlCommand.Parameters.AddWithValue("@p4",model.Address);
            sqlCommand.ExecuteNonQuery();
            Db.Close();
        }
        public void Update(UpdateSupplierModel model)
        {
            string query = $@"update Suppliers set
	                                Name = @p1,
	                                ContactName= @p2,
	                                Phone = @p3,
	                                Address=@p4
                              where Id = @p5";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Db.Connect);
            sqlCommand.Parameters.AddWithValue("@p1", model.Name);
            sqlCommand.Parameters.AddWithValue("@p2", model.ContactName);
            sqlCommand.Parameters.AddWithValue("@p3", model.Phone);
            sqlCommand.Parameters.AddWithValue("@p4", model.Address);
            if (model.Id != 0) sqlCommand.Parameters.AddWithValue("@p5", model.Id);
            sqlCommand.ExecuteNonQuery();
            Db.Close();
        }
        public void delete(int id)
        {
            string query = $@"delete Suppliers where Id = @p1";
            SqlCommand sqlCommand = new SqlCommand(query,Db.Connect);
            sqlCommand.Parameters.AddWithValue("@p1", id);

        }

        public List<SupplierModel> GetAll()
        {
            string query = $@"select * from Suppliers";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query, Db.Connect);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<SupplierModel> list = [];
            SupplierModel supplier;
            while(reader.Read()){
                supplier = new SupplierModel
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    ContactName = (string)reader[2],
                    Phone = (string)reader[3],
                    Address = (string)reader[4]

                };
                list.Add(supplier);
                

            }
            Db.Close();
            return list;
        }

    }
}
