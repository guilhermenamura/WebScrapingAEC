using WebScrapingAEC.Application.ViewModels;

namespace WebScrapingAEC.Application.Interface;
public interface IWordSearchService
{
    bool Search(SearchRequest words);
}