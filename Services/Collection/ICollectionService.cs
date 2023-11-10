using Services.Collection.Dtos;
using Services.Song.Dtos;

namespace Services.Collection;

public interface ICollectionService
{
    void AddCollection(string name, int categoryId);
    void AddSongToCollection(int collectionid, int songId);
    bool DeleteCollection(int id);
    bool DeleteSongFromCollection(int collectionId, int songId);
    CollectionDto? GetCollection(int id);
    List<CollectionDto> GetCollections(string name);
    List<CollectionDto> GetCollections();
    List<SongDto> GetSongs(int id);
    bool UpdateCollection(int id, string name, int categoryId);
}