using MusicLibrary.DataAccess.Repositories.Interfaces;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Services.Interfaces;

namespace MusicLibrary.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<IEnumerable<Album>> GetAll()
        {
            var albums = await _albumRepository.GetAll();
            return albums;
        }
        public async Task<Album> GetAlbumById(int id)
        {
            var albumWithId = await _albumRepository.GetAlbumById(id);
            return albumWithId;
        }
    }
}
