using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebScrapingAEC.Data.Context;
using WebScrapingAEC.Data.Repository;
using WebScrapingAEC.Domain.Entities;
using WebScrapingAEC.Domain.Interfaces;
using WebScrapingAEC.Domain.Interfaces.Scraping;
using WebScrapingAEC.Service.Services;

namespace WebScrapingAEC.CrossCutting.DependencyInjection;

public class ConfigureRepository
{
    public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IScrapingService, ScrapingService>();
        
        serviceCollection.AddScoped<IRepository<PublicationSearchResultEntity>, BaseRepository<PublicationSearchResultEntity>>();

        IServiceCollection serviceCollections = serviceCollection.AddDbContext<MyContext>(
            options => options.UseNpgsql("Host=aec.postgres.uhserver.com; Port=5432; Database=aec; Username=guilherme11;Password=Mudar@12")
        );
    }
}