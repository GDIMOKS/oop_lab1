using Microsoft.AspNetCore.Mvc;
using Services.Category;
using Services.Category.Dtos;
using Services.Song.Dtos;

namespace OOP_Lab.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    
    [HttpGet]
    public IEnumerable<CategoryDto> GetCategories()
    {
        return _categoryService.GetCategories();
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCategory([FromRoute]int id)
    {
        var category = _categoryService.GetCategory(id);
        return (category != null) ? Ok(category) : NotFound();
    }
    [HttpGet("{id}/[controller]")]
    public IEnumerable<CategoryDto> GetCategories([FromRoute] int id)
    {
        return _categoryService.GetCategories(id);
    }

    [HttpGet("{id}/[action]")]
    public IEnumerable<SongDto> GetCategorySongs([FromRoute] int id)
    {
        return _categoryService.GetSongs(id);
    }
    [HttpPost]
    public void AddCategory([FromBody]CreateCategoryDto dto)
    {
        _categoryService.AddCategory(dto.Name, dto.ParentCategoryId);
    }

    [HttpPut("{id}")]
    public void UpdateCategory([FromRoute]int id, [FromBody]CreateCategoryDto dto)
    {
        _categoryService.UpdateCategory(id, dto.Name, dto.ParentCategoryId);
    }

    [HttpDelete("{id}")]
    public void DeleteCategory([FromRoute]int id)
    {
        _categoryService.DeleteCategory(id);

    }
    
}
