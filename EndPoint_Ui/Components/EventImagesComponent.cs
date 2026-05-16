using Application.DataTransferObject;
using Application.Services.Blog;
using Application.Services.Event;
using Application.Services.Setting;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class EventImagesComponent : ViewComponent
{
    readonly IEventService _eventService;
    public EventImagesComponent(IEventService eventService)
    {
        _eventService = eventService;
    }

    public async Task<IViewComponentResult> InvokeAsync(Guid Id)
    {
        IReadOnlyList<EventImageDto> images = await _eventService.GetImagesByEventIdAsync(Id);
        return View("/Views/Shared/ViewComponent/EventImagesComponent.cshtml",
            images.Adapt<IReadOnlyList<EventImageViewModel>>());
    }
}
