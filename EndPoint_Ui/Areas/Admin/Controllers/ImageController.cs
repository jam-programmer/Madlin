using Application.Common;
using Application.Common.CustomException;
using Application.DataTransferObject;
using Application.Services.Image;
using EndPoint_Ui.Areas.Admin.Models.Common;
using EndPoint_Ui.Areas.Admin.Models.Image;
using EndPoint_Ui.Attributes;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Areas.Admin.Controllers;
[Area("Admin")]
[AdminAuthorize("Image")]
public class ImageController : Controller
{
    readonly IImageService _imageService;
    public ImageController(IImageService imageService)
    {
        _imageService = imageService;
    }
    public async Task<IActionResult> Index()
    {
        IReadOnlyList<ImageDto> images=
            await _imageService.GetImagesAsync();
        return View(images.Adapt<IReadOnlyList<ImageViewModel>>());
    }
    [HttpGet]
    public IActionResult Create() => View();



    [HttpPost]
    public async Task<IActionResult>Create(CreateImageModel model)
    {
        if (!ModelState.IsValid) 
        {
            return View(model); 
        }
        try
        {
            await _imageService.InsertImageAsync(new ImageDto()
            {
                File = model.File,
            });
            return RedirectToAction(nameof(Index)); 
        }
        catch (InternalException ex)
        {   
            ViewBag.Alert=ex.Message; return View(model);
		}
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] DeleteModel input)
    {
        try
        {

            await _imageService.DeleteImageAsync(input.Id);
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
