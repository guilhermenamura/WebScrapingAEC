using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebScrapingAEC.Data.Context;

public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
{
    public MyContext CreateDbContext(string[] args)
    {
        var connectionString = "Host=aec.postgres.uhserver.com; Port=5432; Database=aec; Username=guilherme11;Password=Mudar@12";
        var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
        optionsBuilder.UseNpgsql(connectionString);
        return new MyContext(optionsBuilder.Options);
    }
}