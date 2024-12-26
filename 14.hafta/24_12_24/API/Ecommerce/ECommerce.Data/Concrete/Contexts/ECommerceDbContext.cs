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
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            

            // Category entity yapılandırması
            builder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Description).HasMaxLength(500);
            });

            // Product entity yapılandırması
            builder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
                entity.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(p => p.Properties).HasMaxLength(1000);
                entity.Property(p => p.ImageUrl).IsRequired().HasMaxLength(500); // Added ImageUrl property
            });

            // ProductCategory entity yapılandırması
            builder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(pc => new { pc.ProductId, pc.CategoryId });
                entity.HasOne(pc => pc.Product)
                      .WithMany(p => p.ProductCategories)
                      .HasForeignKey(pc => pc.ProductId);
                entity.HasOne(pc => pc.Category)
                      .WithMany(c => c.ProductCategories)
                      .HasForeignKey(pc => pc.CategoryId);
            });

            // Kategori verileri
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Elektronik", Description = "Elektronik ürünler" },
                new Category { Id = 2, Name = "Giyim", Description = "Giyim ürünleri" },
                new Category { Id = 3, Name = "Kozmetik", Description = "Kozmetik ürünler" },
                new Category { Id = 4, Name = "Kitap", Description = "Kitaplar" },
                new Category { Id = 5, Name = "Hediyelik Eşya", Description = "Hediyelik eşyalar" }
            );

            // Ürün verileri
            builder.Entity<Product>().HasData(
                // Elektronik ve Hediyelik Eşya kategorisine dahil ürünler
                new Product { Id = 1, Name = "Akıllı Telefon", Price = 2999.99m, Properties = "Son model akıllı telefon", ImageUrl = "http://localhost:5050/images/products/product1.png" },
                new Product { Id = 2, Name = "Laptop", Price = 4999.99m, Properties = "Yüksek performanslı laptop", ImageUrl = "http://localhost:5050/images/products/product2.png" },
                new Product { Id = 3, Name = "Kamera", Price = 1999.99m, Properties = "Yüksek çözünürlüklü kamera", ImageUrl = "http://localhost:5050/images/products/product3.png" },
                new Product { Id = 4, Name = "Tablet", Price = 1999.99m, Properties = "Taşınabilir tablet", ImageUrl = "http://localhost:5050/images/products/product4.png" },
                new Product { Id = 5, Name = "Bluetooth Hoparlör", Price = 399.99m, Properties = "Kablosuz hoparlör", ImageUrl = "http://localhost:5050/images/products/product5.png" },
                new Product { Id = 6, Name = "Akıllı Saat", Price = 799.99m, Properties = "Akıllı saat", ImageUrl = "http://localhost:5050/images/products/product6.png" },
                new Product { Id = 7, Name = "Kulaklık", Price = 299.99m, Properties = "Kablosuz kulaklık", ImageUrl = "http://localhost:5050/images/products/product7.png" },
                new Product { Id = 8, Name = "Dizüstü Bilgisayar", Price = 3499.99m, Properties = "Hafif dizüstü bilgisayar", ImageUrl = "http://localhost:5050/images/products/product8.png" },
                new Product { Id = 9, Name = "Oyun Konsolu", Price = 2499.99m, Properties = "Yeni nesil oyun konsolu", ImageUrl = "http://localhost:5050/images/products/product9.png" },
                new Product { Id = 10, Name = "Masaüstü Bilgisayar", Price = 3999.99m, Properties = "Güçlü masaüstü bilgisayar", ImageUrl = "http://localhost:5050/images/products/product10.png" },
                new Product { Id = 11, Name = "Yazıcı", Price = 499.99m, Properties = "Renkli yazıcı", ImageUrl = "http://localhost:5050/images/products/product11.png" },
                new Product { Id = 12, Name = "Tarayıcı", Price = 299.99m, Properties = "Doküman tarayıcı", ImageUrl = "http://localhost:5050/images/products/product12.png" },
                new Product { Id = 13, Name = "Projeor", Price = 1999.99m, Properties = "Ev sinema sistemi için projektör", ImageUrl = "http://localhost:5050/images/products/product13.png" },
                new Product { Id = 14, Name = "Kamera Lens", Price = 799.99m, Properties = "Yüksek kaliteli lens", ImageUrl = "http://localhost:5050/images/products/product14.png" },
                new Product { Id = 15, Name = "Aksiyon Kamerası", Price = 1499.99m, Properties = "Aksiyon çekimleri için kamera", ImageUrl = "http://localhost:5050/images/products/product15.png" },
                new Product { Id = 16, Name = "Küçük Ev Aletleri", Price = 299.99m, Properties = "Küçük ev aletleri", ImageUrl = "http://localhost:5050/images/products/product16.png" },
                new Product { Id = 17, Name = "Mutfak Robotu", Price = 899.99m, Properties = "Mutfak robotu", ImageUrl = "http://localhost:5050/images/products/product17.png" },
                new Product { Id = 18, Name = "Blender", Price = 199.99m, Properties = "Blender", ImageUrl = "http://localhost:5050/images/products/product18.png" },
                new Product { Id = 19, Name = "Mikser", Price = 149.99m, Properties = "Mikser", ImageUrl = "http://localhost:5050/images/products/product19.png" },
                new Product { Id = 20, Name = "Fırın", Price = 1999.99m, Properties = "Dijital fırın", ImageUrl = "http://localhost:5050/images/products/product20.png" },

                // Kozmetik ve Hediyelik Eşya kategorisine dahil ürünler
                new Product { Id = 21, Name = "Ruj", Price = 49.99m, Properties = "Kırmızı ruj", ImageUrl = "http://localhost:5050/images/products/product21.png" },
                new Product { Id = 22, Name = "Parfüm", Price = 199.99m, Properties = "Kadın parfümü", ImageUrl = "http://localhost:5050/images/products/product22.png" },
                new Product { Id = 23, Name = "Krem", Price = 79.99m, Properties = "Nemlendirici krem", ImageUrl = "http://localhost:5050/images/products/product23.png" },
                new Product { Id = 24, Name = "Şampuan", Price = 39.99m, Properties = "Saç şampuanı", ImageUrl = "http://localhost:5050/images/products/product24.png" },
                new Product { Id = 25, Name = "Dudak Balmı", Price = 19.99m, Properties = "Nemlendirici dudak balmı", ImageUrl = "http://localhost:5050/images/products/product25.png" },
                new Product { Id = 26, Name = "Makyaj Seti", Price = 299.99m, Properties = "Makyaj seti", ImageUrl = "http://localhost:5050/images/products/product26.png" },
                new Product { Id = 27, Name = "Göz Farı", Price = 59.99m, Properties = "Göz farı", ImageUrl = "http://localhost:5050/images/products/product27.png" },
                new Product { Id = 28, Name = "Oje", Price = 29.99m, Properties = "Renkli oje", ImageUrl = "http://localhost:5050/images/products/product28.png" },
                new Product { Id = 29, Name = "Cilt Bakım Seti", Price = 199.99m, Properties = "Cilt bakım seti", ImageUrl = "http://localhost:5050/images/products/product29.png" },
                new Product { Id = 30, Name = "Vücut Losyonu", Price = 89.99m, Properties = "Vücut losyonu", ImageUrl = "http://localhost:5050/images/products/product30.png" },
                new Product { Id = 31, Name = "Saç Spreyi", Price = 39.99m, Properties = "Saç spreyi", ImageUrl = "http://localhost:5050/images/products/product31.png" },
                new Product { Id = 32, Name = "Makyaj Ayna", Price = 49.99m, Properties = "Makyaj aynası", ImageUrl = "http://localhost:5050/images/products/product32.png" },
                new Product { Id = 33, Name = "Tırnak Bakım Seti", Price = 29.99m, Properties = "Tırnak bakım seti", ImageUrl = "http://localhost:5050/images/products/product33.png" },
                new Product { Id = 34, Name = "Yüz Maskesi", Price = 19.99m, Properties = "Yüz maskesi", ImageUrl = "http://localhost:5050/images/products/product34.png" },
                new Product { Id = 35, Name = "Göz Kremi", Price = 59.99m, Properties = "Göz kremi", ImageUrl = "http://localhost:5050/images/products/product35.png" },
                new Product { Id = 36, Name = "Dudak Peelingi", Price = 29.99m, Properties = "Dudak peelingi", ImageUrl = "http://localhost:5050/images/products/product36.png" },
                new Product { Id = 37, Name = "Cilt Temizleme Jeli", Price = 39.99m, Properties = "Cilt temizleme jeli", ImageUrl = "http://localhost:5050/images/products/product37.png" },
                new Product { Id = 38, Name = "Vücut Scrub'ı", Price = 49.99m, Properties = "Vücut scrub'ı", ImageUrl = "http://localhost:5050/images/products/product38.png" },
                new Product { Id = 39, Name = "Saç Maskesi", Price = 59.99m, Properties = "Saç maskesi", ImageUrl = "http://localhost:5050/images/products/product39.png" },
                new Product { Id = 40, Name = "Makyaj Fırçası", Price = 19.99m, Properties = "Makyaj fırçası", ImageUrl = "http://localhost:5050/images/products/product40.png" },

                // Giyim ve Hediyelik Eşya kategorisine dahil ürünler
                new Product { Id = 41, Name = "Tişört", Price = 99.99m, Properties = "Pamuklu tişört", ImageUrl = "http://localhost:5050/images/products/product41.png" },
                new Product { Id = 42, Name = "Pantolon", Price = 149.99m, Properties = "Şık pantolon", ImageUrl = "http://localhost:5050/images/products/product42.png" },
                new Product { Id = 43, Name = "Elbise", Price = 199.99m, Properties = "Şık elbise", ImageUrl = "http://localhost:5050/images/products/product43.png" },
                new Product { Id = 44, Name = "Ceket", Price = 299.99m, Properties = "Şık ceket", ImageUrl = "http://localhost:5050/images/products/product44.png" },
                new Product { Id = 45, Name = "Kaban", Price = 399.99m, Properties = "Kış kabanı", ImageUrl = "http://localhost:5050/images/products/product45.png" },

                // Kitap ve Hediyelik Eşya kategorisine dahil ürünler
                new Product { Id = 46, Name = "Roman", Price = 39.99m, Properties = "Roman", ImageUrl = "http://localhost:5050/images/products/product46.png" },
                new Product { Id = 47, Name = "Bilim Kurgu", Price = 29.99m, Properties = "Bilim kurgu kitabı", ImageUrl = "http://localhost:5050/images/products/product47.png" },
                new Product { Id = 48, Name = "Tarih Kitabı", Price = 34.99m, Properties = "Tarih kitabı", ImageUrl = "http://localhost:5050/images/products/product48.png" },
                new Product { Id = 49, Name = "Çocuk Kitabı", Price = 19.99m, Properties = "Çocuklar için kitap", ImageUrl = "http://localhost:5050/images/products/product49.png" },
                new Product { Id = 50, Name = "Yemek Kitabı", Price = 49.99m, Properties = "Yemek tarifleri kitabı", ImageUrl = "http://localhost:5050/images/products/product50.png" }
            );

            // Ürün-Kategori ilişkileri
            builder.Entity<ProductCategory>().HasData(
                // Elektronik ve Hediyelik Eşya kategorisine dahil ürünler
                new ProductCategory { ProductId = 1, CategoryId = 1 },
                new ProductCategory { ProductId = 1, CategoryId = 5 },
                new ProductCategory { ProductId = 2, CategoryId = 1 },
                new ProductCategory { ProductId = 2, CategoryId = 5 },
                new ProductCategory { ProductId = 3, CategoryId = 1 },
                new ProductCategory { ProductId = 3, CategoryId = 5 },
                new ProductCategory { ProductId = 4, CategoryId = 1 },
                new ProductCategory { ProductId = 4, CategoryId = 5 },
                new ProductCategory { ProductId = 5, CategoryId = 1 },
                new ProductCategory { ProductId = 5, CategoryId = 5 },
                new ProductCategory { ProductId = 6, CategoryId = 1 },
                new ProductCategory { ProductId = 6, CategoryId = 5 },
                new ProductCategory { ProductId = 7, CategoryId = 1 },
                new ProductCategory { ProductId = 7, CategoryId = 5 },
                new ProductCategory { ProductId = 8, CategoryId = 1 },
                new ProductCategory { ProductId = 8, CategoryId = 5 },
                new ProductCategory { ProductId = 9, CategoryId = 1 },
                new ProductCategory { ProductId = 9, CategoryId = 5 },
                new ProductCategory { ProductId = 10, CategoryId = 1 },
                new ProductCategory { ProductId = 10, CategoryId = 5 },
                new ProductCategory { ProductId = 11, CategoryId = 1 },
                new ProductCategory { ProductId = 11, CategoryId = 5 },
                new ProductCategory { ProductId = 12, CategoryId = 1 },
                new ProductCategory { ProductId = 12, CategoryId = 5 },
                new ProductCategory { ProductId = 13, CategoryId = 1 },
                new ProductCategory { ProductId = 13, CategoryId = 5 },
                new ProductCategory { ProductId = 14, CategoryId = 1 },
                new ProductCategory { ProductId = 14, CategoryId = 5 },
                new ProductCategory { ProductId = 15, CategoryId = 1 },
                new ProductCategory { ProductId = 15, CategoryId = 5 },

                // Kozmetik ve Hediyelik Eşya kategorisine dahil ürünler
                new ProductCategory { ProductId = 21, CategoryId = 3 },
                new ProductCategory { ProductId = 21, CategoryId = 5 },
                new ProductCategory { ProductId = 22, CategoryId = 3 },
                new ProductCategory { ProductId = 22, CategoryId = 5 },
                new ProductCategory { ProductId = 23, CategoryId = 3 },
                new ProductCategory { ProductId = 23, CategoryId = 5 },
                new ProductCategory { ProductId = 24, CategoryId = 3 },
                new ProductCategory { ProductId = 24, CategoryId = 5 },
                new ProductCategory { ProductId = 25, CategoryId = 3 },
                new ProductCategory { ProductId = 25, CategoryId = 5 },
                new ProductCategory { ProductId = 26, CategoryId = 3 },
                new ProductCategory { ProductId = 26, CategoryId = 5 },
                new ProductCategory { ProductId = 27, CategoryId = 3 },
                new ProductCategory { ProductId = 27, CategoryId = 5 },
                new ProductCategory { ProductId = 28, CategoryId = 3 },
                new ProductCategory { ProductId = 28, CategoryId = 5 },
                new ProductCategory { ProductId = 29, CategoryId = 3 },
                new ProductCategory { ProductId = 29, CategoryId = 5 },
                new ProductCategory { ProductId = 30, CategoryId = 3 },
                new ProductCategory { ProductId = 30, CategoryId = 5 },
                new ProductCategory { ProductId = 31, CategoryId = 3 },
                new ProductCategory { ProductId = 31, CategoryId = 5 },
                new ProductCategory { ProductId = 32, CategoryId = 3 },
                new ProductCategory { ProductId = 32, CategoryId = 5 },
                new ProductCategory { ProductId = 33, CategoryId = 3 },
                new ProductCategory { ProductId = 33, CategoryId = 5 },
                new ProductCategory { ProductId = 34, CategoryId = 3 },
                new ProductCategory { ProductId = 34, CategoryId = 5 },
                new ProductCategory { ProductId = 35, CategoryId = 3 },
                new ProductCategory { ProductId = 35, CategoryId = 5 },
                new ProductCategory { ProductId = 36, CategoryId = 3 },
                new ProductCategory { ProductId = 36, CategoryId = 5 },
                new ProductCategory { ProductId = 37, CategoryId = 3 },
                new ProductCategory { ProductId = 37, CategoryId = 5 },
                new ProductCategory { ProductId = 38, CategoryId = 3 },
                new ProductCategory { ProductId = 38, CategoryId = 5 },
                new ProductCategory { ProductId = 39, CategoryId = 3 },
                new ProductCategory { ProductId = 39, CategoryId = 5 },
                new ProductCategory { ProductId = 40, CategoryId = 3 },
                new ProductCategory { ProductId = 40, CategoryId = 5 },

                // Giyim ve Hediyelik Eşya kategorisine dahil ürünler
                new ProductCategory { ProductId = 41, CategoryId = 2 },
                new ProductCategory { ProductId = 41, CategoryId = 5 },
                new ProductCategory { ProductId = 42, CategoryId = 2 },
                new ProductCategory { ProductId = 42, CategoryId = 5 },
                new ProductCategory { ProductId = 43, CategoryId = 2 },
                new ProductCategory { ProductId = 43, CategoryId = 5 },
                new ProductCategory { ProductId = 44, CategoryId = 2 },
                new ProductCategory { ProductId = 44, CategoryId = 5 },
                new ProductCategory { ProductId = 45, CategoryId = 2 },
                new ProductCategory { ProductId = 45, CategoryId = 5 },

                // Kitap ve Hediyelik Eşya kategorisine dahil ürünler
                new ProductCategory { ProductId = 46, CategoryId = 4 },
                new ProductCategory { ProductId = 46, CategoryId = 5 },
                new ProductCategory { ProductId = 47, CategoryId = 4 },
                new ProductCategory { ProductId = 47, CategoryId = 5 },
                new ProductCategory { ProductId = 48, CategoryId = 4 },
                new ProductCategory { ProductId = 48, CategoryId = 5 },
                new ProductCategory { ProductId = 49, CategoryId = 4 },
                new ProductCategory { ProductId = 49, CategoryId = 5 },
                new ProductCategory { ProductId = 50, CategoryId = 4 },
                new ProductCategory { ProductId = 50, CategoryId = 5 }
            );

            // OrderItem entity yapılandırması
            builder.Entity<OrderItem>().Property(oi => oi.UnitPrice).HasColumnType("decimal(10,2)");
            base.OnModelCreating(builder);
        }
    }
}
