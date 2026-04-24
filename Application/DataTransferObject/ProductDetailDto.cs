namespace Application.DataTransferObject;

public sealed record  ProductDetailDto
{
    public Guid Id { get; set; }
    public string? CategoryTitleEn { get; set; }
    public string? CategoryTitleFa { get; set; }
    public string? CategoryUrlName { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
    public string? MainImagePath { get; set; }
    public string? HoverImagePath { get; set; }
    public string? UrlName { get; set; }
    public ulong Price { get; set; }

    public ulong? DiscountPrice { get; set; }

    public string? ShortDescriptionEn { get; set; }
    public string? ShortDescriptionFa { get; set; }
    public string? FullDescriptionEn { get; set; }
    public string? FullDescriptionFa { get; set; }
    public int Quantity { get; set; }
    public string? ProductCode { get; set; }
    public int Rating { get; set; }
}
