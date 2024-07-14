using Microsoft.EntityFrameworkCore;
using MusicLibrary.DataAccess.Data;
using MusicLibrary.DataAccess.Repositories.Interfaces;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.DataAccess.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ArtistRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Artist>> GetAll()
        {
            return await _dbContext.Artists.ToListAsync();
        }

        public async Task<Artist> GetArtistById(int id)
        {
            var artistById = await _dbContext.Artists.FindAsync(id);

            return artistById;
        }

        public async Task Add(Artist artist)
        {
            await _dbContext.Artists.AddAsync(artist);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Artist artist)
        {
            _dbContext.Entry(artist).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var artist = await _dbContext.Artists.FindAsync(id);
            if (artist != null)
            {
                _dbContext.Artists.Remove(artist);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
