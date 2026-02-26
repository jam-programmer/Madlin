using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.Admin.Models.Question
{
    public record CreateQuestionModel
    {
        [Required(ErrorMessage ="عنوان فارسی سوال الزامی است")]
        public string? TitleFa { get; set; }
        [Required(ErrorMessage = "پاسخ فارسی سوال الزامی است")]

        public string? DescriptionFa { get; set; }
        
        [Required(ErrorMessage ="عنوان انگلیسی سوال الزامی است")]
        public string? TitleEn { get; set; }
        [Required(ErrorMessage = "پاسخ انگلیسی سوال الزامی است")]

        public string? DescriptionEn { get; set; }
    }
}
