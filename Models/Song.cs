using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Song
    {
        public int SongId { get; set; }
        
        public string Name { get; set; }
        
        public int Duration { get; set; }
        
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        
        public int AlbumId { get; set; }
        public Album? Album { get; set; }
        
        [ForeignKey("CategoriesId")]
        public List<Category> Categories { get; set; } = new();
        [ForeignKey("CollectionsId")]
        public List<Collection> Collections { get; set; } = new();
    }
}

