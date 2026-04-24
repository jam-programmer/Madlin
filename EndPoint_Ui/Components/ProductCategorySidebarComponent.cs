using Application.DataTransferObject;
using Application.Services.ProductCategory;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class ProductCategorySidebarComponent:ViewComponent
{
    readonly IProductCategoryService _productCategoryService;
    public ProductCategorySidebarComponent(IProductCategoryService productCategoryService)
    {
        _productCategoryService = productCategoryService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        IReadOnlyList<ProductCategoryItemDto> data = await _productCategoryService.GetProductCategoriesForFilterAsync();  
        return View("/Views/Shared/ViewComponent/ProductCategorySidebarComponent.cshtml",
            data.Adapt<IReadOnlyList<ProductCategoryItemViewModel>>());

    }
}
