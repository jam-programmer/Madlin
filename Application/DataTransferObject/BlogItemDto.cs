namespace Application.DataTransferObject;

public sealed record BlogItemDto
{
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
    public string? UrlName { get; set; }
    public string? ImagePath { get; set; }
    public string? CreatedAt { get; set; }
    public string? CategoryTitleEn { get; set; }
    public string? CategoryTitleFa { get; set; }
    public string? ShortDescriptionEn { get; set; }
    public string? ShortDescriptionFa { get; set; }
}
