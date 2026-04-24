namespace EndPoint_Ui.Areas.Admin.Models.BlogCategory;

public sealed record BlogCategoryViewModel
{
    public Guid Id { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
    public string? UrlName { get; set; }
}
