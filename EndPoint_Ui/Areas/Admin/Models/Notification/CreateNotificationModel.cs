using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.Admin.Models.Notification;

public record CreateNotificationModel
{
    public IFormFile? File { get; set; }
    public int Size { get; set; }
    [Required(ErrorMessage = "تاریخ شروع الزامی است")]

    public string? Start { get; set; }
    [Required(ErrorMessage = "تاریخ پایان الزامی است")]

    public string? End { get; set; }
    [Required(ErrorMessage = "عنوان انگلیسی الزامی است")]

    public string? TitleEn { get; set; }
    [Required(ErrorMessage = "عنوان فارسی الزامی است")]

    public string? TitleFa { get; set; }
    public string? DescriptionEn { get; set; }
    public string? DescriptionFa { get; set; }
    public bool IsActive { get; set; }
}
