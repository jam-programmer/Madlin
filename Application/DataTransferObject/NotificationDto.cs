using Microsoft.AspNetCore.Http;

namespace Application.DataTransferObject;

public sealed record NotificationDto
{
    public Guid Id { get; set; }
    public IFormFile? File { get; set; }
    public int Size { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
    public string? Path { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
    public string? DescriptionEn { get; set; }
    public string? DescriptionFa { get; set; }
    public bool IsActive { get; set; }
}
