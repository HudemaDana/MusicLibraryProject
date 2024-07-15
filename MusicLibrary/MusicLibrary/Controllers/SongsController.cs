using Microsoft.AspNetCore.Mvc;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongsController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetAll()
        {
            var songs = await _songService.GetAll();
            return Ok(songs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetById(int id)
        {
            var song = await _songService.GetById(id);
            if (song == null)
            {
                return NotFound();
            }
            return Ok(song);
        }

        [HttpGet("album/{albumId}")]
        public async Task<ActionResult<IEnumerable<Song>>> GetByAlbumId(int albumId)
        {
            var songs = await _songService.GetByAlbumId(albumId);
            return Ok(songs);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Song song)
        {
            if (id != song.Id)
            {
                return BadRequest();
            }

            await _songService.Update(song);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _songService.Delete(id);
            return NoContent();
        }
    }
}
