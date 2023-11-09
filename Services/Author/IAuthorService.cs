using Services.Author.Dtos;

namespace Services.Author;

public interface IAuthorService
{
    void AddAuthor(string name, string description);
    bool DeleteAuthor(int id);
    AuthorDto? GetAuthor(int id);
    List<AuthorDto> GetAuthors();
    bool UpdateAuthor(int id, string name, string description);
}