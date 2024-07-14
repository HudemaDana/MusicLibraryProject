using MusicLibrary.Domain.Entities;

namespace MusicLibrary.DataAccess.Repositories.Interfaces
{
    public interface ISongRepository
    {
        Task<IEnumerable<Song>> GetAll();
        Task<Song> GetSongById(int id);
        Task Add(Song song);
        Task Update(Song song);
        Task Delete(int id);
    }
}
