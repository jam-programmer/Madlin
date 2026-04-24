using Application.Common;
using Application.Common.CustomException;
using Application.DataTransferObject;
using Application.Services.BlogCategory;
using EndPoint_Ui.Areas.Admin.Models.BlogCategory;
using EndPoint_Ui.Areas.Admin.Models.Common;
using EndPoint_Ui.Attributes;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Areas.Admin.Controllers;

[Area("Admin")]
[AdminAuthorize("BlogCategory")]
public class BlogCategoryController : Controller
{
    readonly IBlogCategoryService _blogCategoryService;
    public BlogCategoryController(IBlogCategoryService blogCategoryService)
    {
        _blogCategoryService = blogCategoryService;
    }
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        PaginatedList<BlogCategoryDto> model=await _blogCategoryService
            .GetBlogCategoriesAsync(pagination);
        ViewBag.Keyword = pagination.keyword;
        return View(model.Adapt<PaginatedList<BlogCategoryViewModel>>());
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();  
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBlogCategoryModel model)
    {
        if (!ModelState.IsValid)
        { 
            return View(model);
        }
        try
        {
            await _blogCategoryService.InsertBlogCategoryAsync(model.Adapt<BlogCategoryDto>()); 
            return RedirectToAction(nameof(Index));
        }
        catch (InternalException ex) 
        {
            ViewBag.Alert=ex.Message;
            return View(model);
        }
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {
        BlogCategoryDto blogCategory=await _blogCategoryService.GetBlogCategoryByIdAsync(Id);
        return View(blogCategory.Adapt<EditBlogCategoryModel>());
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditBlogCategoryModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        try
        {
            await _blogCategoryService.UpdateBlogCategoryAsync(model.Adapt<BlogCategoryDto>());
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
            await _blogCategoryService.DeleteBlogCategoryAsync(input.Id);
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




}
