using Application.DataTransferObject;
using Application.Services.Blog;
using Application.Services.Setting;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class BlogSidebarBannerComponent:ViewComponent
{
    readonly ISettingService _settingService;
    public BlogSidebarBannerComponent(ISettingService settingService)
    {
        _settingService = settingService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        string bannerPath = await _settingService.GetBannerForBlogsSidebarAsync();
        return View("/Views/Shared/ViewComponent/BlogSidebarBannerComponent.cshtml", bannerPath);

    }
}
