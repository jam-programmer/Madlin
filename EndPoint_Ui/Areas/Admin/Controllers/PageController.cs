using Application.Common;
using Application.DataTransferObject;
using Application.Services.Page;
using Mapster;
using EndPoint_Ui.Areas.Admin.Models.Common;
using EndPoint_Ui.Areas.Admin.Models.Page;
using EndPoint_Ui.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Areas.Admin.Controllers;
[Area("Admin")]
[AdminAuthorize("Page")]
public class PageController : Controller
{
    readonly IPageService _pageService;
    public PageController(IPageService pageService)
    {
        _pageService = pageService; 
    }
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        ViewBag.Keyword = pagination.keyword;
        PaginatedList<PageDto> model = await _pageService.
            GetPagesAsync(pagination);
        return View(model.Adapt<PaginatedList<PageViewModel>>());
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Alert = null;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePageModel model)
    {
        if (ModelState.IsValid is false)
        {
            return View(model);
        }
        try
        {
            await _pageService.InsertPageAsync(model.Adapt<PageDto>());
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {

            ViewBag.Alert = ex.Message;
            return View(model);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {
        ViewBag.Alert = null;
        PageDto Page = await _pageService.GetPageByIdAsync(Id);
        return View(Page.Adapt<EditPageModel>());
    }
    [HttpPost]
    public async Task<IActionResult> Edit(EditPageModel model)
    {
        if (ModelState.IsValid is false)
        {
            return View(model);
        }
        try
        {
            await _pageService.UpdatePageAsync(model.Adapt<PageDto>());
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
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

            await _pageService.DeletePageAsync(input.Id);
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
