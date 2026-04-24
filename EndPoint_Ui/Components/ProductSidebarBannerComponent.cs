using Application.Services.Setting;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class ProductSidebarBannerComponent: ViewComponent
{
    readonly ISettingService _settingService;
    public ProductSidebarBannerComponent(ISettingService settingService)
    {
        _settingService = settingService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        string bannerPath = await _settingService.GetBannerForProductsSidebarAsync();
        return View("/Views/Shared/ViewComponent/ProductSidebarBannerComponent.cshtml", bannerPath);

    }
}
