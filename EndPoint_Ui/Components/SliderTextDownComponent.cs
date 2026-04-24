using Application.DataTransferObject;
using Application.Services.Setting;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class SliderTextDownComponent:ViewComponent
{
    readonly ISettingService _settingService;
    public SliderTextDownComponent(ISettingService settingService)
    {
        _settingService = settingService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        SliderTextDownDto slider
            = await _settingService.GetSliderTextDownAsync();
        return View("/Views/Shared/ViewComponent/SliderTextDownComponent.cshtml",
            slider.Adapt<SliderTextDownViewModel>());

    }
}
