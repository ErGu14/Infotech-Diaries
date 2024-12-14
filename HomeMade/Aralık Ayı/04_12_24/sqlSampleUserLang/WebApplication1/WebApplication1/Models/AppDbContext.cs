using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class AppDbContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<UserLang> UserLangs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=ERAY\\SQLEXPRESS;Database=SampleDb;User=sa;Password=1234;TrustServerCertificate=true");
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(x => x.UserLangs).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<Language>().HasMany(x => x.UserLangs).WithOne(x => x.Language).HasForeignKey(x => x.LanguageId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
