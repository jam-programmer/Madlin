using Microsoft.AspNetCore.Http;

namespace Application.DataTransferObject;

public sealed record ImageDto
{
    public Guid Id { get; set; }
    public string? FilePath { set; get; }
    public IFormFile? File { get; set; }
}
