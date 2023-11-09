using Microsoft.AspNetCore.Mvc;

using Services.Author;
using Services.Author.Dtos;

namespace OOP_Lab.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }
    
    [HttpGet]
    public IEnumerable<AuthorDto> GetAuthors()
    {
        return _authorService.GetAuthors();
    }
    
    [HttpGet("{id}")]
    public IActionResult GetAuthor([FromRoute]int id)
    {
        var author = _authorService.GetAuthor(id);
        return (author != null) ? Ok(author) : NotFound();
    }

    [HttpPost]
    public void AddAuthor([FromBody]CreateAuthorDto dto)
    {
        _authorService.AddAuthor(dto.Name, dto.Description);
    }

    [HttpPut("{id}")]
    public void UpdateAuthor([FromRoute]int id, [FromBody]CreateAuthorDto dto)
    {
        _authorService.UpdateAuthor(id, dto.Name, dto.Description);
    }

    [HttpDelete("{id}")]
    public void DeleteAuthor([FromRoute]int id)
    {
        _authorService.DeleteAuthor(id);
    }
    
}