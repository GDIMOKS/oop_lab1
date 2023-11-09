using Services.Collection.Dtos;

namespace Services.Collection;

public interface ICollectionService
{
    void AddCollection(string name, int categoryId);
    bool DeleteCollection(int id);
    CollectionDto? GetCollection(int id);
    List<CollectionDto> GetCollections();
    bool UpdateCollection(int id, string name, int categoryId);
}