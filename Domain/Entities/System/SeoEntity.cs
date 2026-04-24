using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.System;

public class SeoEntity : BaseEntity
{
    public string? OgTitleFa { get; set; }
    public string? OgTitleEn { get; set; }
    public string? OgType { get; set; }
    public string? OgUrl { get; set; }
    public string? OgImage { get; set; }
    public string? OgDescriptionFa { get; set; }
    public string? OgDescriptionEn { get; set; }
    public string? TwitterTitleEn { get; set; }
    public string? TwitterDescriptionEn { get; set; }
    public string? TwitterTitleFa { get; set; }
    public string? TwitterDescriptionFa { get; set; }
    public string? TwitterImage { get; set; }
    public int? Robots { get; set; }
    public string? ThemeColor { get; set; }
    public string? KeywordsEn { get; set; }
    public string? KeywordsFa { get; set; }
    public string? Canonical { get; set; }
    public string? TitleFa { get; set; }
    public string? DescriptionFa { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionEn { get; set; }

}
