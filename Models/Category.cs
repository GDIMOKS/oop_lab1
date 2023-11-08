using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    
    public int? ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }

    [ForeignKey("SongsId")]
    public List<Song> Songs { get; set; } = new();
    public List<Category> Categories { get; set; } = new();

}