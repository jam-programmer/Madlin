using Application.Common.CustomException;
using Application.DataTransferObject;
using Application.Services.Picture;
using EndPoint_Ui.Areas.Admin.Models.Common;
using EndPoint_Ui.Areas.Admin.Models.Picture;
using EndPoint_Ui.Attributes;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Areas.Admin.Controllers;

[Area("Admin")]
[AdminAuthorize("Product")]
public class PictureController : Controller
{
    readonly IPictureService _pictureService;
    public PictureController(IPictureService pictureService)
    {
        _pictureService = pictureService;
    }
    [HttpGet]
    public async Task<IActionResult> Index(Guid ParentId)
    {
        IReadOnlyList<PictureDto> model = await _pictureService.GetPictureAsync(ParentId);

        ViewBag.ParentId = ParentId;
        return View(model.Adapt<IReadOnlyList<EndPoint_Ui.Areas.Admin.Models.PictureViewModel>>());
    }
    [HttpGet]
    public IActionResult Create(Guid ParentId)
    {
        ViewBag.ParentId = ParentId;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePictureModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.ParentId = model.ProductId;
            return View(model);
        }
        try
        {

            PictureDto pictureDto = new()
            {
                File = model.File,
                ProductId = model.ProductId
            };
            await _pictureService.InsertPictureAsync(pictureDto);
            return RedirectToAction(nameof(Index), new { ParentId = model.ProductId });
        }
        catch (InternalException ex)
        {
            ViewBag.ParentId = model.ProductId;
            ViewBag.Alert = ex.Message;
            return View(model);
        }
    }



    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] DeleteModel input)
    {
        try
        {
            await _pictureService.DeletePictureAsync(input.Id);
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
