using Microsoft.EntityFrameworkCore;
using MusicLibrary.DataAccess.Data;
using MusicLibrary.DataAccess.Repositories.Interfaces;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.DataAccess.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SongRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Song>> GetAll()
        {
            return await _dbContext.Songs.ToListAsync();
        }

        public async Task<Song> GetSongById(int id)
        {
            var songById = await _dbContext.Songs.FindAsync(id);

            return songById;
        }

        public async Task Add(Song song)
        {
            await _dbContext.Songs.AddAsync(song);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Song song)
        {
            _dbContext.Entry(song).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var song = await _dbContext.Songs.FindAsync(id);
            if (song != null)
            {
                _dbContext.Songs.Remove(song);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
