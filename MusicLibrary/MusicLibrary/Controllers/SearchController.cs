using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Services.Interfaces;

namespace MusicLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public SearchController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet("autocomplete")]
        public async Task<IEnumerable<Artist>> Autocomplete([FromQuery] string query)
        {
            return await _artistService.SearchArtistsAsync(query);
        }
    }
}
