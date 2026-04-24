using Microsoft.AspNetCore.Http;

namespace Application.DataTransferObject;

public sealed record PictureDto
{
    public Guid ProductId { get; set; }
    public string? Path { get; set; }
    public Guid Id { get; set; }
    public IFormFile? File { get; set; }
}
