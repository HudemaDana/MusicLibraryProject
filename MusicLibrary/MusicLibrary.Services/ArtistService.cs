using MusicLibrary.DataAccess.Repositories.Interfaces;
using MusicLibrary.Services.Interfaces;

namespace MusicLibrary.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }
    }
}
