namespace EndPoint_Ui.Areas.Admin.Models.Product;

public record EditProductModel:CreateProductModel
{
    public Guid Id { get; set; }
    public string? MainImagePath { get; set; }
    public string? HoverImagePath { get; set; }
    public string? CategoryTitleFa { get; set; }

    public new IFormFile? MainImageFile { get; set; }
    public new IFormFile? HoverImageFile { get; set; }

}
