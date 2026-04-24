using Application.DataTransferObject;
using Application.Services.ProductCategory;
using Application.Services.Setting;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EndPoint_Ui.Components;

public class NewestProductCategoryComponent : ViewComponent
{
    readonly ISettingService _settingService;
    readonly IProductCategoryService _productCategoryService;
    public NewestProductCategoryComponent(IProductCategoryService productCategoryService, ISettingService settingService)
    {
        _settingService = settingService;
        _productCategoryService = productCategoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        SectionHeaderDto sectionHeaderDto = await _settingService.GetCategoryHeaderAsync();
        IReadOnlyList<ProductCategoryItemDto> productCategories
           = await _productCategoryService.GetNewestProductCategoriesForSliderAsync();

        ValueTuple<IReadOnlyList<ProductCategoryItemViewModel>, HeaderViewModel> model = 
            new(productCategories.Adapt<IReadOnlyList<ProductCategoryItemViewModel>>(), sectionHeaderDto.Adapt<HeaderViewModel>());
        return View("/Views/Shared/ViewComponent/NewestProductCategoryComponent.cshtml", model);
    }
}
