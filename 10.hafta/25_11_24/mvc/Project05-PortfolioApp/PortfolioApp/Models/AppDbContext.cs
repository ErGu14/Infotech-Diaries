using System;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Models.Entities;

namespace PortfolioApp.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options ):base(options)
    {
        
    }
    #region DbSets
        
    
    public DbSet<About>? Abouts { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Contact>? Contacts { get; set; }
    public DbSet<HomeBanner>? HomeBanners { get; set; }
    public DbSet<Message>? Messages { get; set; }
    public DbSet<Project>? Projects { get; set; }
     public DbSet<Service>? Services { get; set; }
    public DbSet<ServiceInfo>? ServiceInfos { get; set; }
    public DbSet<Setting>? Settings { get; set; }
    public DbSet<SocialMediaAccount>? socialMediaAccounts { get; set; }
    #endregion

    





}
