using Application.DataTransferObject;
using Application.Services.Tag;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class TagsComponent:ViewComponent
{
    readonly ITagService _tagService;
    public TagsComponent(ITagService tagService)
    {
        _tagService = tagService;   
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        IReadOnlyList<TagDto> blogs =
            await _tagService.GetTagsAsync();
        return View("/Views/Shared/ViewComponent/TagsComponent.cshtml", 
            blogs.Adapt<IReadOnlyList<TagViewModel>>());

    }
}
