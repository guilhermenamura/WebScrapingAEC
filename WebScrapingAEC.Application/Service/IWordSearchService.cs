using WebScrapingAEC.Domain.Entities.Scraping;

namespace WebScrapingAEC.Application.Service;

public interface IWordSearchService
{
    bool Search(WordSearchList words);
}