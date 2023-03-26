using WebScrapingAEC.Application.Request;

namespace WebScrapingAEC.Application.Interfaces;

public interface IWordSearchService
{
    Task<bool> Search(SearchRequest words);
}



