using MusicLibrary.Domain.Entities;

namespace MusicLibrary.DataAccess.Repositories.Interfaces
{
    public interface IArtistRepository
    {
        Task<IEnumerable<Artist>> GetAll();
        Task<Artist> GetArtistById(int id);
        Task Add(Artist artist);
        Task Update(Artist artist);
        Task Delete(int id);
    }
}
