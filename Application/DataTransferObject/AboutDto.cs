using Microsoft.AspNetCore.Http;

namespace Application.DataTransferObject;

public sealed record AboutDto
{
    public IFormFile? ImageFile { get; set; }
    public string? ImagePath { get; set; }
    public string? TextEn { get; set; }
    public string? TextFa { get; set; }
}
