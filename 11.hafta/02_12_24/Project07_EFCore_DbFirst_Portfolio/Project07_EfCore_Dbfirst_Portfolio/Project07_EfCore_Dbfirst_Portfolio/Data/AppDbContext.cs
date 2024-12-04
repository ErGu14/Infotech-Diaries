using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Project07_EfCore_Dbfirst_Portfolio.Data.Entities;

namespace Project07_EfCore_Dbfirst_Portfolio.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<About> Abouts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<HomeBanner> HomeBanners { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceInfo> ServiceInfos { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SocialsMediaAccount> SocialsMediaAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-O3KR7G2\\SQLEXPRESS;Database=PortfolioDb;User=sa;Password=1234;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<About>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable(tb => tb.HasTrigger("trg_UpdateAt_Abouts"));

            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Id).HasDefaultValue(1);
            entity.Property(e => e.UpdatedAt).HasPrecision(3);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC071E495238");

            entity.ToTable(tb => tb.HasTrigger("trg_UpdateAt_Categories"));

            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description).HasDefaultValue("Kategori Açıklaması");
            entity.Property(e => e.UpdatedAt).HasPrecision(3);
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable(tb => tb.HasTrigger("trg_UpdateAt_Contacts"));

            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Id).HasDefaultValue(1);
            entity.Property(e => e.UpdatedAt).HasPrecision(3);
        });

        modelBuilder.Entity<HomeBanner>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable(tb => tb.HasTrigger("trg_UpdateAt_HomeBanners"));

            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Id).HasDefaultValue(1);
            entity.Property(e => e.UpdatedAt).HasPrecision(3);
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Messages__3214EC0794E28BCA");

            entity.Property(e => e.ReadingDate).HasPrecision(3);
            entity.Property(e => e.SendingDate)
                .HasPrecision(3)
                .HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Projects__3214EC0787899EA0");

            entity.ToTable(tb => tb.HasTrigger("trg_UpdateAt_Projects"));

            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description).HasDefaultValue("Proje Açıklaması");
            entity.Property(e => e.UpdatedAt).HasPrecision(3);

            entity.HasOne(d => d.Catgorie).WithMany(p => p.Projects)
                .HasForeignKey(d => d.CatgorieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Projects__Catgor__5070F446");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Services__3214EC0705B51580");

            entity.ToTable(tb => tb.HasTrigger("trg_UpdateAt_Services"));

            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Icon).HasDefaultValue("~/ui/img/services/s1.png");
            entity.Property(e => e.UpdatedAt).HasPrecision(3);
        });

        modelBuilder.Entity<ServiceInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable(tb => tb.HasTrigger("trg_UpdateAt_ServiceInfos"));

            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Id).HasDefaultValue(1);
            entity.Property(e => e.UpdatedAt).HasPrecision(3);
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable(tb => tb.HasTrigger("trg_UpdateAt_Settings"));

            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Id).HasDefaultValue(1);
            entity.Property(e => e.UpdatedAt).HasPrecision(3);
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skills__3214EC076C08B8CE");

            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedAt).HasPrecision(3);
        });

        modelBuilder.Entity<SocialsMediaAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SocialsM__3214EC07BBAD1BC3");

            entity.ToTable("SocialsMediaAccount", tb => tb.HasTrigger("trg_UpdateAt_SocialsMediaAccounts"));

            entity.Property(e => e.CreatedAt)
                .HasPrecision(3)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Icon).HasDefaultValue("fa-facebook");
            entity.Property(e => e.UpdatedAt).HasPrecision(3);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
