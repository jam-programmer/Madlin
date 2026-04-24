namespace EndPoint_Ui.Areas.Admin.Models.Blog;

public sealed record EditBlogModel:CreateBlogModel
{
    public Guid Id { get; set; }
    public string? CategoryTitleFa { get; set; }
    public string? ImagePath { get; set; }
    public new IFormFile? ImageFile { get; set; }
}
