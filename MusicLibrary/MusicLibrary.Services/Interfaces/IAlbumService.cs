using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Services.Interfaces
{
    public interface IAlbumService
    {
        Task<IEnumerable<Album>> GetAll();
        Task<Album> GetAlbumById(int id);
    }
}
