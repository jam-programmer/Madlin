namespace Application.DataTransferObject;

public sealed record FeatureDto
{
    public string? TitleFa { get; set; }
    public string? ValueFa { get; set; }
    public string? TitleEn { get; set; }
    public string? ValueEn { get; set; }
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
}
