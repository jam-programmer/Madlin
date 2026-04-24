using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject;

public sealed record SiteInfoDto
{
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
    public string? FaviconPath { get; set; }
}
