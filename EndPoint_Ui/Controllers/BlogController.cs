using Application.Common;
using Application.DataTransferObject;
using Application.Services.Blog;
using Application.Services.BlogCategory;
using Application.Services.Tag;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Controllers;

public class BlogController : Controller
{
    readonly ITagService _tagService;
    readonly IBlogCategoryService _blogCategoryService;
    readonly IBlogService _blogService;
    public BlogController(IBlogService blogService,ITagService tagService, IBlogCategoryService blogCategoryService)
    {
        _tagService = tagService;
        _blogService = blogService;
        _blogCategoryService = blogCategoryService;
    }
    [Route("/Blogs")]
    public async Task<IActionResult> Blogs(int currentPage = 1,
        int pageSize = 12, string search = null)
    {
        PaginatedList<BlogItemDto> blogs =
            await _blogService.GetBlogsForBlogListPageAsync(new Pagination()
            {
                currentPage = currentPage,
                pageSize = pageSize,
                keyword = search
            });
        return View(blogs.Adapt<PaginatedList<BlogViewModel>>());
    }



  
    [Route("/Blog/Category/{UrlName}")]
    public async Task<IActionResult> Category
        (string UrlName, int currentPage = 1, int pageSize = 12, string search = null)
    {
        PaginationWithKey pagination = new PaginationWithKey();
        pagination.Key = UrlName;
        pagination.keyword=search;
        pagination.pageSize = pageSize;
        pagination.currentPage = currentPage;
        ViewBag.UrlName = UrlName;
        ViewBag.Keyword = search;
        PaginatedList<BlogItemDto> blogs =
            await _blogService.GetBlogsByCategoryUrlNamAsync(pagination);
        BlogCategoryDto category = await _blogCategoryService.GetBlogCategoryByUrlNameAsync(UrlName);   
        ValueTuple<PaginatedList<BlogViewModel>, BlogCategoryViewModel> model = new();
        model.Item1 = blogs.Adapt<PaginatedList<BlogViewModel>>();
        model.Item2 = category.Adapt<BlogCategoryViewModel>();
        return View(model);
    }

    [Route("/Blog/Tag/{TagKey}")]
    public async Task<IActionResult> Tag
        (string TagKey, int currentPage = 1, int pageSize = 12, string search = null)
    {
        PaginationWithKey pagination = new PaginationWithKey();
        pagination.Key = TagKey;
        pagination.keyword = search;
        pagination.pageSize = pageSize;
        pagination.currentPage = currentPage;
        ViewBag.TagKey = TagKey;
        ViewBag.Keyword = search;

        PaginatedList<BlogItemDto> blogs =
            await _blogService.GetBlogsByTagAsync(pagination);
        TagDto tag = await _tagService.GetTagByKeyAsync(TagKey);
        ValueTuple<PaginatedList<BlogViewModel>, TagViewModel> model = new();
        model.Item1 = blogs.Adapt<PaginatedList<BlogViewModel>>();
        model.Item2 = tag.Adapt<TagViewModel>();
        return View(model);
    }


    [Route("/Blog/Detail/{UrlName}")]
    public async Task<IActionResult>Detail(string UrlName)
    {
        BlogDetailDto blogDetailDto=await _blogService.GetBlogByUrlNameAsync(UrlName);  
        return View(blogDetailDto.Adapt<BlogDetailViewModel>());
    }
}
