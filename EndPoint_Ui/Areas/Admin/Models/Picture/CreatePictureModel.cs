using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.Admin.Models.Picture;

public sealed record CreatePictureModel
{
    public Guid ProductId { get; set; }
    [Required(ErrorMessage ="تصویر را آپلود نمائید")]
    public IFormFile File { get; set; }
}
