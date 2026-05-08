using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.Admin.Models.Slider
{
    public sealed record EditSliderImageModel
    {
        public Guid Id { get; set; }
        public new IFormFile File { get; set; }
        public string? Link { get; set; }
        public string? Title { get; set; }
        [Required(ErrorMessage = "بازه شروع نمایش الزامی است")]
        public string? Start { get; set; }
        [Required(ErrorMessage = "بازه پایان نمایش الزامی است")]
        public string? End { get; set; }
    }
}
