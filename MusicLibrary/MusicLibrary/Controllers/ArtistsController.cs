using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Services;
using MusicLibrary.Services.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class ArtistsController : ControllerBase
{
    private readonly IArtistService _artistService;

    public ArtistsController(IArtistService artistService)
    {
        _artistService = artistService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
    {
        var artists = await _artistService.GetAll();
        return Ok(artists);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Artist>> GetArtist(int id)
    {
        var artist = await _artistService.GetById(id);
        if (artist == null)
        {
            return NotFound();
        }
        return Ok(artist);
    }

    //[HttpPost]
    //public async Task<ActionResult<Artist>> CreateArtist(Artist artist)
    //{
    //    var createdArtist = await _artistService.Create(artist);
    //    return CreatedAtAction(nameof(GetArtist), new { id = createdArtist.Id }, createdArtist);
    //}

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateArtist(int id, Artist artist)
    {
        if (id != artist.Id)
        {
            return BadRequest();
        }

        await _artistService.Update(artist);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _artistService.Delete(id);
        return NoContent();
    }
}


