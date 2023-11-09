namespace Services.Album.Dtos;

public class CreateAlbumDto
{
    public string Name { get; set; }
    public int ReleaseDate { get; set; }
    public int AuthorId { get; set; }
    /*
    public List<Song>? Songs = new();
*/
}