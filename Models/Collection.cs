using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Collection
{
    public int CollectionId { get; set; }
    public string Name { get; set; }
    
    [ForeignKey("SongsId")]
    public List<Song> Songs { get; set; } = new();
}