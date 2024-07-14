namespace MusicLibrary.Domain.Entities;

public class Artist : BaseEntity
{
    public string Name { get; set; }

    public List<Album> Albums { get; set; }
}
