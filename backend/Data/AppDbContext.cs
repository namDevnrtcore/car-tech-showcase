// ============================================
// 📁 Data/AppDbContext.cs - Entity Framework DbContext
// ============================================

using Microsoft.EntityFrameworkCore;
using CarTechShowcase.Models;

namespace CarTechShowcase.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Banner> Banners => Set<Banner>();
    public DbSet<CarScreen> CarScreens => Set<CarScreen>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<News> News => Set<News>();
    public DbSet<SiteConfig> SiteConfigs => Set<SiteConfig>();
}