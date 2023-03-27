using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebScrapingAEC.Application.Service;
using WebScrapingAEC.Application.ViewModels;
using WebScrapingAEC.Domain.Entities.Scraping;
using WebScrapingAEC.Domain.Interfaces.Scraping;

namespace WebScrapingAEC.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchWordController : ControllerBase
    {
        private readonly IWordSearchService _wordSearchService;

        public SearchWordController(IWordSearchService wordSearchService)
        {
            _wordSearchService = wordSearchService;
        }

        [HttpPost()]
        public async Task<IActionResult> SearchWord([FromBody] WordSearchList words)
        {
            var searchResults = await Task.Run(() => _wordSearchService.Search(words));

            return Ok(searchResults);
        }
    }
}
