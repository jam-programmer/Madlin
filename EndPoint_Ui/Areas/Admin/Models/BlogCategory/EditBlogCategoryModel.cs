namespace EndPoint_Ui.Areas.Admin.Models.BlogCategory;

public sealed record EditBlogCategoryModel:CreateBlogCategoryModel
{
    public Guid Id { get; set; }    
}
