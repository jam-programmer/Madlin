using Application.Common;
using Application.DataTransferObject;
using Application.Services.SliderImage;
using EndPoint_Ui.Areas.Admin.Models.Common;
using EndPoint_Ui.Areas.Admin.Models.Slider;

using EndPoint_Ui.Attributes;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Areas.Admin.Controllers;
[Area("Admin")]
[AdminAuthorize("Slider")]
public class SliderController : Controller
{
    readonly ISliderImageService _SliderImageService;
    public SliderController(ISliderImageService SliderImageService)
    {
        _SliderImageService = SliderImageService;
    }
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        ViewBag.Keyword = pagination.keyword;
        PaginatedList<SliderImageDto> model = await _SliderImageService.
            GetSliderImagesAsync(pagination);
        return View(model.Adapt<PaginatedList<SliderImageViewModel>>());
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Alert = null;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSliderImageModel model)
    {
        if (ModelState.IsValid is false)
        {
            return View(model);
        }
        try
        {
            await _SliderImageService.InsertSliderImageAsync(model.Adapt<SliderImageDto>());
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
        SliderImageDto SliderImage = await _SliderImageService.GetSliderImageByIdAsync(Id);
        return View(SliderImage.Adapt<EditSliderImageModel>());
    }
    [HttpPost]
    public async Task<IActionResult> Edit(EditSliderImageModel model)
    {
        if (ModelState.IsValid is false)
        {
            return View(model);
        }
        try
        {
            await _SliderImageService.UpdateSliderImageAsync(model.Adapt<SliderImageDto>());
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

            await _SliderImageService.DeleteSliderImageAsync(input.Id);
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
