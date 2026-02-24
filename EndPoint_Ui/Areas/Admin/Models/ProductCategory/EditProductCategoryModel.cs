namespace EndPoint_Ui.Areas.Admin.Models.ProductCategory;

public sealed record EditProductCategoryModel:CreateProductCategoryModel
{
    public Guid Id { get; set; }    
    public string? MainImagePath { get; set; }
    public new IFormFile? MainImageFile { get; set; }
    public new IFormFile? IconImageFile { get; set; }
    public string? IconImagePath { get; set; }
}
