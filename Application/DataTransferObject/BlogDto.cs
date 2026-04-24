using Microsoft.AspNetCore.Http;

namespace Application.DataTransferObject;

public sealed record BlogDto
{
    public Guid Id { get; set; }
    public string? UrlName { get; set; }
    public string? TitleFa { get; set; }
    public string? ImagePath { get; set; }
    public string? CategoryTitleFa { get; set; }
    public string? TitleEn { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string? DescriptionEn { get; set; }
    public string? DescriptionFa { get; set; }
    public string? ShortDescriptionEn { get; set; }
    public string? ShortDescriptionFa { get; set; }
    public string? CreatedAt { get; set; } 
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }
    public List<Guid>? Tags { get; set; }
}
