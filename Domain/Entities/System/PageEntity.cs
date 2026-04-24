using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.System;

public class PageEntity : BaseEntity, IDelete
{
    public string? TitleEn {  get; set; }
    public string? TitleFa {  get; set; }
    public string? TextEn {  get; set; }
    public string? TextFa {  get; set; }
    public int Show {  get; set; }  
    public string? Url {  get; set; }
    public bool IsDeleted { get; set; }=false;  
}
