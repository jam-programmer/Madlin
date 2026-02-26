using Application.Common;
using Application.Common.CustomException;
using Application.DataTransferObject;
using Application.Services.ProductCategory;
using EndPoint_Ui.Areas.Admin.Models.Common;
using EndPoint_Ui.Areas.Admin.Models.ProductCategory;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Areas.Admin.Controllers;
[Area("Admin")]
public class ProductCategoryController (IProductCategoryService prodcutCategoryService): Controller
{
    readonly IProductCategoryService _productCategoryService=prodcutCategoryService;
    [HttpGet]   
    public async Task<IActionResult> Index([FromQuery]Pagination pagination)
    {
        ViewBag.Keyword = pagination.keyword;
        PaginatedList<ProductCategoryDto>model=await _productCategoryService
            .GetProductCategoriesAsync(pagination);
        return View(model.Adapt<PaginatedList<ProductCategoryViewModel>>());
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Alert = null;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCategoryModel model)
    {
        if (ModelState.IsValid is false)
        {
            return View(model);
        }
        try
        {
            ProductCategoryDto dto = new()
            {
                DescriptionEn = model.DescriptionEn,
                DescriptionFa = model.DescriptionFa,
                IconImageFile = model.IconImageFile,
                MainImageFile = model.MainImageFile,
                TitleEn = model.TitleEn,
                TitleFa = model.TitleFa,
                IsFeatured = model.IsFeatured,
            };
            await _productCategoryService.InsertProductCategoryAsync(dto);    
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
        ViewBag.Alert = null;
        ProductCategoryDto productCategory=
            await _productCategoryService.GetProductCategoryByIdAsync(Id);
        return View(productCategory.Adapt<EditProductCategoryModel>());
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditProductCategoryModel model)
    {
        if (ModelState.IsValid is false)
        {
            return View(model);
        }
        try
        {
            ProductCategoryDto dto = new()
            {
                DescriptionEn = model.DescriptionEn,
                DescriptionFa = model.DescriptionFa,
                IconImageFile = model.IconImageFile,
                MainImageFile = model.MainImageFile,
                TitleEn = model.TitleEn,
                TitleFa = model.TitleFa,
                IsFeatured = model.IsFeatured,
                IconImagePath = model.IconImagePath,    
                MainImagePath = model.MainImagePath,
                Id = model.Id
            };
            await _productCategoryService.UpdateProductCategoryAsync(dto);
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

            await _productCategoryService.DeleteProductCategoryAsync(input.Id);
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
