using Application.DataTransferObject;
using Application.Services.SliderImage;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class SliderComponent:ViewComponent
{
    readonly ISliderImageService _sliderImageService;
    public SliderComponent(ISliderImageService sliderImageService)
    {
        _sliderImageService = sliderImageService;   
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        IReadOnlyList<SliderImageDto> images =
            await _sliderImageService.GetSliderImagesAsync();
        return View("/Views/Shared/ViewComponent/SliderComponent.cshtml",
            images.Adapt<IReadOnlyList<SliderImageViewModel>>());

    }
}
