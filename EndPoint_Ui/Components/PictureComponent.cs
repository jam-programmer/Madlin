using Application.DataTransferObject;
using Application.Services.Picture;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class PictureComponent:ViewComponent
{
    readonly IPictureService _pictureService;
    public PictureComponent(IPictureService pictureService)
    {
        _pictureService = pictureService;
    }
    public async Task<IViewComponentResult> InvokeAsync(Guid Id)
    {
        IReadOnlyList<PictureDto> pictures =
            await _pictureService.GetPictureAsync(Id);

        return View("/Views/Shared/ViewComponent/PictureComponent.cshtml",
            pictures.Adapt<IReadOnlyList<PictureViewModel>>());

    }
}
