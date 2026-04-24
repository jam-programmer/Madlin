namespace EndPoint_Ui.Areas.Admin.Models.Feature;

public sealed record EditFeatureModel:CreateFeatureModel
{
    public Guid Id { get; set; }
}
