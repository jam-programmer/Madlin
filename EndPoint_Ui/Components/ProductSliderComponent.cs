using Application.DataTransferObject;
using Application.Services.Product;
using Application.Services.Setting;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EndPoint_Ui.Components;

public class ProductSliderComponent : ViewComponent
{
    readonly ISettingService _settingService;
    readonly IProductService _productService;
    public ProductSliderComponent(IProductService productService, ISettingService settingService)
    {
        _productService = productService;
        _settingService = settingService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        SliderHeaderDto sliderHeaderDto = await _settingService.GetSliderHeaderAsync();

        IReadOnlyList<ProductItemDto> products
           = await _productService.GetProductsForSliderAsync();

        ValueTuple<IReadOnlyList<CardProductViewModel>, SliderHeaderViewModel> model =
            new(products.Adapt<IReadOnlyList<CardProductViewModel>>(), sliderHeaderDto.Adapt<SliderHeaderViewModel>());

        return View("/Views/Shared/ViewComponent/ProductSliderComponent.cshtml",
            model);
    }
}
