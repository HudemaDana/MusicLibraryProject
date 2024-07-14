using MusicLibrary.DataAccess.Repositories.Interfaces;
using MusicLibrary.Services.Interfaces;

namespace MusicLibrary.Services
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;

        public SongService(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }
    }
}
