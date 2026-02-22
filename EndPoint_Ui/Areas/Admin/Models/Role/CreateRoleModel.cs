using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.Admin.Models.Role;

public  record CreateRoleModel
{
    [Required(ErrorMessage ="نام سیستمی نقش الزامی است")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "نام نقش الزامی است")]
    public string? PersianName { get; set; }
    public bool IsCustomer { get; set; }
}
