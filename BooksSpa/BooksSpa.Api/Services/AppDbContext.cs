using BooksSpa.Api.Models;
using BooksSpa.Api.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BooksSpa.Api.Services;

public class AppDbContext: DbContext
{
    public DbSet<BookWithId> Books { get; set; }

    private readonly AppDbOptions _options;

    public AppDbContext(IOptions<AppDbOptions> options)
    {
        _options = options.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString: $"Data Source = {_options.FileName};");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookWithId>().ToTable("Books");
    }
}