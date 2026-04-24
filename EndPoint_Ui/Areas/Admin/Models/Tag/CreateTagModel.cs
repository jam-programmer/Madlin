using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.Admin.Models.Tag;

public class CreateTagModel
{
    [Required(ErrorMessage ="عنوان فارسی الزامی است")]
    public string? TitleFa { get; set; }
    [Required(ErrorMessage ="عنوان انگلیسی الزامی است")]
    public string? TitleEn { get; set; }
}
