namespace EndPoint_Ui.Areas.Admin.Models.ProductCategory;

public sealed record ProductCategoryViewModel
{
    public Guid Id { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
  
    public string? IconImagePath { get; set; }
    public bool IsFeatured { get; set; }
}
