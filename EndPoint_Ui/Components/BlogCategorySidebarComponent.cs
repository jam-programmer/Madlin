using Application.DataTransferObject;
using Application.Services.BlogCategory;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class BlogCategorySidebarComponent:ViewComponent
{
    readonly IBlogCategoryService _blogCategoryService;
    public BlogCategorySidebarComponent(IBlogCategoryService blogCategoryService)
    {
        _blogCategoryService = blogCategoryService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        IReadOnlyList<BlogCategoryDto> categories =
            await _blogCategoryService.GetBlogCategoriesAsync();
        return View("/Views/Shared/ViewComponent/BlogCategorySidebarComponent.cshtml",
            categories.Adapt<IReadOnlyList<BlogCategoryViewModel>>());

    }
}
