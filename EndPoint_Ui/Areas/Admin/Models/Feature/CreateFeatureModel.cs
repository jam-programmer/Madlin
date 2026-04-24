using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.Admin.Models.Feature;

public record CreateFeatureModel
{
    [Required(ErrorMessage ="عنوان فارسی ویژگی الزامی است")]
    public string? TitleFa { get; set; }
    [Required(ErrorMessage = "مقدار فارسی ویژگی الزامی است")]
    public string? ValueFa { get; set; }
    [Required(ErrorMessage = "عنوان انگلیسی ویژگی الزامی است")]
    public string? TitleEn { get; set; }
    [Required(ErrorMessage = "مقدار انگلیسی ویژگی الزامی است")]
    public string? ValueEn { get; set; }
    public Guid ProductId { get; set; }
}
