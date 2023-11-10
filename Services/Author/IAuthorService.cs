using Services.Album.Dtos;
using Services.Author.Dtos;
using Services.Song.Dtos;

namespace Services.Author;

public interface IAuthorService
{
    void AddAuthor(string name, string description);
    bool DeleteAuthor(int id);
    AuthorDto? GetAuthor(int id);
    List<AuthorDto> GetAuthors(string name);

    List<SongDto> GetSongs(int authorId);
    List<AlbumDto> GetAlbums(int authorId);
    List<AuthorDto> GetAuthors();
    bool UpdateAuthor(int id, string name, string description);
}