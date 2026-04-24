using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject
{
    public sealed record SliderTextDownDto
    {
        public string? TextOneSliderDownFa { get; set; }
        public string? TextTwoSliderDownFa { get; set; }
        public string? TextThreeSliderDownFa { get; set; }

        public string? TextOneSliderDownEn { get; set; }
        public string? TextTwoSliderDownEn { get; set; }
        public string? TextThreeSliderDownEn { get; set; }
    }
}
