using Microsoft.AspNetCore.Mvc;
using Services.Category.Dtos;
using Services.Collection.Dtos;
using Services.Song;
using Services.Song.Dtos;

namespace OOP_Lab.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SongsController : ControllerBase
{
    private ISongService _songService;

    public SongsController(ISongService songService)
    {
        _songService = songService;
    }
    
    [HttpGet("[action]/{name}")]
    public IEnumerable<SongDto> GetSongs([FromRoute]string name)
    {
        return _songService.GetSongs(name.Trim());
    }
    
    [HttpGet]
    public IEnumerable<SongDto> GetSongs()
    {
        return _songService.GetSongs();
    }
    
    [HttpGet("{id}")]
    public IActionResult GetSong([FromRoute]int id)
    {
        var song = _songService.GetSong(id);
        
        return (song != null) ? Ok(song) : NotFound();
    }
    
    [HttpGet("{id}/Collections")]
    public IEnumerable<CollectionDto> GetSongCollections([FromRoute]int id)
    {
        return _songService.GetSongCollections(id);
    }
    
    [HttpGet("{id}/Categories")]
    public IEnumerable<CategoryDto> GetSongCategories([FromRoute]int id)
    {
        return _songService.GetSongCategories(id);
    }

    [HttpPost]
    public void AddSong([FromBody]CreateSongDto dto)
    {
        _songService.AddSong(dto.Name, dto.Duration, dto.AuthorId, dto.AlbumId);
    }
    
    [HttpPost("{id}/Categories")]
    public void AddCategoryToSong([FromRoute]int id,[FromBody]SongCategoryDto dto)
    {
        _songService.AddCategoryToSong(id, dto.CategoryId);
    }

    [HttpPost("{id}/Collections")]
    public void AddCollectionToSong([FromRoute] int id,[FromBody]SongCollectionDto dto)
    {
        _songService.AddCollectionToSong(id, dto.CollectionId);
    }

    [HttpPut("{id}")]
    public void UpdateSong([FromRoute]int id, [FromBody]CreateSongDto dto)
    {
        _songService.UpdateSong(id, dto.Name, dto.Duration, dto.AuthorId, dto.AlbumId);
    }

    [HttpDelete("{id}")]
    public void DeleteSong([FromRoute]int id)
    {
        _songService.DeleteSong(id);
    }
    
    [HttpDelete("{songId}/Categories/{categoryId}")]
    public void DeleteCategoryFromSong([FromRoute]int songId, [FromRoute]int categoryId)
    {
        _songService.DeleteCategoryFromSong(songId, categoryId);
    }
    
    [HttpDelete("{songId}/Collections/{collectionId}")]
    public void DeleteCollectionFromSong([FromRoute]int songId, [FromRoute]int collectionId)
    {
        _songService.DeleteCollectionFromSong(songId, collectionId);
    }
    
}