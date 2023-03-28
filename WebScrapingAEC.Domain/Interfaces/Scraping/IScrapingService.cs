using WebScrapingAEC.Domain.Entities.Scraping;

namespace WebScrapingAEC.Domain.Interfaces.Scraping;

public interface IScrapingService
{
    bool Get(WordSearchList words);
}