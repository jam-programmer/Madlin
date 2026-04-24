using Application.DataTransferObject;
using Application.Services.Setting;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class SliderTextTopComponent : ViewComponent
{
    readonly ISettingService _settingService;
    public SliderTextTopComponent(ISettingService settingService)
    {
        _settingService = settingService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        SliderTextTopDto slider
            = await _settingService.GetSliderTextTopAsync();
        return View("/Views/Shared/ViewComponent/SliderTextTopComponent.cshtml",
            slider.Adapt<SliderTextTopViewModel>());

    }
}
