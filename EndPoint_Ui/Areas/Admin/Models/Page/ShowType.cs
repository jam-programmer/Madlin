using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.Admin.Models.Page
{
    public enum ShowType
    {
        [Display(Name ="عدم نمایش")]
        None = 0,
        [Display(Name = "منو پابرگ")]
        Footer = 1,
        [Display(Name = "منو سربرگ")]
        Header = 2,
    }
}
