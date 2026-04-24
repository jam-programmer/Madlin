using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject;

public sealed record SocialDto
{
    public string? Telegram { get; set; }
    public string? WhatsApp { get; set; }
    public string? Instagram { get; set; }
    public string? Linkedin { get; set; }
}
