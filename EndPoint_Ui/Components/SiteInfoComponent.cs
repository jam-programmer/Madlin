using Application.DataTransferObject;
using Application.Services.Setting;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class SiteInfoComponent:ViewComponent
{
    readonly ISettingService _settingService;
    public SiteInfoComponent(ISettingService settingService)
    {
        _settingService = settingService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        SiteInfoDto model
            = await _settingService.GetSiteInfoAsync();
        return View("/Views/Shared/ViewComponent/SiteInfoComponent.cshtml", model.Adapt<SiteInfoViewModel>());

    }
}
