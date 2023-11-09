using DataAccess;
using Services.Album.Dtos;

namespace Services.Album;

public interface IAlbumService
{
    void AddAlbum(string name, int authorId, int releaseDate);
    bool DeleteAlbum(int id);
    AlbumDto? GetAlbum(int id);
    List<AlbumDto> GetAlbums();
    bool UpdateAlbum(int id, string name, int authorId, int releaseDate);
}