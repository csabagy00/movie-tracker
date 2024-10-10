using Microsoft.EntityFrameworkCore;
using MovieTracker.Models;
using System.IO;

namespace MovieTracker.Database;

public class MovieTrackerContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Series> Series { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Season> Seasons { get; set; }

    public MovieTrackerContext()
    {
        ApplyMigration();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        string databaseFolder = Path.Combine(baseDirectory, "Database");

        string dbPath = Path.Combine(databaseFolder, "MovieTracker.db");

        if (!Directory.Exists(databaseFolder) || !File.Exists(dbPath))
        {
            Directory.CreateDirectory(databaseFolder);
            File.Create(dbPath);
        }

        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    private void ApplyMigration()
    {
        this.Database.Migrate();
    }
}