using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.System;

public class AboutEntity:BaseEntity
{
    public string? ImagePath { get; set; }   
    public string? TextEn {  get; set; }
    public string? TextFa {  get; set; }
}
