using Microsoft.AspNetCore.Mvc;
using Services.Collection;
using Services.Collection.Dtos;

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
    
    [HttpGet]
    public IEnumerable<CollectionDto> GetCollections()
    {
        return _collectionService.GetCollections();
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCollection([FromRoute]int id)
    {
        var Collection = _collectionService.GetCollection(id);
        return (Collection != null) ? Ok(Collection) : NotFound();
    }

    [HttpPost]
    public void AddCollection([FromBody]CreateCollectionDto dto)
    {
        _collectionService.AddCollection(dto.Name, dto.CategoryId);
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
    
}