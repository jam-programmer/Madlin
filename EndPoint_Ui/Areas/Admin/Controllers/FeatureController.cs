using Application.Common;
using Application.Common.CustomException;
using Application.DataTransferObject;
using Application.Services.Feature;
using EndPoint_Ui.Areas.Admin.Models.Common;
using EndPoint_Ui.Areas.Admin.Models.Feature;
using EndPoint_Ui.Attributes;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using NPOI.POIFS.Properties;

namespace EndPoint_Ui.Areas.Admin.Controllers;
[Area("Admin")]
[AdminAuthorize("Product")]

public class FeatureController : Controller
{
    readonly IFeatureService _featureService;
    public FeatureController(IFeatureService featureService)
    {
        _featureService= featureService;
    }
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] PaginationWithParent pagination)
    {
        PaginatedList<FeatureDto> model=await _featureService.GetFeaturesAsync(pagination);
        ViewBag.Keyword = pagination.keyword;
        ViewBag.ParentId = pagination.ParentId;
        return View(model.Adapt<PaginatedList<FeatureViewModel>>());
    }
    [HttpGet]
    public IActionResult Create(Guid ParentId)
    {
        ViewBag.ParentId=ParentId;
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateFeatureModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.ParentId = model.ProductId;
            return View(model);
        }
        try
        {
            await _featureService.InsertFeatureAsync(model.Adapt<FeatureDto>());
            return RedirectToAction(nameof(Index), new {ParentId=model.ProductId});    
        }
        catch (InternalException ex)
        {
            ViewBag.ParentId = model.ProductId;
            ViewBag.Alert = ex.Message;
            return View(model);
        }
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {
        FeatureDto feature=await _featureService
            .GetFeatureByIdAsync(Id);
        EditFeatureModel pageModel=feature.Adapt<EditFeatureModel>();
        return View(pageModel);  
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditFeatureModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        try
        {
            await _featureService.UpdateFeatureAsync(model.Adapt<FeatureDto>());
            return RedirectToAction(nameof(Index), new { ParentId = model.ProductId });
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
            await _featureService.DeleteFeatureAsync(input.Id);
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
