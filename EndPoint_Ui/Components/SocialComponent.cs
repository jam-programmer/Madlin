using Application.DataTransferObject;
using Application.Services.Setting;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class SocialComponent:ViewComponent
{
    readonly ISettingService _settingService;
    public SocialComponent(ISettingService settingService)
    {
        _settingService = settingService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        SocialDto footer
            = await _settingService.GetSocialsAsync();
        return View("/Views/Shared/ViewComponent/SocialComponent.cshtml", footer.Adapt<SocialViewModel>());

    }
}
