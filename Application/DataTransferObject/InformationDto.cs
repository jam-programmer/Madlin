using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject;

public sealed record InformationDto
{
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? AddressFa { get; set; }
    public string? AddressEn { get; set; }
    public string? Telegram { get; set; }
    public string? WhatsApp { get; set; }
    public string? Instagram { get; set; }
    public string? Linkedin { get; set; }
}
