using Application.Services.Setting;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class MetaHeaderComponent : ViewComponent
{
    readonly ISettingService _settingService;
    public MetaHeaderComponent(ISettingService settingService)
    {
        _settingService = settingService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        string model = await _settingService.GetHeaderAsync();

        return View("/Views/Shared/ViewComponent/MetaHeaderComponent.cshtml", model);
    }
}
