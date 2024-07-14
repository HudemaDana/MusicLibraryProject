using System.ComponentModel.DataAnnotations;

namespace MusicLibrary.Domain.Entities;
public class Song : BaseEntity
{
    public string Title { get; set; }

    [RegularExpression(@"^\d+:\d+$", ErrorMessage = "Length must be in the format number:number.")]
    public string Length { get; set; }

    public int AlbumId { get; set; }

    public Album Album { get; set; }
}
