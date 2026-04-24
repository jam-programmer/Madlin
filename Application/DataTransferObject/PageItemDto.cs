namespace Application.DataTransferObject;

public sealed record PageItemDto
{
    public Guid Id { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
    public string? Url { get; set; }
}
