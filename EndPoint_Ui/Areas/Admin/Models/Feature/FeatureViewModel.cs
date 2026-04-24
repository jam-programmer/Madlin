namespace EndPoint_Ui.Areas.Admin.Models.Feature;

public sealed record FeatureViewModel
{
    public Guid Id { get; set; }
    public string? TitleFa { get; set; }
    public string? ValueFa { get; set; }
}
