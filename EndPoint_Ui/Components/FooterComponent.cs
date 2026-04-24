using Application.DataTransferObject;
using Application.Services.Setting;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class FooterComponent:ViewComponent
{
    readonly ISettingService _settingService;
    public FooterComponent(ISettingService settingService)
    {
        _settingService = settingService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        FooterDto footer
            =await _settingService.GetFooterInformationAsync();
        return View("/Views/Shared/ViewComponent/FooterComponent.cshtml", footer.Adapt<FooterViewModel>());

    }
}
