using Application.Common;
using Application.Common.CustomException;
using Application.DataTransferObject;
using Application.Services.Tag;
using EndPoint_Ui.Areas.Admin.Models.Common;
using EndPoint_Ui.Areas.Admin.Models.Tag;
using EndPoint_Ui.Attributes;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Areas.Admin.Controllers;
[Area("Admin")]
[AdminAuthorize("Tag")]

public class TagController : Controller
{
    readonly ITagService _tagService;
    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        ViewBag.Keyword = pagination.keyword;
        PaginatedList<TagDto> model=await _tagService.GetTagsAsync(pagination);
        return View(model.Adapt<PaginatedList<TagViewModel>>());
    }

    [HttpGet]
    public IActionResult Create() => View();
    [HttpPost]
    public async Task<IActionResult> Create(CreateTagModel model)
    {
        if (ModelState.IsValid is false) 
        {
            return View(model);
        }

        try
        {
            await _tagService.InsertTagAsync(model.Adapt<TagDto>());
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
        TagDto tag=await _tagService.GetTagByIdAsync(Id);
        return View(tag.Adapt<EditTagModel>());  
    }


    [HttpPost]
    public async Task<IActionResult> Edit(EditTagModel model)
    {
        if (ModelState.IsValid is false)
        {
            return View(model);
        }

        try
        {
            await _tagService.UpdateTagAsync(model.Adapt<TagDto>());
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
            await _tagService.DeleteTagAsync(input.Id);
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
