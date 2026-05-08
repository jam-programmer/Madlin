using Application.Common;
using Application.Common.Extension;
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
        DateTime Start = model.Start!.ConvertToGregorian();
        DateTime End = model.End!.ConvertToGregorian();
        if (Start > End)
        {
            ViewBag.Alert = "تاریخ شروع نمیتواند بزرگتر از تاریخ پایان باشد";
            return View(model);
        }
        try
        {

          


            await _SliderImageService.InsertSliderImageAsync(new SliderImageDto()
            {
                File= model.File,   
                Link= model.Link,
                Start= Start,
                End= End,
                Title=model.Title
            
            });
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
        EditSliderImageModel model =new();
        model.Id=Id;
        model.Title=SliderImage.Title;
        model.Link=SliderImage.Link;
        model.Path=SliderImage.Path;
        model.Start = SliderImage.Start!.Value.PersianDateWithOutTime();
        model.End = SliderImage.End!.Value.PersianDateWithOutTime();
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(EditSliderImageModel model)
    {
        if (ModelState.IsValid is false)
        {
            return View(model);
        }
        DateTime Start = model.Start!.ConvertToGregorian();
        DateTime End = model.End!.ConvertToGregorian();
        if (Start > End)
        {
            ViewBag.Alert = "تاریخ شروع نمیتواند بزرگتر از تاریخ پایان باشد";
            return View(model);
        }
        try
        {

            await _SliderImageService.UpdateSliderImageAsync(new SliderImageDto()
            {
                File = model.File,
                Link = model.Link,
                Start = Start,
                End = End,
                Title = model.Title,
                Path=model.Path,
                Id=model.Id
            });
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
