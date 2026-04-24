using Application.Common;
using Application.Common.CustomException;
using Application.DataTransferObject;
using Application.Services.Product;
using Application.Services.ProductCategory;
using EndPoint_Ui.Areas.Admin.Models.Common;
using EndPoint_Ui.Areas.Admin.Models.Product;
using EndPoint_Ui.Attributes;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Areas.Admin.Controllers;

[Area("Admin")]
[AdminAuthorize("Product")]
public class ProductController (IProductService productService,
    IProductCategoryService productCategoryService): Controller
{
    readonly IProductService _productService= productService;
    readonly IProductCategoryService _productCategoryService = productCategoryService;

    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        ViewBag.Keyword = pagination.keyword;   
        PaginatedList<ProductDto> model=await _productService
            .GetProductsAsync(pagination);
        return View(model.Adapt<PaginatedList<ProductViewModel>>());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        if (model.DiscountPrice != null && model.DiscountPrice > model.Price)
        {
            ViewBag.Alert = "قیمت با تخفیف نمیتواند از قیمت اصلی بیشتر باشد";
            return View(model);
        }

        try
        {
            ProductDto product = new()
            {
                IsShowSlider = model.IsShowSlider,
                Price = model.Price,
                CategoryId = model.CategoryId,
                HoverImageFile = model.HoverImageFile,
                MainImageFile = model.MainImageFile,
                Quantity = model.Quantity,
                DiscountPrice = model.DiscountPrice,
                ProductCode = model.ProductCode,
                Rating = model.Rating,
                UrlName = model.UrlName,
                TitleEn = model.TitleEn,
                TitleFa = model.TitleFa,
                ShortDescriptionEn = model.ShortDescriptionEn,
                ShortDescriptionFa = model.ShortDescriptionFa,
                FullDescriptionEn = model.FullDescriptionEn,
                FullDescriptionFa = model.FullDescriptionFa,
            };
            await _productService.InsertProductAsync(product);
            return RedirectToAction(nameof(Index));
        }
        catch (InternalException ex) 
        {
            ViewBag.Alert =ex.Message;
            return View(model);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        ProductDto product=await _productService.GetProductByIdAsync(id);
        return View(product.Adapt<EditProductModel>());
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditProductModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        if (model.DiscountPrice != null && model.DiscountPrice > model.Price)
        {
            ViewBag.Alert = "قیمت با تخفیف نمیتواند از قیمت اصلی بیشتر باشد";
            return View(model);
        }

        try
        {
            ProductDto product = new()
            {
                IsShowSlider = model.IsShowSlider,
                HoverImagePath =model.HoverImagePath,
                MainImagePath = model.MainImagePath,
                Id = model.Id,
                Price = model.Price,
                CategoryId = model.CategoryId,
                HoverImageFile = model.HoverImageFile,
                MainImageFile = model.MainImageFile,
                Quantity = model.Quantity,
                DiscountPrice = model.DiscountPrice,
                ProductCode = model.ProductCode,
                Rating = model.Rating,
                UrlName = model.UrlName,
                TitleEn = model.TitleEn,
                TitleFa = model.TitleFa,
                ShortDescriptionEn = model.ShortDescriptionEn,
                ShortDescriptionFa = model.ShortDescriptionFa,
                FullDescriptionEn = model.FullDescriptionEn,
                FullDescriptionFa = model.FullDescriptionFa,
            };
            await _productService.UpdateProductAsync(product);
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

            await _productService.DeleteProductAsync(input.Id);
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
    public async Task<JsonResult> GetCategories([FromQuery]string search)
    {
        var categories=await _productCategoryService.GetCategoriesForDropDownAsync(search);
        return Json(categories);
    }


}
