namespace Services.Category.Dtos;

public class CreateCategoryDto
{
    public string Name { get; set; }
    public int? ParentCategoryId { get; set; }
}