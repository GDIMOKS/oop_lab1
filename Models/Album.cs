namespace Models;

public class Album
{
    public int AlbumId { get; set; }
    public string Name { get; set; }
    public int ReleaseDate { get; set; }

    public int AuthorId { get; set; }
    public Author? Author { get; set; }

    public List<Song>? Songs = new();
    //author
}