using Microsoft.AspNetCore.Mvc;
using Services.Album;
using Services.Album.Dtos;

namespace OOP_Lab.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlbumsController : ControllerBase
{
    private IAlbumService _albumService;

    public AlbumsController(IAlbumService albumService)
    {
        _albumService = albumService;
    }
    
    [HttpGet]
    public IEnumerable<AlbumDto> GetAlbums()
    {
        return _albumService.GetAlbums();
    }
    
    [HttpGet("{id}")]
    public IActionResult GetAlbum([FromRoute]int id)
    {
        var album = _albumService.GetAlbum(id);
        return (album != null) ? Ok(album) : NotFound();
    }

    [HttpPost]
    public void AddAlbum([FromBody]CreateAlbumDto dto)
    {
        _albumService.AddAlbum(dto.Name, dto.AuthorId, dto.ReleaseDate);
    }

    [HttpPut("{id}")]
    public void UpdateAlbum([FromRoute]int id, [FromBody]CreateAlbumDto dto)
    {
        _albumService.UpdateAlbum(id, dto.Name, dto.AuthorId, dto.ReleaseDate);
    }

    [HttpDelete("{id}")]
    public void DeleteAlbum([FromRoute]int id)
    {
        _albumService.DeleteAlbum(id);
    }
    
}