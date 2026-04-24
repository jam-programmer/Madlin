using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.Admin.Models.Blog;

public record CreateBlogModel
{
    public string? UrlName { get; set; }
    [Required(ErrorMessage ="عنوان فارسی الزامی است")]
    public string? TitleFa { get; set; }
    [Required(ErrorMessage = "عنوان انگلیسی الزامی است")]
    public string? TitleEn { get; set; }
    [Required(ErrorMessage = "آپلود تصویر الزامی است")]
    public IFormFile? ImageFile { get; set; }
    [Required(ErrorMessage = "متن انگلیسی الزامی است")]
    public string? DescriptionEn { get; set; }
    [Required(ErrorMessage = "متن فارسی الزامی است")]
    public string? DescriptionFa { get; set; }
    [Required(ErrorMessage = "دسته بندی الزامی است")]
    public Guid CategoryId { get; set; }

    [Required(ErrorMessage = "توضیح کوتاه انگلیسی الزامی است")]
    public string? ShortDescriptionEn { get; set; }
    [Required(ErrorMessage = "توضیح کوتاه فارسی الزامی است")]
    public string? ShortDescriptionFa { get; set; }
    public List<Guid>? Tags { get; set; }
}
