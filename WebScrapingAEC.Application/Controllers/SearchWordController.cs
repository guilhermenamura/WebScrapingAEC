using Microsoft.AspNetCore.Mvc;
using WebScrapingAEC.Application.Service;
using WebScrapingAEC.Application.ViewModels;

namespace WebScrapingAEC.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SearchWordController : ControllerBase
{
    [HttpPost()]
    public Task<IActionResult> SearchWord([FromBody] SearchRequest words)
    {
        var searchResults = WordSearchService.Search(words);

        return Task.FromResult<IActionResult>(Ok());
    }
}