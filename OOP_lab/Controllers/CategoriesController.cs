using Microsoft.AspNetCore.Mvc;
using Services;
using Models;
using Services.Dtos;

namespace OOP_Lab.Controllers;

[Route("api/[controller]/[action]")]
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
    public CategoryDto GetCategory([FromRoute]int id)
    {
        return _categoryService.GetCategory(id);
    }

    [HttpGet("{id}")]
    public IEnumerable<CategoryDto> GetCategories([FromRoute] int id)
    {
        return _categoryService.GetCategories(id);
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
