using Application.DataTransferObject;
using Application.Services.Setting;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class AdvertisingBannerComponent:ViewComponent
{
    readonly ISettingService _settingService;
    public AdvertisingBannerComponent(ISettingService settingService)
    {
        _settingService = settingService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        AdvertisingBannerDto AdvertisingBanner
            = await _settingService.GetAdvertisingBannerAsync();
        return View("/Views/Shared/ViewComponent/AdvertisingBannerComponent.cshtml", 
            AdvertisingBanner.Adapt<AdvertisingBannerViewModel>());

    }
}
