using Application.DataTransferObject;
using Application.Services.ProductCategory;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class FeaturedProductCategoryComponent:ViewComponent
{
    readonly IProductCategoryService _productCategoryService;
    public FeaturedProductCategoryComponent(IProductCategoryService productCategoryService)
    {
        _productCategoryService = productCategoryService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        IReadOnlyList<FeaturedProductCategoryDto> model
            = await _productCategoryService.GetFeaturedProductCategoriesAsync();
        return View("/Views/Shared/ViewComponent/FeaturedProductCategoryComponent.cshtml", 
            model.Adapt<IReadOnlyList<FeaturedProductCategoryViewModel>>());

    }
}
