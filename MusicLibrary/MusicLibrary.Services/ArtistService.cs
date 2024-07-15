using MusicLibrary.DataAccess.Repositories.Interfaces;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Services.Interfaces;

namespace MusicLibrary.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<IEnumerable<Artist>> GetAll()
        {
            var artists = await _artistRepository.GetAll();
            return artists;
        }

        public async Task<Artist> GetById(int id)
        {
            var artist = await _artistRepository.GetArtistById(id);
            return artist;
        }

        public async Task Create(Artist artist)
        {
            await _artistRepository.Add(artist);
        }

        public async Task Update(Artist artist)
        {
            await _artistRepository.Update(artist);
        }

        public async Task Delete(int id)
        {
            await _artistRepository.Delete(id);
        }
    }
}
