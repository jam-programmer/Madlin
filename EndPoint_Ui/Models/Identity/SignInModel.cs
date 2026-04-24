using EndPoint_Ui.Resources.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Models.Identity;

public sealed record SignInModel
{
	[Required(ErrorMessageResourceName = "UserName",
		ErrorMessageResourceType = typeof(SignInResource))]

	public string UserName { get; set; }
	[Required(ErrorMessageResourceName = "Password",
		ErrorMessageResourceType = typeof(SignInResource))]

	public string Password { get; set; }
}
