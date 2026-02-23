using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.Admin.Models.User;

public sealed record EditUserModel : CreateUserModel, IValidatableObject
{
    public Guid Id { get; set; }
    public string? OldPassword { get; set; }
    public new string? Password { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
           List<ValidationResult> errors = new();
        if (string.IsNullOrEmpty(OldPassword) is false && string.IsNullOrEmpty(Password))
        {
            errors.Add(new ValidationResult("برای تغییر گذرواژه، گذرواژه قدیم را وارد کنید", new[] { "OldPassword" }));
            errors.Add(new ValidationResult("گذرواژه جدید را وارد کنید", new[] { "Password" }));
        }
        if (string.IsNullOrEmpty(OldPassword)&& string.IsNullOrEmpty(Password) is false)
        {
            errors.Add(new ValidationResult("گذرواژه جدید را وارد کنید", new[] { "Password" }));
            errors.Add(new ValidationResult("برای تغییر گذرواژه، گذرواژه قدیم را وارد کنید", new[] { "OldPassword" }));
        }
        return errors;
    }
}
