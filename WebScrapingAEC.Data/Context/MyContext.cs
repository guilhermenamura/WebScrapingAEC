using WebScrapingAEC.Data.Mapping;
using WebScrapingAEC.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebScrapingAEC.Data.Context;

public class MyContext : DbContext
{
    public DbSet<PublicationSearchResultEntity> WebScraping { get; set; }
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<PublicationSearchResultEntity>(new WebScrapingMap().Configure);
    }
}