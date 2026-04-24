namespace Application.DataTransferObject;

public sealed record CategoryPageDto
{
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }

    public string? DescriptionEn { get; set; }
    public string? DescriptionFa { get; set; }
    public string? UrlName { get; set; }

    public Guid? Id { get; set; }
}
