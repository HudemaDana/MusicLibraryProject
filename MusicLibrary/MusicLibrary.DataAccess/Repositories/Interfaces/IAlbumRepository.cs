using MusicLibrary.Domain.Entities;

namespace MusicLibrary.DataAccess.Repositories.Interfaces
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<Album>> GetAll();
        Task<Album> GetAlbumById(int id);
        Task Add(Album album);
        Task Update(Album album);
        Task Delete(int id);
    }
}
