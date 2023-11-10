using Microsoft.AspNetCore.Mvc;
using Services.Collection;
using Services.Collection.Dtos;
using Services.Song.Dtos;

namespace OOP_Lab.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CollectionsController : ControllerBase
{
    private ICollectionService _collectionService;

    public CollectionsController(ICollectionService collectionService)
    {
        _collectionService = collectionService;
    }
    
    [HttpGet("[action]/{name}")]
    public IEnumerable<CollectionDto> GetCollections([FromRoute]string name)
    {
        return _collectionService.GetCollections(name.Trim());
    }
    
    [HttpGet]
    public IEnumerable<CollectionDto> GetCollections()
    {
        return _collectionService.GetCollections();
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCollection([FromRoute]int id)
    {
        var collection = _collectionService.GetCollection(id);
        return (collection != null) ? Ok(collection) : NotFound();
    }
    
    [HttpGet("{id}/Songs")]
    public IEnumerable<SongDto> GetCollectionSongs([FromRoute]int id)
    {
        return _collectionService.GetSongs(id);
    }

    [HttpPost]
    public void AddCollection([FromBody]CreateCollectionDto dto)
    {
        _collectionService.AddCollection(dto.Name, dto.CategoryId);
    }
    
    [HttpPost("{id}/Songs")]
    public void AddSongToCollection([FromRoute]int id, [FromBody]CollectionSongDto dto)
    {
        _collectionService.AddSongToCollection(id, dto.SongId);
    }

    [HttpPut("{id}")]
    public void UpdateCollection([FromRoute]int id, [FromBody]CreateCollectionDto dto)
    {
        _collectionService.UpdateCollection(id, dto.Name, dto.CategoryId);
    }

    [HttpDelete("{id}")]
    public void DeleteCollection([FromRoute]int id)
    {
        _collectionService.DeleteCollection(id);
    }
    
    [HttpDelete("{collectionId}/Songs/{songId}")]
    public void DeleteSongFromCollection([FromRoute]int collectionId,[FromRoute]int songId)
    {
        _collectionService.DeleteSongFromCollection(collectionId, songId);
    }
}