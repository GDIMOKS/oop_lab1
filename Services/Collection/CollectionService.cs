using DataAccess;
using Services.Collection.Dtos;

namespace Services.Collection;

public class CollectionService : ICollectionService
{
    private AudioserviceDbContext _dbContext;

    public CollectionService(AudioserviceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void AddCollection(string name, int categoryId)
    {
        var collection = new Models.Collection() {Name = name, CategoryId = categoryId};
        _dbContext.Collections.Add(collection);
        _dbContext.SaveChanges();
    }

    public bool DeleteCollection(int id)
    {
        var collection = _dbContext.Collections.FirstOrDefault(x => x.CollectionId == id);
        if (collection != null)
        {
            _dbContext.Collections.Remove(collection);
            _dbContext.SaveChanges();
            return true;
        }

        return false;
    }

    public CollectionDto? GetCollection(int id)
    {
        var collection = _dbContext.Collections.FirstOrDefault(x => x.CollectionId == id);
        return (collection != null)
            ? new CollectionDto()
            {
                CollectionId = collection.CollectionId,
                Name = collection.Name,
                CategoryId = collection.CategoryId
            }
            : null;
    }

    public List<CollectionDto> GetCollections()
    {
        var collections = _dbContext.Collections
            .Select(x => new CollectionDto()
            {
                CollectionId = x.CollectionId,
                Name = x.Name,
                CategoryId = x.CategoryId
            });
        return collections.ToList<CollectionDto>();
    }

    public bool UpdateCollection(int id, string name, int categoryId)
    {
        var collection = _dbContext.Collections.FirstOrDefault(x => x.CollectionId == id);
        if (collection != null)
        {
            collection.Name = name;
            collection.CategoryId = categoryId;
            return true;
        }

        return false;
    }
}