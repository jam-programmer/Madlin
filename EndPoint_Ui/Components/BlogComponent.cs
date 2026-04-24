using Application.DataTransferObject;
using Application.Services.Blog;
using Application.Services.Setting;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EndPoint_Ui.Components;

public class BlogComponent : ViewComponent
{
    readonly ISettingService _settingService;
    readonly IBlogService _blogService;
    public BlogComponent(IBlogService blogService, ISettingService settingService)
    {
        _blogService = blogService;
        _settingService = settingService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        SectionHeaderDto sectionHeader = await _settingService.GetBlogHeaderAsync();

        IReadOnlyList<BlogItemDto> blogs = await _blogService.GetNewestBlogsAsync(3);
        ValueTuple<IReadOnlyList<BlogViewModel>, HeaderViewModel> model =
            new(blogs.Adapt<IReadOnlyList<BlogViewModel>>(), sectionHeader.Adapt<HeaderViewModel>());

        return View("/Views/Shared/ViewComponent/BlogComponent.cshtml", model);

    }
}
