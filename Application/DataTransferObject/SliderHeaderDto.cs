using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject
{
    public sealed record SliderHeaderDto
    {
        public string? SliderTitleFa { get; set; }
        public string? SliderTitleEn { get; set; }


        public string? SliderTextFa { get; set; }
        public string? SliderTextEn { get; set; }
    }
}
