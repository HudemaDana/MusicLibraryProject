using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Services.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class AlbumsController : ControllerBase
{
    private readonly IAlbumService _albumService;

    public AlbumsController(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
    {
        var products = await _albumService.GetAll();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Album>> GetAlbum(int id)
    {
        var product = await _albumService.GetAlbumById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
}
