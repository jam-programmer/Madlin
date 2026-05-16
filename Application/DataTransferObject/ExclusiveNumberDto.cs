using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject
{
    public class ExclusiveNumberDto
    {
        public string? Message { get; set; }
        public string[] PhoneNumbers { get; set; }
    }
}
