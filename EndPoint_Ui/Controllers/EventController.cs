using Application.Common;
using Application.DataTransferObject;
using Application.Services.Event;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Controllers;

public class EventController : Controller
{
    readonly IEventService _eventService;
    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }
    [HttpGet]
    [Route("/Events")]
    public async Task<IActionResult> Events([FromQuery] Pagination pagination)
    {
        ViewBag.Keyword = pagination.keyword;
        PaginatedList<EventDto> model = await _eventService.
            GetEventsAsync(pagination);
        return View(model.Adapt<PaginatedList<EventViewModel>>());
    }

    [HttpGet]
    [Route("/Events/Detail/{Url}")]
    public async Task<IActionResult> Detail(string Url)
    {
        EventDto eventDto = await _eventService.GetEventByUrlAsync(Url);
        EventDetailViewModel model=eventDto.Adapt<EventDetailViewModel>();
        return View(model);
    }
}
