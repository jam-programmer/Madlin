using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.Admin.Models.BlogCategory;

public record CreateBlogCategoryModel
{
    [Required(ErrorMessage = "عنوان انگلیسی الزامی است")]
    public string? TitleEn { get; set; }
    [Required(ErrorMessage = "عنوان فارسی الزامی است")]
    public string? TitleFa { get; set; }
    public string? UrlName { get; set; }
}
