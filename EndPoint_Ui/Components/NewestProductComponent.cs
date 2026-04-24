using Application.DataTransferObject;
using Application.Services.Product;
using Application.Services.Setting;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EndPoint_Ui.Components;

public class NewestProductComponent : ViewComponent
{
    readonly ISettingService _settingService;
    readonly IProductService _productService;
    public NewestProductComponent(IProductService productService, ISettingService settingService)
    {
        _settingService = settingService;
        _productService = productService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        SectionHeaderDto sectionHeader = await _settingService.GetProductHeaderAsync();

        IReadOnlyList<ProductItemDto> products
           = await _productService.GetNewestProductsAsync();


        ValueTuple<IReadOnlyList<CardProductViewModel>, HeaderViewModel> model

            = new(products.Adapt < IReadOnlyList<CardProductViewModel>>(),
            sectionHeader.Adapt<HeaderViewModel>());



        return View("/Views/Shared/ViewComponent/NewestProductComponent.cshtml",
            model);
    }
}
