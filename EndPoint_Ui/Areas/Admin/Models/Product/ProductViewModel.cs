namespace EndPoint_Ui.Areas.Admin.Models.Product;

public sealed record ProductViewModel
{
    public Guid Id { get; set; }
    public string? CategoryTitleFa { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
    public string? MainImagePath { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountPrice { get; set; }
    public int Quantity { get; set; }
    public string? ProductCode { get; set; }
}
