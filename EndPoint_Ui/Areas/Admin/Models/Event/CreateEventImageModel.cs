using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.Admin.Models.Event
{
    public sealed record CreateEventImageModel
    {
        [Required(ErrorMessage ="تصویر را آپلود نمائید")]
        public IFormFile File { get; set; }
        public Guid EventId { get; set; }
    }
}
