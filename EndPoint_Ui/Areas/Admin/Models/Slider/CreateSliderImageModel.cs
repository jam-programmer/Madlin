using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.Admin.Models.Slider
{
    public record CreateSliderImageModel
    {
        [Required(ErrorMessage ="تصویر الزامی است")]
        public IFormFile File { get; set; }
        public string? Link { get; set; }
        public string? Title { get; set; }
        [Required(ErrorMessage = "بازه شروع نمایش الزامی است")]

        public string? Start { get; set; }
        [Required(ErrorMessage = "بازه پایان نمایش الزامی است")]

        public string? End { get; set; }
    }
}
