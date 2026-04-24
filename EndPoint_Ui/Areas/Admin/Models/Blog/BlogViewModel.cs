namespace EndPoint_Ui.Areas.Admin.Models.Blog;

public sealed record BlogViewModel
{
    public Guid Id { get; set; }
    public string? UrlName { get; set; }
    public string? TitleFa { get; set; }
    public string? ImagePath { get; set; }
    public string? CategoryTitleFa { get; set; }
}
