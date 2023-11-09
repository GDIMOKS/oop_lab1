using DataAccess;
using Services.Author.Dtos;

namespace Services.Author;

public class AuthorService : IAuthorService
{
    private AudioserviceDbContext _dbContext;
    
    public AuthorService(AudioserviceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddAuthor(string name, string description)
    {
        var author = new Models.Author() {Name = name, Description = description ?? null};
        _dbContext.Authors.Add(author);
        _dbContext.SaveChanges();
    }

    public bool DeleteAuthor(int id)
    {
        var author = _dbContext.Authors.FirstOrDefault(x => x.AuthorId == id);

        if (author != null)
        {
            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
            return true;
        }

        return false;
    }

    public AuthorDto? GetAuthor(int id)
    {
        var author = _dbContext.Authors.FirstOrDefault(x => x.AuthorId == id);
        return (author != null) ? new AuthorDto()
        {
            AuthorId = author.AuthorId, 
            Name = author.Name, 
            Description = author.Description
        } : null;
    }

    public List<AuthorDto> GetAuthors()
    {
        var authors = _dbContext.Authors
            .Select(x => new AuthorDto()
            {
                AuthorId = x.AuthorId, 
                Name = x.Name, 
                Description = x.Description
            });
        return authors.ToList<AuthorDto>();
    }

    public bool UpdateAuthor(int id, string name, string description)
    {
        var author = _dbContext.Authors.FirstOrDefault(x => x.AuthorId == id);

        if (author != null)
        {
            author.AuthorId = id;
            author.Name = name;
            author.Description = description;

            _dbContext.SaveChanges();
            return true;
        }
        return false; 
    }
}