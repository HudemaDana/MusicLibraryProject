using MusicLibrary.DataAccess.Repositories.Interfaces;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicLibrary.Services
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;

        public SongService(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        public async Task<IEnumerable<Song>> GetAll()
        {
            var songs = await _songRepository.GetAll();
            return songs;
        }

        public async Task<Song> GetById(int id)
        {
            var song = await _songRepository.GetSongById(id);
            return song;
        }

        public async Task<IEnumerable<Song>> GetByAlbumId(int albumId)
        {
            var songs = await _songRepository.GetAll();

            return songs.Where(song=> song.AlbumId == albumId).ToList();
        }

        public async Task Create(Song song)
        {
            await _songRepository.Add(song);
        }

        public async Task Update(Song song)
        {
            await _songRepository.Update(song);
        }

        public async Task Delete(int id)
        {
            await _songRepository.Delete(id);
        }
    }
}
