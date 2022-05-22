using Microsoft.EntityFrameworkCore;
using CompanyApp.Core.Domain.Models;

namespace CompanyApp.Infrastructure.Database;

public sealed class CompanyAppContext: DbContext
{
 public CompanyAppContext()
    { 
        Database.EnsureCreated();
    }      
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=NewsDb;Username=postgres;Password=123");
    }

    public DbSet<MainTitle>  MainTitle { get; set; } = null!;
}