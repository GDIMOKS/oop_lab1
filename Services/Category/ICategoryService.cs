using Services.Category.Dtos;
using Services.Collection.Dtos;
using Services.Song;
using Services.Song.Dtos;

namespace Services.Category;
public interface ICategoryService
{
    void AddCategory(string name, int? parentId);
    bool DeleteCategory(int id);
    CategoryDto? GetCategory(int id);
    List<CategoryDto> GetCategories();
    List<CategoryDto> GetCategories(int id);
    List<SongDto> GetSongs(int id);
    List<CollectionDto> GetCollections(int id);
    bool UpdateCategory(int id, string name, int? parentId);
}
    