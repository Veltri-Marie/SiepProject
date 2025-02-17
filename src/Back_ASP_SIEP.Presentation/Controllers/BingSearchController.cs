using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Services.BingSearch;

namespace Controllers
{
    [Route("api/bing")]
    [ApiController]
    public class BingSearchController : ControllerBase
    {
        private readonly BingSearchService _bingSearchService;

        public BingSearchController(BingSearchService bingSearchService)
        {
            _bingSearchService = bingSearchService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Le paramètre 'query' est requis.");

            var result = await _bingSearchService.SearchAsync(query);
            return Ok(result);
        }
    }
}
