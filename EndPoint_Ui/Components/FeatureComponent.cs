using Application.DataTransferObject;
using Application.Services.Feature;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class FeatureComponent:ViewComponent
{
    readonly IFeatureService _featureService;
    public FeatureComponent(IFeatureService featureService)
    {
        _featureService = featureService;
    }
    public async Task<IViewComponentResult> InvokeAsync(Guid Id)
    {
        IReadOnlyList<FeatureDto> features =
            await _featureService.GetFeaturesByProductIdAsync(Id);

        return View("/Views/Shared/ViewComponent/FeatureComponent.cshtml",
            features.Adapt<IReadOnlyList<FeatureViewModel>>());

    }
}
