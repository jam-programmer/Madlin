using Application.DataTransferObject;
using Application.Services.Tag;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class BlogTagsComponent:ViewComponent
{
    readonly ITagService _tagService;
    public BlogTagsComponent(ITagService tagService)
    {
        _tagService = tagService;
    }
    public async Task<IViewComponentResult> InvokeAsync(Guid Id)
    {
        IReadOnlyList<TagDto> blogs =
            await _tagService.GetTagsByBlogIdAsync(Id);
        return View("/Views/Shared/ViewComponent/BlogTagsComponent.cshtml",
            blogs.Adapt<IReadOnlyList<TagViewModel>>());

    }
}
