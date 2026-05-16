using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Sms;

public interface ISmsService
{
    Task SendSmsWithExclusiveNumberAsync(ExclusiveNumberDto model);
    Task SendSmsWithGeneralNumberAsync(GeneralNumberDto model);
}
