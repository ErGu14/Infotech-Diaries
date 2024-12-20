using Exam.Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.DbContexts
{
    public class SQLExamContext : IdentityDbContext<AppUser,AppRole,string> // user bilgisi ,role bilgisi, ve bunların alacağı veri türü        Identity İçeren bir dbcontex  diyoruz
    {
        public SQLExamContext(DbContextOptions options ) : base( options ) 
        {
            
        }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductCategory>().HasKey(x => new {x.ProductId,x.CategoryId });
            base.OnModelCreating(builder);
        }



    }
}
