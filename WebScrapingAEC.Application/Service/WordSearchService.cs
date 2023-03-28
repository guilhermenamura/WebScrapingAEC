using WebScrapingAEC.Domain.Entities.Scraping;
using WebScrapingAEC.Domain.Interfaces.Scraping;

namespace WebScrapingAEC.Application.Service
{
    public class WordSearchService : IWordSearchService
    {
        private readonly IScrapingService _scrapingService;

        public WordSearchService(IScrapingService scrapingService)
        {
            _scrapingService = scrapingService;
        }

        public bool Search(WordSearchList words)
        {
            return  _scrapingService.Get(words);
        }
    }
}
