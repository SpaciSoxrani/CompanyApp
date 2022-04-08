using Microsoft.EntityFrameworkCore;
using MusicApp.Core.Domain.Models;

namespace MusicApp.Infrastructure.Database;

public sealed class MusicAppContext: DbContext
{
 public MusicAppContext()
    { 
        Database.EnsureCreated();
    }      
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DbConcerts;Username=postgres;Password=123");
    }

    public DbSet<MusicEvent> MusEvent { get; set; } = null!;

    public DbSet<EventPlace> EventPlace { get; set; } = null!;
}