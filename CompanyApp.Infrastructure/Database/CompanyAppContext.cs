using Microsoft.EntityFrameworkCore;
using CompanyApp.Core.Domain.Models;

namespace CompanyApp.Infrastructure.Database;

public sealed class CompanyAppContext: DbContext
{
    // public CompanyAppContext()
    // { 
    //     Database.EnsureCreated();
    // }      
    
    public CompanyAppContext()
    {
    }

    public CompanyAppContext(DbContextOptions options) : base(options)
    {
    }
    
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<NewsDateGroup>().HasData()
    // }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=NewsDb;Username=postgres;Password=123");
    }

    public DbSet<MainTitle>  MainTitle { get; set; } = null!;
    public DbSet<NewsDateGroup>  NewsDateGroups { get; set; } = null!;
}