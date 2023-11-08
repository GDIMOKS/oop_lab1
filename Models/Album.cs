namespace Models;

public class Album
{
    public int AlbumId { get; set; }
    public string Name { get; set; }
    public DateOnly ReleaseDate { get; set; }

    public List<Song>? Songs = new();
    //author
}