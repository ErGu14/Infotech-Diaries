using ECommerce.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Concrete.Contexts
{
    public class ECommerceDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {

        }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region ProductCategory
            builder.Entity<ProductCategory>().HasKey(x => new { x.ProductId, x.CategoryId });
            #endregion

            #region Category

            builder.Entity<Category>().HasKey(x => x.Id);
            builder.Entity<Category>().Property(x => x.Id).ValueGeneratedOnAdd(); //ekleme esnasında değerini yarat
            builder.Entity<Category>().Property(x => x.CreatedDate).HasDefaultValueSql("GETDATE()"); // git oluştururken şu komudu şu şeyi yaz
            builder.Entity<Category>().Property(x => x.Name).HasMaxLength(100);
            //builder.Entity<Category>().Property(x => x.Name).HasColumnType("VARCHAR"); oluştururken bunu böyle yap dedik



            #endregion

            #region Product
            builder.Entity<Product>().HasKey(x => x.Id);
            builder.Entity<Product>().Property(x => x.Id).ValueGeneratedOnAdd(); //ekleme esnasında değerini yarat.
            builder.Entity<Product>().Property(x => x.CreatedDate).HasDefaultValueSql("GETDATE()");


            builder.Entity<Product>().HasMany(x => x.ProductCategories).WithOne(x => x.Product); //productda liste olduğu için many junc table da 1 tane var lsit yok o yüzden one diyoruz
            #endregion

            base.OnModelCreating(builder);
        }
    }
}
