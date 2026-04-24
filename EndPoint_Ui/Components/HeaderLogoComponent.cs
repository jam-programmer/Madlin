using Application.DataTransferObject;
using Application.Services.Setting;
using EndPoint_Ui.Models;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class HeaderLogoComponent:ViewComponent
{
    readonly ISettingService _settingService;
    public HeaderLogoComponent(ISettingService settingService)
    {
        _settingService = settingService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        string logoPath
            = await _settingService.GetLogoAsync();
        return View("/Views/Shared/ViewComponent/HeaderLogoComponent.cshtml", logoPath);

    }
}
