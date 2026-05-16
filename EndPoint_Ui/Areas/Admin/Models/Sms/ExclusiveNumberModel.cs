using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.Admin.Models.Sms
{
	public class ExclusiveNumberModel
	{
		[Required(ErrorMessage ="متن پیام را ارسال نمائید")]
		public string Message {  get; set; }
		[Required(ErrorMessage = "حداقل شماره تلفن گیرنده را وارد کنید")]
        public string[] PhoneNumbers { get; set; }
    }
}
