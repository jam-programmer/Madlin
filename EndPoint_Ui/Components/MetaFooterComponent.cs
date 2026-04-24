using Application.DataTransferObject;
using Application.Services.Setting;
using EndPoint_Ui.Models;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class MetaFooterComponent:ViewComponent
{
    readonly ISettingService _settingService;
    public MetaFooterComponent(ISettingService settingService)
    {
        _settingService = settingService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        string model = await _settingService.GetFooterAsync();

        return View("/Views/Shared/ViewComponent/MetaFooterComponent.cshtml", model);
    }
}
