namespace Services.Dtos;

public class CreateCategoryDto
{
    public string? Name { get; set; }
    public int? ParentCategoryId { get; set; }
}