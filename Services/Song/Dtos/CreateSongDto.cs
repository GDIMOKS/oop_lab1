namespace Services.Song.Dtos;

public class CreateSongDto
{
    public string? Name { get; set; }
    public int Duration { get; set; }
    public int AuthorId { get; set; }
    public int AlbumId { get; set; }
}