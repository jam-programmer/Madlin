using Application.DataTransferObject;
using Application.Services.Setting;
using EndPoint_Ui.Models;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class SliderBannerComponent:ViewComponent
{
    readonly ISettingService _settingService;
    public SliderBannerComponent(ISettingService settingService)
    {
        _settingService = settingService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        string banner
            = await _settingService.GetSliderBannerAsync();
        return View("/Views/Shared/ViewComponent/SliderBannerComponent.cshtml", banner);

    }
}
