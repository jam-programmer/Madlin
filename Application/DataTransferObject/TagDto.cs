namespace Application.DataTransferObject;

public sealed record TagDto
{
    public Guid Id { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
    public string? Key { get; set; }
}
