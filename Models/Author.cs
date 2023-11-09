using System.ComponentModel.DataAnnotations;

namespace Models;

public class Author
{
    public int AuthorId {get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public List<Song>? Songs = new();
    public List<Album>? Albums = new();
}