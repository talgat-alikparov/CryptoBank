using CryptoBank.Database.Configurations;
using CryptoBank.Features.News.Domain;
using Microsoft.EntityFrameworkCore;

namespace CryptoBank.Database;

public class CryptoBankDbContext : DbContext
{
    public DbSet<News> News { get; set; }
    public CryptoBankDbContext(DbContextOptions<CryptoBankDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new NewsConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
