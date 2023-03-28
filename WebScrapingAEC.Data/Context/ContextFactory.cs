using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebScrapingAEC.Data.Context;

public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
{
    public MyContext CreateDbContext(string[] args)
    {
        var connectionString = "Host=eac-webscraping.postgres.uhserver.com; Port=5432; Database=eac_webscraping; Username=guilhermefelixs;Password=L@ranj4";
        var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
        optionsBuilder.UseNpgsql(connectionString);
        return new MyContext(optionsBuilder.Options);
    }
}