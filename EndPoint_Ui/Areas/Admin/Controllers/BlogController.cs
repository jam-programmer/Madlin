using Application.Common;
using Application.Common.CustomException;
using Application.DataTransferObject;
using Application.Services.Blog;
using Application.Services.BlogCategory;
using Application.Services.Tag;
using EndPoint_Ui.Areas.Admin.Models.Blog;
using EndPoint_Ui.Areas.Admin.Models.Common;
using EndPoint_Ui.Attributes;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Areas.Admin.Controllers;
[Area("Admin")]
[AdminAuthorize("Blog")]
public class BlogController : Controller
{
    readonly ITagService _tagService;
    readonly IBlogCategoryService _blogCategoryService;
    readonly IBlogService _blogService;
    public BlogController(IBlogService blogService,
        IBlogCategoryService blogCategoryService, ITagService tagService)
    {
        _blogCategoryService = blogCategoryService;
        _blogService = blogService;
        _tagService = tagService;
    }
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        PaginatedList<BlogDto> model = await _blogService.GetBlogsAsync(pagination);
        ViewBag.Keyword = pagination.keyword;
        return View(model.Adapt<PaginatedList<BlogViewModel>>());
    }

    [HttpGet]
    public IActionResult Create() => View();
    [HttpPost]
    public async Task<IActionResult> Create(CreateBlogModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        try
        {
            await _blogService.InsertBlogAsync(new BlogDto()
            {
                CategoryId = model.CategoryId,
                TitleEn = model.TitleEn,
                TitleFa = model.TitleFa,
                UrlName = model.UrlName,
                ImageFile = model.ImageFile,
                DescriptionEn = model.DescriptionEn,
                DescriptionFa = model.DescriptionFa,
                ShortDescriptionEn = model.ShortDescriptionEn,
                ShortDescriptionFa = model.ShortDescriptionFa,
                Tags = model.Tags,
                UserId = Guid.Parse(User.Claims!.FirstOrDefault(f => f.Type == "Id").Value!)
            });
            return RedirectToAction(nameof(Index));
        }
        catch (InternalException ex)
        {
            ViewBag.Alert = ex.Message;
            return View(model);
        }
    }


    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {
        BlogDto blog = await _blogService.GetBlogAsync(Id);

        return View(blog.Adapt<EditBlogModel>());
    }
    [HttpPost]
    public async Task<IActionResult> Edit(EditBlogModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        try
        {
            await _blogService.UpdateBlogAsync(new BlogDto()
            {
                CategoryId = model.CategoryId,
                TitleEn = model.TitleEn,
                TitleFa = model.TitleFa,
                UrlName = model.UrlName,
                ImageFile = model.ImageFile,
                ShortDescriptionEn = model.ShortDescriptionEn,
                ShortDescriptionFa = model.ShortDescriptionFa,
                DescriptionEn = model.DescriptionEn,
                DescriptionFa = model.DescriptionFa,
                Tags = model.Tags,
                UserId = Guid.Parse(User.Claims!.FirstOrDefault(f => f.Type == "Id").Value!),
                Id = model.Id,
                ImagePath = model.ImagePath,
            });
            return RedirectToAction(nameof(Index));
        }
        catch (InternalException ex)
        {
            ViewBag.Alert = ex.Message;
            return View(model);
        }
    }


    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] DeleteModel input)
    {
        try
        {

            await _blogService.DeleteBlogAsync(input.Id);
            return new JsonResult(new
            {
                IsSuccess = true,
                Message = string.Empty,
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                IsSuccess = false,
                Message = ex.Message,
            });
        }
    }
    public async Task<JsonResult> GetCategories([FromQuery] string search)
    {
        var categories = await _blogCategoryService.GetCategoriesForDropDownAsync(search);
        return Json(categories);
    }
    public async Task<JsonResult> GetTags([FromQuery] string search)
    {
        var tags = await _tagService.GetTagsForDropDownAsync(search);
        return Json(tags);
    }
    public async Task<JsonResult> GetSelectedTags([FromQuery] Guid Id)
    {
        var tags = await _blogService.GetTagsByBlogIdAsync(Id);
        var result = tags.Select(s => new
        {
            id = s.Id,
            text = s.Title
        });
        return Json(result);
    }
}
