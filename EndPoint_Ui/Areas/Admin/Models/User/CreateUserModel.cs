using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.Admin.Models.User;

public record CreateUserModel
{
    [Required(ErrorMessage ="نام و نام خانوادگی الزامی است")]
    public string? FullName { get; set; }
    [Required(ErrorMessage = "کدملی الزامی است")]
    public string? UserName { get; set; }
    [Required(ErrorMessage = "پست الکترونیک الزامی است")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "شماره تماس الزامی است")]
    public string? PhoneNumber { get; set; }
    [Required(ErrorMessage = "گذر واژه الزامی است")]
    public string? Password { get; set; }
    [Required(ErrorMessage = "انتخاب نقش الزامی است")]
    public string? Role { get; set; }
    public bool IsActive { get; set; }
}
