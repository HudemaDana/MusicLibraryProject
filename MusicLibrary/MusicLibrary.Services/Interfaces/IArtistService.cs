using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Services.Interfaces
{
    public interface IArtistService
    {
        Task<IEnumerable<Artist>> GetAll();
        Task<Artist> GetById(int id);
        Task Create(Artist artist);
        Task Update(Artist artist);
        Task Delete(int id);

        Task<IEnumerable<Artist>> SearchArtistsAsync(string query);
    }
}
