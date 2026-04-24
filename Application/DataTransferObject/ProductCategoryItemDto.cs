namespace Application.DataTransferObject;

public sealed record ProductCategoryItemDto
{
    public Guid Id { get; set; }
    public string? UrlName { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
    public string? IconImagePath { get; set; }
    public int Count { get; set; }
}
