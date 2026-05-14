using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.Admin.Models.Bank
{
	public record CreateBankModel
	{
		[Required(ErrorMessage ="عنوان شماره الزامی است")]
		public string? Title { get; set; }
		[Required(ErrorMessage = " شماره الزامی است")]

		public string? PhoneNumber { get; set; }
	}
}
