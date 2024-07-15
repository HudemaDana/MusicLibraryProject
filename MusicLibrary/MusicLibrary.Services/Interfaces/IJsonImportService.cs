// MusicLibrary.Services/Interfaces/IJsonImportService.cs
using System.Threading.Tasks;

namespace MusicLibrary.Services.Interfaces
{
    public interface IJsonImportService
    {
        Task ImportArtistsFromJsonAsync(string jsonFilePath);
    }
}
