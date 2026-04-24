using EndPoint_Ui.Resources.Areas.User.Models;
using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.User.Models;

public sealed record ProfileModel:IValidatableObject
{
    public Guid Id { get; set; }
    [Required(ErrorMessageResourceName = "FullName",
        ErrorMessageResourceType = typeof(ProfileModelResource))]
    public string? FullName { get; set; }
    [Required(ErrorMessageResourceName = "Email",
    ErrorMessageResourceType = typeof(ProfileModelResource))]
    public string? Email { get; set; }
    [Required(ErrorMessageResourceName = "PhoneNumber",
    ErrorMessageResourceType = typeof(ProfileModelResource))]
    public string? PhoneNumber { get; set; }
    public string? OldPassword { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        List<ValidationResult> validations = [];

        if (!string.IsNullOrEmpty(OldPassword) &&
            (string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword)))
        {
            string passwordError = CultureInfo.CurrentUICulture.Name == "en-US"
                ? "To change your password, please enter the new password and confirm the new password"
                : "برای تغییر رمز عبور لطفا رمز عبور جدید و تکرار رمز عبور جدید را وارد کنید";

            validations.Add(new ValidationResult(passwordError, ["Password", "ConfirmPassword"]));
        }

       
        if (string.IsNullOrEmpty(OldPassword) &&
            (!string.IsNullOrEmpty(Password) || !string.IsNullOrEmpty(ConfirmPassword)))
        {
         
            string passwordError = CultureInfo.CurrentUICulture.Name == "en-US"
                ? "To change the password, you must enter the old password"
                : "برای تغییر رمز باید رمز عبور قدیمی را وارد کنید";

            validations.Add(new ValidationResult(passwordError, ["OldPassword"]));
        }

        
        if (!string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(ConfirmPassword) && Password != ConfirmPassword)
        {
            string passwordError = CultureInfo.CurrentUICulture.Name == "en-US"
                ? "The password and the password confirmation do not match"
                : "رمز عبور و تکرار رمز عبور یکسان نیستند";

            validations.Add(new ValidationResult(passwordError, ["Password", "ConfirmPassword"]));
        }

        return validations;
    }
}
