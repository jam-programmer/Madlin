using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.Admin.Models.ProductCategory;

public record CreateProductCategoryModel
{
    public string? UrlName { get; set; }
    [Required(ErrorMessage ="عنوان انگلیسی الزامی است")]
    public string? TitleEn { get; set; }
    [Required(ErrorMessage = "عنوان فارسی الزامی است")]
    public string? TitleFa { get; set; }
    [Required(ErrorMessage = "توضیحات انگلیسی الزامی است")]
    public string? DescriptionEn { get; set; }
    [Required(ErrorMessage = "توضیحات فارسی الزامی است")]
    public string? DescriptionFa { get; set; }
    [Required(ErrorMessage = "تصویر دسته بندی الزامی است")]
    public IFormFile? MainImageFile { get; set; }
    [Required(ErrorMessage = "آیکون دسته بندی الزامی است")]
    public IFormFile? IconImageFile { get; set; }
    public bool IsFeatured { get; set; }
}
