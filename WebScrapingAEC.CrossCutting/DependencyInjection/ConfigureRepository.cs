using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebScrapingAEC.Data.Context;
using WebScrapingAEC.Data.Repository;
using WebScrapingAEC.Domain.Entities;
using WebScrapingAEC.Domain.Interfaces;

namespace WebScrapingAEC.CrossCutting.DependencyInjection;

public class ConfigureRepository
{
    public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

        IServiceCollection serviceCollections = serviceCollection.AddDbContext<MyContext>(
            options => options.UseNpgsql("Host=eac-webscraping.postgres.uhserver.com ;Port=5432; Database=eac_webscraping ;Username=guilhermefelixs;Password=L@ranj4")
        );
    }
}