using DataAccess;
using Microsoft.EntityFrameworkCore;
using Services.Category.Dtos;
using Services.Collection.Dtos;
using Services.Song;
using Services.Song.Dtos;

namespace Services.Category;

public class CategoryService : ICategoryService
{
    private AudioserviceDbContext _dbContext;

    public CategoryService(AudioserviceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddCategory(string name, int? parentId)
    {
        var category = new Models.Category() { Name = name, ParentCategoryId = parentId };

        _dbContext.Categories.Add(category);
        _dbContext.SaveChanges();
    }

    public bool DeleteCategory(int id)
    {
        var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == id);

        if (category != null)
        {
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return true;
        }

        return false;
    }

    public CategoryDto? GetCategory(int id)
    {
        var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == id);
        return (category != null) ? new CategoryDto()
        {
            CategoryId = category.CategoryId, 
            Name = category.Name, 
            ParentCategoryId = category?.ParentCategoryId
        } : null;
    }

    public List<CategoryDto> GetCategories()
    {
        var categories = _dbContext.Categories
            .Select(x => new CategoryDto {CategoryId = x.CategoryId, Name = x.Name, ParentCategoryId = x.ParentCategoryId});
        return categories.ToList<CategoryDto>();
    }

    public List<CategoryDto> GetCategories(int id)
    {
        var categories = _dbContext.Categories.Where(x => x.ParentCategoryId == id)
            .Select(x => new CategoryDto() { CategoryId = x.CategoryId, Name = x.Name, ParentCategoryId = x.ParentCategoryId });
        return categories.ToList<CategoryDto>();
    }
    public List<SongDto> GetSongs(int id)
    {
        var category = _dbContext.Categories
            .Include(category => category.Songs)
            .FirstOrDefault(x => x.CategoryId == id);
        
        if (category != null)
        {
            var songs = category.Songs
                .Select(x => new SongDto()
                {
                    SongId = x.SongId,
                    Name = x.Name,
                    Duration = x.Duration,
                    AuthorId = x.AuthorId,
                    AlbumId = x.AlbumId
                });
            return songs.ToList<SongDto>();
        }

        return new List<SongDto>();
    }

    public List<CollectionDto> GetCollections(int id)
    {
        var collections = _dbContext.Collections
            .Where(x => x.CategoryId == id)
            .Select(x => new CollectionDto()
            {
                CollectionId = x.CollectionId,
                Name = x.Name,
                CategoryId = x.CategoryId
            });

        return collections.ToList<CollectionDto>();
    }

    public bool UpdateCategory(int id, string name, int? parentId)
    {
        var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == id);

        if (category != null)
        {
            category.Name = name;
            category.ParentCategoryId = parentId;

            _dbContext.SaveChanges();
            return true;
        }
        return false;
    }


}
