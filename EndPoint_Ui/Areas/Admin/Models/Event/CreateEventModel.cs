using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.Admin.Models.Event
{
    public record CreateEventModel
    {
        [Required(ErrorMessage = "آپلود تصویر الزامی است")]
        public IFormFile? File { get; set; }
        [Required(ErrorMessage ="عنوان انگلیسی الزامی است")]
        public string? TitleEn { set; get; }
        [Required(ErrorMessage = "عنوان فارسی الزامی است")]
        public string? TitleFa { set; get; }
        public string? DescriptionEn { set; get; }
        public string? DescriptionFa { set; get; }
        public List<string>? VideoUrls { set; get; }
    }
}
