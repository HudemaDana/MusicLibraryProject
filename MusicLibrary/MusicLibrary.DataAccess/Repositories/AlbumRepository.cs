using Microsoft.EntityFrameworkCore;
using MusicLibrary.DataAccess.Data;
using MusicLibrary.DataAccess.Repositories.Interfaces;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.DataAccess.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AlbumRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Album>> GetAll()
        {
            return await _dbContext.Albums.ToListAsync();
        }

        public async Task<Album> GetAlbumById(int id)
        {
            var albumById = await _dbContext.Albums.FindAsync(id);

            return albumById;
        }

        public async Task Add(Album album)
        {
            await _dbContext.Albums.AddAsync(album);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Album album)
        {
            _dbContext.Entry(album).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var album = await _dbContext.Albums.FindAsync(id);
            if (album != null)
            {
                _dbContext.Albums.Remove(album);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
