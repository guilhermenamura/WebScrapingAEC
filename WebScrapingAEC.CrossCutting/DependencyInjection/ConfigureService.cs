using WebScrapingAEC.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using WebScrapingAEC.Domain.Interfaces.Scraping;

namespace WebScrapingAEC.CrossCutting.DependencyInjection;

public class ConfigureService
{
    public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IScrapingService, ScrapingService>();
    }
}