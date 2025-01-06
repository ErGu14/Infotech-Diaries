using Microsoft.Data.SqlClient;
using StockMasterApp_Home.Models.CategoryModels;
using StockMasterApp_Home.Models.ProductModels;
using StockMasterApp_Home.Models.SupplierModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMasterApp_Home.DataS.DAL
{
    internal class ProductDAL
    {
        public void Create(AddProductModel model)
        {
            string query = $@"insert into Products(Name,QuantityPerUnit,UnitPrice,UnitsInStock,Discounted,ReorderLevel,CategoryId,SupplierId)
                              values
	                             (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8) ";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query,Db.Connect);
            sqlCommand.Parameters.AddWithValue("@p1",model.Name);
            sqlCommand.Parameters.AddWithValue("@p2",model.QuantityPerUnit);
            sqlCommand.Parameters.AddWithValue("@p3",model.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@p4",model.UnitsInStock);
            sqlCommand.Parameters.AddWithValue("@p5",model.Discounted);
            sqlCommand.Parameters.AddWithValue("@p6",model.ReorderLevel);
            sqlCommand.Parameters.AddWithValue("@p7",model.CategoryId);
            sqlCommand.Parameters.AddWithValue("@p8",model.SupplierId);
            sqlCommand.ExecuteNonQuery();
            Db.Close();


        }
        public void Update(UpdateProductModel model) {
            string query = $@" update Products set
	                                Name = @p1,
	                                QuantityPerUnit = @p2,
	                                UnitPrice = @p3,
	                                UnitsInStock = @p4,
	                                Discounted = @p5,
	                                ReorderLevel = @p6,
	                                CategoryId = @p7,
	                                SupplierId = @p8
                                where Id = @p9";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query,Db.Connect);
            sqlCommand.Parameters.AddWithValue("@p1", model.Name);
            sqlCommand.Parameters.AddWithValue("@p2", model.QuantityPerUnit);
            sqlCommand.Parameters.AddWithValue("@p3", model.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@p4", model.UnitsInStock);
            sqlCommand.Parameters.AddWithValue("@p5", model.Discounted);
            sqlCommand.Parameters.AddWithValue("@p6", model.ReorderLevel);
            sqlCommand.Parameters.AddWithValue("@p7", model.CategoryId);
            sqlCommand.Parameters.AddWithValue("@p8", model.SupplierId);
            if (model.Id != 0)sqlCommand.Parameters.AddWithValue("@p9", model.Id);
            sqlCommand.ExecuteNonQuery();
            Db.Close();
        }

        public void Delete(int id)
        {
            string query = $@"delete Products where Id = @p1";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query,Db.Connect);
            sqlCommand.Parameters.AddWithValue("@p1", id);
            sqlCommand.ExecuteNonQuery();
            Db.Close();
        }

        public List<ProductModel> GetAll()// yine tamamen deneme yanılma yoluyla bişiler test edeceğim.
        {
            string query = $@"select
                                p.Id[Ürün Id],
	                            p.Name[Ürün],
	                            p.QuantityPerUnit[Birim Başına Miktar],
	                            p.UnitPrice[Fiyat],
	                            p.UnitsInStock[Stok Miktarı],
	                            p.Discounted[İndirimli Satış],
	                            p.ReorderLevel[Miktar Seviyesi],
                                p.CategoryId[Kategori Id],
								c.Name[KategoriAdı],
                                 p.SupplierId[Tedarikçi Id],
								 s.Name[Tedarikçi Adı]
								 
	                          


                            from Products p
									join Categories c on c.Id = p.CategoryId
										join Suppliers s on s.Id = p.SupplierId"; // injection korumasını biraz abartarak ve sql de and operatörünü kullanarak farklı bir şey denemeye çalışıyorum.(olmadı)
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query,Db.Connect);
            
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<ProductModel> list = [];
            ProductModel model;
            while (reader.Read()) {
                model = new ProductModel
                {
                    Id = (int)reader[0], 
                    Name = (string)reader[1],
                    QuantityPerUnit = (string)reader[2],
                    UnitPrice = (decimal)reader[3],
                    UnitsInStock = (int)reader[4],
                    Discounted = (bool)reader[5],
                    ReorderLevel = (int)reader[6],
                    CategoryId = (int)reader[7],
                    CategoryName = (string)reader[8],
                    SupplierId = (int)reader[9],
                    SupplierName = (string)reader[10]
                    
                    
                    
                };
                list.Add(model);
            }
            Db.Close();
            return list;



        }
       

        
        public List<ProductModel> GetAll(string searchText,bool check)
        {
            searchText = check ? $@"{searchText}%" : $@"%{searchText}%";

            string query = $@"  select  
                                  p.Id[Ürün Id],
                                    p.Name[Ürün],
                                    p.QuantityPerUnit[Birim Başına Miktar],
                                    p.UnitPrice[Fiyat],
                                    p.UnitsInStock[Stok Miktarı],
                                    p.Discounted[İndirimli Satış],
                                    p.ReorderLevel[Miktar Seviyesi],
                                    p.CategoryId[Kategori Id],
				                    c.Name[KategoriAdı],
                                    p.SupplierId[Tedarikçi Id],
				                    s.Name[Tedarikçi Adı]
				 
  


                                from Products p
								join Categories c on c.Id = p.CategoryId
									join Suppliers s on s.Id = p.SupplierId
                                where p.Name like '{searchText}'";
            Db.Open();
            SqlCommand sqlCommand = new SqlCommand(query,Db.Connect);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<ProductModel> list = [];
            ProductModel model;
                while (reader.Read())
            {
                model = new ProductModel {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    QuantityPerUnit = (string)reader[2],
                    UnitPrice = (decimal)reader[3],
                    UnitsInStock = (int)reader[4],
                    Discounted = (bool)reader[5],
                    ReorderLevel = (int)reader[6],
                    CategoryId = (int)reader[7],
                    CategoryName = (string)reader[8],
                    SupplierId = (int)reader[9],
                    SupplierName = (string)reader[10]
                };
                list.Add(model);

            }
                Db.Close();
            return list;

        }


    }
    }

