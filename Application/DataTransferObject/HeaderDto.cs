using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject;

public sealed record HeaderDto
{
    public string? CategoryTitleFa { get; set; }
    public string? CategoryTitleEn { get; set; }

    public string? ProductTitleFa { get; set; }
    public string? ProductTitleEn { get; set; }

    public string? BlogTitleFa { get; set; }
    public string? BlogTitleEn { get; set; }

    public string? SliderTitleFa { get; set; }
    public string? SliderTitleEn { get; set; }


    public string? SliderTextFa { get; set; }
    public string? SliderTextEn { get; set; }


    public string? GalleryTitleFa { get; set; }
    public string? GalleryTitleEn { get; set; }



    public string? TextOneSliderTopFa { get; set; }
    public string? TextTwoSliderTopFa { get; set; }
    public string? TextThreeSliderTopFa { get; set; }

    public string? TextOneSliderTopEn { get; set; }
    public string? TextTwoSliderTopEn { get; set; }
    public string? TextThreeSliderTopEn { get; set; }



    public string? TextOneSliderDownFa { get; set; }
    public string? TextTwoSliderDownFa { get; set; }
    public string? TextThreeSliderDownFa { get; set; }

    public string? TextOneSliderDownEn { get; set; }
    public string? TextTwoSliderDownEn { get; set; }
    public string? TextThreeSliderDownEn { get; set; }
}
