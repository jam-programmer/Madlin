using Application.DataTransferObject;
using Application.Services.Setting;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;

namespace EndPoint_Ui.Components;

public class ContactInformationComponent:ViewComponent
{
    readonly ISettingService _settingService;
    public ContactInformationComponent(ISettingService settingService)
    {
        _settingService = settingService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        ContactInformationDto model = await _settingService.GetContactInformationAsync();

      
        return View("/Views/Shared/ViewComponent/ContactInformationComponent.cshtml", 
            model.Adapt<ContactInformationViewModel>());

    }
}
