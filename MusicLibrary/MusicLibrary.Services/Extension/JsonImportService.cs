// MusicLibrary.Services/JsonImportService.cs
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Services.Interfaces;

namespace MusicLibrary.Services
{
    public class JsonImportService : IJsonImportService
    {
        private readonly IArtistService _artistService;

        public JsonImportService(IArtistService artistService)
        {
            _artistService = artistService;
        }

        public async Task ImportArtistsFromJsonAsync(string jsonFilePath)
        {
            if (File.Exists(jsonFilePath))
            {
                // Read the JSON file content as a string
                var jsonString = await File.ReadAllTextAsync(jsonFilePath);

                // Use regular expressions to remove newlines and tabs that are not inside strings
                jsonString = CleanJsonString(jsonString);

                // Deserialize the cleaned JSON content
                var artists = JsonSerializer.Deserialize<List<Artist>>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (artists != null)
                {
                    foreach (var artist in artists)
                    {
                        var existingArtists = await _artistService.GetAll();
                        if (!existingArtists.Any(a => a.Name == artist.Name))
                        {
                            await _artistService.Create(artist);
                        }
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("JSON file not found.", jsonFilePath);
            }
        }

        private string CleanJsonString(string jsonString)
        {
            var regex = new Regex(@"(?<!\\)[\n\t\r]", RegexOptions.Multiline);
            jsonString = regex.Replace(jsonString, string.Empty);
            return jsonString;
        }
    }
}
