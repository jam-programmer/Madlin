using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.Admin.Models.Sms;

public sealed record GeneralNumberModel
{
    [Required(ErrorMessage ="شناسه قالب الزامی است")]
    public int TemplateCode { get; set; }
    [Required(ErrorMessage = "شماره گیرنده الزامی است")]

    public string? PhoneNumber { get; set; }
    [Required(ErrorMessage = "حداقل یک پارامتر الزامی است")]

    public List<SmsParameter>? Parameters { get; set; }  

}
public sealed record SmsParameter
{
    public string? Key { get; set; }
    public string? Value { get; set; }
}
