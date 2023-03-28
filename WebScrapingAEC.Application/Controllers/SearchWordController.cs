using Microsoft.AspNetCore.Mvc;
using WebScrapingAEC.Application.Service;
using WebScrapingAEC.Domain.Entities.Scraping;

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
