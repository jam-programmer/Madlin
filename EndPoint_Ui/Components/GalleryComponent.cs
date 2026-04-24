using Application.DataTransferObject;
using Application.Services.Blog;
using Application.Services.Image;
using Application.Services.Setting;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class GalleryComponent:ViewComponent
{
	readonly ISettingService _settingService;
	readonly IImageService _imageService;
	public GalleryComponent(IImageService imageService, ISettingService settingService)
	{
		_settingService = settingService;
		_imageService = imageService;
	}
	public async Task<IViewComponentResult> InvokeAsync()
	{

		SectionHeaderDto sectionHeaderDto = await _settingService.GetGalleryHeaderAsync();
		IReadOnlyList<ImageDto> images = await _imageService.GetImagesAsync();

		ValueTuple<IReadOnlyList<ImageViewModel>, HeaderViewModel> model =
			new(images.Adapt<IReadOnlyList<ImageViewModel>>() , sectionHeaderDto.Adapt<HeaderViewModel>());

		return View("/Views/Shared/ViewComponent/GalleryComponent.cshtml", model);

	}
}
