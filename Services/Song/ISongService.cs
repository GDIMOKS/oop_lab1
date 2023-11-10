using Services.Category.Dtos;
using Services.Collection.Dtos;
using Services.Song.Dtos;

namespace Services.Song;

public interface ISongService
{
    void AddSong(string name, int duration, int authorId, int albumId);
    void AddCategoryToSong(int songId, int categoryId);
    void AddCollectionToSong(int songId, int collectionId);

    bool DeleteSong(int id);
    bool DeleteCategoryFromSong(int songId, int categoryId);
    bool DeleteCollectionFromSong(int songId, int collectionId);
    SongDto? GetSong(int id);
    List<SongDto> GetSongs(string name);
    /*
     метод уже есть в категориях
    List<SongDto> GetSongsByCategory(int categoryId);
    */


    List<SongDto> GetSongs();
    List<CategoryDto> GetSongCategories(int id);
    List<CollectionDto> GetSongCollections(int id);

    bool UpdateSong(int id, string name, int duration, int authorId, int albumId);
}