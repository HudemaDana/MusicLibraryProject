using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Services.Interfaces
{
    public interface ISongService
    {
        Task<IEnumerable<Song>> GetAll();
        Task<Song> GetById(int id);
        Task<IEnumerable<Song>> GetByAlbumId(int albumId);
        Task Create(Song song);
        Task Update(Song song);
        Task Delete(int id);
    }
}
