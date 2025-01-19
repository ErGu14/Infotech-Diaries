using ECommerce.Entity.Concrete;
using ECommerce.Shared.ComplexTypes;
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
        public DbSet<Basket>? Baskets { get; set; }
        public DbSet<BasketItem>? BasketItems { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderItem>? OrderItems { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductCategory>? ProductCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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

            builder.Entity<OrderItem>().Property(p => p.UnitPrice).HasColumnType("decimal(10,2)");

            // Kategori verileri
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Elektronik", Description = "Elektronik ürünler", ImageUrl = "/images/category-elektronik.png" },
                new Category { Id = 2, Name = "Giyim", Description = "Giyim ürünleri", ImageUrl = "/images/category-giyim.png" },
                new Category { Id = 3, Name = "Kozmetik", Description = "Kozmetik ürünler", ImageUrl = "/images/category-kozmetik.png" },
                new Category { Id = 4, Name = "Kitap", Description = "Kitaplar", ImageUrl = "/images/category-kitap.png" },
                new Category { Id = 5, Name = "Hediyelik Eşya", Description = "Hediyelik eşyalar", ImageUrl = "/images/category-hediyelik-esya.png" },
                new Category { Id = 6, Name = "Spor", Description = "Spor ürünleri", ImageUrl = "/images/category-spor.png" },
                new Category { Id = 7, Name = "Ev Dekorasyonu", Description = "Ev dekorasyon ürünleri", ImageUrl = "/images/category-ev-dekorasyonu.png" },
                new Category { Id = 8, Name = "Müzik", Description = "Müzik aletleri", ImageUrl = "/images/category-muzik.png" },
                new Category { Id = 9, Name = "Oyun", Description = "Oyun ürünleri", ImageUrl = "/images/category-oyun.png" },
                new Category { Id = 10, Name = "Yiyecek", Description = "Gıda ürünleri", ImageUrl = "/images/category-yiyecek.png" }
            );

            List<Product> products = new List<Product>
            {
                // Elektronik ve Hediyelik Eşya kategorisine dahil ürünler
                new Product { Id = 1, Name = "Akıllı Telefon", Price = 2999.99m, Properties = "Son model akıllı telefon", ImageUrl = "/images/product-1.jpg" },
                new Product { Id = 2, Name = "Laptop", Price = 4999.99m, Properties = "Yüksek performanslı laptop", ImageUrl = "/images/product-2.jpg" },
                new Product { Id = 3, Name = "Kamera", Price = 1999.99m, Properties = "Yüksek çözünürlüklü kamera", ImageUrl = "/images/product-3.jpg" },
                new Product { Id = 4, Name = "Tablet", Price = 1999.99m, Properties = "Taşınabilir tablet", ImageUrl = "/images/product-4.jpg" },
                new Product { Id = 5, Name = "Bluetooth Hoparlör", Price = 399.99m, Properties = "Kablosuz hoparlör", ImageUrl = "/images/product-5.jpg" },
                new Product { Id = 6, Name = "Akıllı Saat", Price = 799.99m, Properties = "Akıllı saat", ImageUrl = "/images/product-6.jpg" },
                new Product { Id = 7, Name = "Kulaklık", Price = 299.99m, Properties = "Kablosuz kulaklık", ImageUrl = "/images/product-7.jpg" },
                new Product { Id = 8, Name = "Dizüstü Bilgisayar", Price = 3499.99m, Properties = "Hafif dizüstü bilgisayar", ImageUrl = "/images/product-8.jpg" },
                new Product { Id = 9, Name = "Oyun Konsolu", Price = 2499.99m, Properties = "Yeni nesil oyun konsolu", ImageUrl = "/images/product-9.jpg" },
                new Product { Id = 10, Name = "Masaüstü Bilgisayar", Price = 3999.99m, Properties = "Güçlü masaüstü bilgisayar", ImageUrl = "/images/product-1.jpg" },
                new Product { Id = 11, Name = "Yazıcı", Price = 499.99m, Properties = "Renkli yazıcı", ImageUrl = "/images/product-2.jpg" },
                new Product { Id = 12, Name = "Tarayıcı", Price = 299.99m, Properties = "Doküman tarayıcı", ImageUrl = "/images/product-3.jpg" },
                new Product { Id = 13, Name = "Projeor", Price = 1999.99m, Properties = "Ev sinema sistemi için projektör", ImageUrl = "/images/product-4.jpg" },
                new Product { Id = 14, Name = "Kamera Lens", Price = 799.99m, Properties = "Yüksek kaliteli lens", ImageUrl = "/images/product-5.jpg" },
                new Product { Id = 15, Name = "Aksiyon Kamerası", Price = 1499.99m, Properties = "Aksiyon çekimleri için kamera", ImageUrl = "/images/product-6.jpg" },
                new Product { Id = 16, Name = "Küçük Ev Aletleri", Price = 299.99m, Properties = "Küçük ev aletleri", ImageUrl = "/images/product-7.jpg" },
                new Product { Id = 17, Name = "Mutfak Robotu", Price = 899.99m, Properties = "Mutfak robotu", ImageUrl = "/images/product-8.jpg" },
                new Product { Id = 18, Name = "Blender", Price = 199.99m, Properties = "Blender", ImageUrl = "/images/product-9.jpg" },
                new Product { Id = 19, Name = "Mikser", Price = 149.99m, Properties = "Mikser", ImageUrl = "/images/product-1.jpg" },
                new Product { Id = 20, Name = "Fırın", Price = 1999.99m, Properties = "Dijital fırın", ImageUrl = "/images/product-2.jpg" },

                // Kozmetik ve Hediyelik Eşya kategorisine dahil ürünler
                new Product { Id = 21, Name = "Ruj", Price = 49.99m, Properties = "Kırmızı ruj", ImageUrl = "/images/product-3.jpg" },
                new Product { Id = 22, Name = "Parfüm", Price = 199.99m, Properties = "Kadın parfümü", ImageUrl = "/images/product-4.jpg" },
                new Product { Id = 23, Name = "Krem", Price = 79.99m, Properties = "Nemlendirici krem", ImageUrl = "/images/product-5.jpg" },
                new Product { Id = 24, Name = "Şampuan", Price = 39.99m, Properties = "Saç şampuanı", ImageUrl = "/images/product-6.jpg" },
                new Product { Id = 25, Name = "Dudak Balmı", Price = 19.99m, Properties = "Nemlendirici dudak balmı", ImageUrl = "/images/product-7.jpg" },
                new Product { Id = 26, Name = "Makyaj Seti", Price = 299.99m, Properties = "Makyaj seti", ImageUrl = "/images/product-8.jpg" },
                new Product { Id = 27, Name = "Göz Farı", Price = 59.99m, Properties = "Göz farı", ImageUrl = "/images/product-9.jpg" },
                new Product { Id = 28, Name = "Oje", Price = 29.99m, Properties = "Renkli oje", ImageUrl = "/images/product-1.jpg" },
                new Product { Id = 29, Name = "Cilt Bakım Seti", Price = 199.99m, Properties = "Cilt bakım seti", ImageUrl = "/images/product-2.jpg" },
                new Product { Id = 30, Name = "Vücut Losyonu", Price = 89.99m, Properties = "Vücut losyonu", ImageUrl = "/images/product-3.jpg" },
                new Product { Id = 31, Name = "Saç Spreyi", Price = 39.99m, Properties = "Saç spreyi", ImageUrl = "/images/product-4.jpg" },
                new Product { Id = 32, Name = "Makyaj Ayna", Price = 49.99m, Properties = "Makyaj aynası", ImageUrl = "/images/product-5.jpg" },
                new Product { Id = 33, Name = "Tırnak Bakım Seti", Price = 29.99m, Properties = "Tırnak bakım seti", ImageUrl = "/images/product-6.jpg" },
                new Product { Id = 34, Name = "Yüz Maskesi", Price = 19.99m, Properties = "Yüz maskesi", ImageUrl = "/images/product-7.jpg" },
                new Product { Id = 35, Name = "Göz Kremi", Price = 59.99m, Properties = "Göz kremi", ImageUrl = "/images/product-8.jpg" },
                new Product { Id = 36, Name = "Dudak Peelingi", Price = 29.99m, Properties = "Dudak peelingi", ImageUrl = "/images/product-9.jpg" },
                new Product { Id = 37, Name = "Cilt Temizleme Jeli", Price = 39.99m, Properties = "Cilt temizleme jeli", ImageUrl = "/images/product-1.jpg" },
                new Product { Id = 38, Name = "Vücut Scrub'ı", Price = 49.99m, Properties = "Vücut scrub'ı", ImageUrl = "/images/product-2.jpg" },
                new Product { Id = 39, Name = "Saç Maskesi", Price = 59.99m, Properties = "Saç maskesi", ImageUrl = "/images/product-3.jpg" },
                new Product { Id = 40, Name = "Makyaj Fırçası", Price = 19.99m, Properties = "Makyaj fırçası", ImageUrl = "/images/product-4.jpg" },

                // Giyim ve Hediyelik Eşya kategorisine dahil ürünler
                new Product { Id = 41, Name = "Tişört", Price = 99.99m, Properties = "Pamuklu tişört", ImageUrl = "/images/product-5.jpg" },
                new Product { Id = 42, Name = "Pantolon", Price = 149.99m, Properties = "Şık pantolon", ImageUrl = "/images/product-6.jpg" },
                new Product { Id = 43, Name = "Elbise", Price = 199.99m, Properties = "Şık elbise", ImageUrl = "/images/product-7.jpg" },
                new Product { Id = 44, Name = "Ceket", Price = 299.99m, Properties = "Şık ceket", ImageUrl = "/images/product-8.jpg" },
                new Product { Id = 45, Name = "Kaban", Price = 399.99m, Properties = "Kış kabanı", ImageUrl = "/images/product-9.jpg" },

                // Kitap ve Hediyelik Eşya kategorisine dahil ürünler
                new Product { Id = 46, Name = "Roman", Price = 39.99m, Properties = "Roman", ImageUrl = "/images/product-1.jpg" },
                new Product { Id = 47, Name = "Bilim Kurgu", Price = 29.99m, Properties = "Bilim kurgu kitabı", ImageUrl = "/images/product-2.jpg" },
                new Product { Id = 48, Name = "Tarih Kitabı", Price = 34.99m, Properties = "Tarih kitabı", ImageUrl = "/images/product-3.jpg" },
                new Product { Id = 49, Name = "Çocuk Kitabı", Price = 19.99m, Properties = "Çocuklar için kitap", ImageUrl = "/images/product-4.jpg" },
                new Product { Id = 50, Name = "Yemek Kitabı", Price = 49.99m, Properties = "Yemek tarifleri kitabı", ImageUrl = "/images/product-5.jpg" }
            };

            // Ürün verileri
            builder.Entity<Product>().HasData(products);

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

            // Sipariş verileri
            builder.Entity<Order>().HasData(
                // Ekim 2024
                new Order { Id = 101, ApplicationUserId = "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", OrderStatus = OrderStatus.Delivered, CreatedDate = new DateTime(2024, 10, 5) },
                new Order { Id = 102, ApplicationUserId = "14a0183f-1e96-4930-a83d-6ef5f22d8c09", OrderStatus = OrderStatus.Delivered, CreatedDate = new DateTime(2024, 10, 10) },
                new Order { Id = 103, ApplicationUserId = "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", OrderStatus = OrderStatus.Delivered, CreatedDate = new DateTime(2024, 10, 15) },
                new Order { Id = 104, ApplicationUserId = "14a0183f-1e96-4930-a83d-6ef5f22d8c09", OrderStatus = OrderStatus.Delivered, CreatedDate = new DateTime(2024, 10, 20) },
                new Order { Id = 105, ApplicationUserId = "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", OrderStatus = OrderStatus.Returned, CreatedDate = new DateTime(2024, 10, 25) },
                new Order { Id = 106, ApplicationUserId = "14a0183f-1e96-4930-a83d-6ef5f22d8c09", OrderStatus = OrderStatus.Returned, CreatedDate = new DateTime(2024, 10, 30) },
                new Order { Id = 107, ApplicationUserId = "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", OrderStatus = OrderStatus.Delivered, CreatedDate = new DateTime(2024, 10, 31) },
                new Order { Id = 108, ApplicationUserId = "14a0183f-1e96-4930-a83d-6ef5f22d8c09", OrderStatus = OrderStatus.Returned, CreatedDate = new DateTime(2024, 10, 18) },
                new Order { Id = 109, ApplicationUserId = "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", OrderStatus = OrderStatus.Delivered, CreatedDate = new DateTime(2024, 10, 22) },
                new Order { Id = 110, ApplicationUserId = "14a0183f-1e96-4930-a83d-6ef5f22d8c09", OrderStatus = OrderStatus.Returned, CreatedDate = new DateTime(2024, 10, 28) },

                // Kasım 2024
                new Order { Id = 111, ApplicationUserId = "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", OrderStatus = OrderStatus.Returned, CreatedDate = new DateTime(2024, 11, 5) },
                new Order { Id = 112, ApplicationUserId = "14a0183f-1e96-4930-a83d-6ef5f22d8c09", OrderStatus = OrderStatus.Delivered, CreatedDate = new DateTime(2024, 11, 10) },
                new Order { Id = 113, ApplicationUserId = "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", OrderStatus = OrderStatus.Cancelled, CreatedDate = new DateTime(2024, 11, 15) },
                new Order { Id = 114, ApplicationUserId = "14a0183f-1e96-4930-a83d-6ef5f22d8c09", OrderStatus = OrderStatus.Delivered, CreatedDate = new DateTime(2024, 11, 20) },
                new Order { Id = 115, ApplicationUserId = "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", OrderStatus = OrderStatus.Cancelled, CreatedDate = new DateTime(2024, 11, 25) },
                new Order { Id = 116, ApplicationUserId = "14a0183f-1e96-4930-a83d-6ef5f22d8c09", OrderStatus = OrderStatus.Delivered, CreatedDate = new DateTime(2024, 11, 30) },
                new Order { Id = 117, ApplicationUserId = "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", OrderStatus = OrderStatus.Delivered, CreatedDate = new DateTime(2024, 11, 18) },
                new Order { Id = 118, ApplicationUserId = "14a0183f-1e96-4930-a83d-6ef5f22d8c09", OrderStatus = OrderStatus.Delivered, CreatedDate = new DateTime(2024, 11, 22) },
                new Order { Id = 119, ApplicationUserId = "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", OrderStatus = OrderStatus.Delivered, CreatedDate = new DateTime(2024, 11, 28) },
                new Order { Id = 120, ApplicationUserId = "14a0183f-1e96-4930-a83d-6ef5f22d8c09", OrderStatus = OrderStatus.Delivered, CreatedDate = new DateTime(2024, 11, 29) },

                // Aralık 2024
                new Order { Id = 121, ApplicationUserId = "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", OrderStatus = OrderStatus.Delivered, CreatedDate = new DateTime(2024, 12, 5) },
                new Order { Id = 122, ApplicationUserId = "14a0183f-1e96-4930-a83d-6ef5f22d8c09", OrderStatus = OrderStatus.Delivered, CreatedDate = new DateTime(2024, 12, 10) },
                new Order { Id = 123, ApplicationUserId = "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", OrderStatus = OrderStatus.Shipped, CreatedDate = new DateTime(2024, 12, 15) },
                new Order { Id = 124, ApplicationUserId = "14a0183f-1e96-4930-a83d-6ef5f22d8c09", OrderStatus = OrderStatus.Shipped, CreatedDate = new DateTime(2024, 12, 20) },
                new Order { Id = 125, ApplicationUserId = "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", OrderStatus = OrderStatus.Processing, CreatedDate = new DateTime(2024, 12, 25) },
                new Order { Id = 126, ApplicationUserId = "14a0183f-1e96-4930-a83d-6ef5f22d8c09", OrderStatus = OrderStatus.Processing, CreatedDate = new DateTime(2024, 12, 30) },
                new Order { Id = 127, ApplicationUserId = "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", OrderStatus = OrderStatus.Processing, CreatedDate = new DateTime(2024, 12, 18) },
                new Order { Id = 128, ApplicationUserId = "14a0183f-1e96-4930-a83d-6ef5f22d8c09", OrderStatus = OrderStatus.Processing, CreatedDate = new DateTime(2024, 12, 22) },
                new Order { Id = 129, ApplicationUserId = "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac", OrderStatus = OrderStatus.Pending, CreatedDate = new DateTime(2024, 12, 28) },
                new Order { Id = 130, ApplicationUserId = "14a0183f-1e96-4930-a83d-6ef5f22d8c09", OrderStatus = OrderStatus.Pending, CreatedDate = new DateTime(2024, 12, 29) }
            );

            // Sipariş öğeleri verileri
            builder.Entity<OrderItem>().HasData(
                // Ekim 2024
                new OrderItem { Id = 201, OrderId = 101, ProductId = 1, UnitPrice = 2999.99m, Quantity = 1 },
                new OrderItem { Id = 202, OrderId = 102, ProductId = 2, UnitPrice = 4999.99m, Quantity = 1 },
                new OrderItem { Id = 203, OrderId = 103, ProductId = 3, UnitPrice = 1999.99m, Quantity = 1 },
                new OrderItem { Id = 204, OrderId = 104, ProductId = 4, UnitPrice = 1999.99m, Quantity = 1 },
                new OrderItem { Id = 205, OrderId = 105, ProductId = 5, UnitPrice = 399.99m, Quantity = 1 },
                new OrderItem { Id = 206, OrderId = 106, ProductId = 6, UnitPrice = 799.99m, Quantity = 1 },
                new OrderItem { Id = 207, OrderId = 107, ProductId = 7, UnitPrice = 299.99m, Quantity = 1 },
                new OrderItem { Id = 208, OrderId = 108, ProductId = 8, UnitPrice = 3499.99m, Quantity = 1 },
                new OrderItem { Id = 209, OrderId = 109, ProductId = 9, UnitPrice = 2499.99m, Quantity = 1 },
                new OrderItem { Id = 210, OrderId = 110, ProductId = 10, UnitPrice = 3999.99m, Quantity = 1 },

                // Kasım 2024
                new OrderItem { Id = 211, OrderId = 111, ProductId = 11, UnitPrice = 499.99m, Quantity = 1 },
                new OrderItem { Id = 212, OrderId = 112, ProductId = 12, UnitPrice = 299.99m, Quantity = 1 },
                new OrderItem { Id = 213, OrderId = 113, ProductId = 13, UnitPrice = 1999.99m, Quantity = 1 },
                new OrderItem { Id = 214, OrderId = 114, ProductId = 14, UnitPrice = 799.99m, Quantity = 1 },
                new OrderItem { Id = 215, OrderId = 115, ProductId = 15, UnitPrice = 1499.99m, Quantity = 1 },
                new OrderItem { Id = 216, OrderId = 116, ProductId = 16, UnitPrice = 299.99m, Quantity = 1 },
                new OrderItem { Id = 217, OrderId = 117, ProductId = 17, UnitPrice = 899.99m, Quantity = 1 },
                new OrderItem { Id = 218, OrderId = 118, ProductId = 18, UnitPrice = 199.99m, Quantity = 1 },
                new OrderItem { Id = 219, OrderId = 119, ProductId = 19, UnitPrice = 149.99m, Quantity = 1 },
                new OrderItem { Id = 220, OrderId = 120, ProductId = 20, UnitPrice = 1999.99m, Quantity = 1 },

                // Aralık 2024
                new OrderItem { Id = 221, OrderId = 121, ProductId = 21, UnitPrice = 49.99m, Quantity = 1 },
                new OrderItem { Id = 222, OrderId = 122, ProductId = 22, UnitPrice = 199.99m, Quantity = 1 },
                new OrderItem { Id = 223, OrderId = 123, ProductId = 23, UnitPrice = 79.99m, Quantity = 1 },
                new OrderItem { Id = 224, OrderId = 124, ProductId = 24, UnitPrice = 39.99m, Quantity = 1 },
                new OrderItem { Id = 225, OrderId = 125, ProductId = 25, UnitPrice = 19.99m, Quantity = 1 },
                new OrderItem { Id = 226, OrderId = 126, ProductId = 26, UnitPrice = 299.99m, Quantity = 1 },
                new OrderItem { Id = 227, OrderId = 127, ProductId = 27, UnitPrice = 59.99m, Quantity = 1 },
                new OrderItem { Id = 228, OrderId = 128, ProductId = 28, UnitPrice = 29.99m, Quantity = 1 },
                new OrderItem { Id = 229, OrderId = 129, ProductId = 29, UnitPrice = 199.99m, Quantity = 1 },
                new OrderItem { Id = 230, OrderId = 130, ProductId = 30, UnitPrice = 89.99m, Quantity = 1 }
            );

            // Default roles
            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { Id = "115c7796-cfac-44de-91b5-916eaae125b5", Name = "AdminUser", NormalizedName = "ADMINUSER", Description = "Administrator role" },
                new ApplicationRole { Id = "811f466c-9d06-43f8-a054-24aedbb4161b", Name = "NormalUser", NormalizedName = "NORMALUSER", Description = "Regular user role" }
            );

            // Default users
            var hasher = new PasswordHasher<ApplicationUser>();
            var adminUser = new ApplicationUser
            {
                Id = "c0b7fef7-df2b-4857-9b3d-bc8967ad19ac",
                UserName = "adminuser@gmail.com",
                NormalizedUserName = "ADMINUSER@GMAIL.COM",
                Email = "adminuser@gmail.com",
                NormalizedEmail = "ADMINUSER@GMAIL.COM",
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "User",
                Address = "",
                PhoneNumber = "",
                City = "",
                DateOfBirth = DateTime.Now,
                Gender = GenderType.None,
                PasswordHash = hasher.HashPassword(null, "Qwe123.,")
            };
            var normalUser = new ApplicationUser
            {
                Id = "14a0183f-1e96-4930-a83d-6ef5f22d8c09",
                UserName = "normaluser@gmail.com",
                NormalizedUserName = "NORMALUSER@GMAIL.COM",
                Email = "normaluser@gmail.com",
                NormalizedEmail = "NORMALUSER@GMAIL.COM",
                EmailConfirmed = true,
                FirstName = "Normal",
                LastName = "User",
                Address = "",
                PhoneNumber = "",
                City = "",
                DateOfBirth = DateTime.Now,
                Gender = GenderType.None,
                PasswordHash = hasher.HashPassword(null, "Qwe123.,")
            };
            builder.Entity<ApplicationUser>().HasData(adminUser, normalUser);

            // Assign roles to users
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = adminUser.Id, RoleId = "115c7796-cfac-44de-91b5-916eaae125b5" },
                new IdentityUserRole<string> { UserId = normalUser.Id, RoleId = "811f466c-9d06-43f8-a054-24aedbb4161b" }
            );

            builder.Entity<Basket>().HasData(
                new Basket { Id = 1, ApplicationUserId = adminUser.Id },
                new Basket { Id = 2, ApplicationUserId = normalUser.Id }
            );
        }
    }
}
