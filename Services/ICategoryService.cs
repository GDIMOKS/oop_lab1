using Services.Dtos;

namespace Services;
public interface ICategoryService
{
    void AddCategory(string name, int? parentId);
    bool DeleteCategory(int id);
    CategoryDto GetCategory(int id);
    List<CategoryDto> GetCategories();
    List<CategoryDto> GetCategories(int id);

    bool UpdateCategory(int id, string name, int? parentId);
}
    