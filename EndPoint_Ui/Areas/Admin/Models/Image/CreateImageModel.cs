using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.Admin.Models.Image;

public sealed record CreateImageModel
{
	[Required(ErrorMessage ="آپلود تصویر الزامی است")]
	public IFormFile? File { get; set; }
}
