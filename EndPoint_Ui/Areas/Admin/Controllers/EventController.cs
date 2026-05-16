using Application.Common;
using Application.DataTransferObject;
using Application.Services.Event;
using EndPoint_Ui.Areas.Admin.Models.Event;
using EndPoint_Ui.Areas.Admin.Models.Common;
using EndPoint_Ui.Attributes;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using Application.Common.CustomException;
using EndPoint_Ui.Areas.Admin.Models.Image;
namespace EndPoint_Ui.Areas.Admin.Controllers;
[Area("Admin")]
[AdminAuthorize("Event")]
public class EventController : Controller
{
    readonly IEventService _eventService;
    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        ViewBag.Keyword = pagination.keyword;
        PaginatedList<EventDto> model = await _eventService.
            GetEventsAsync(pagination);
        return View(model.Adapt<PaginatedList<EventViewModel>>());
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Alert = null;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEventModel model)
    {
        if (ModelState.IsValid is false)
        {
            return View(model);
        }
        try
        {
            await _eventService.InsertEventAsync(new EventDto()
            {
                DescriptionEn=model.DescriptionEn,
                DescriptionFa=model.DescriptionFa,
                File=model.File,
                TitleEn=model.TitleEn,
                TitleFa=model.TitleFa,  
                VideoUrls=model.VideoUrls,
            });
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {

            ViewBag.Alert = ex.Message;
            return View(model);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {
        ViewBag.Alert = null;
        EventDto Event = await _eventService.GetEventByIdAsync(Id);
        return View(Event.Adapt<EditEventModel>());
    }
    [HttpPost]
    public async Task<IActionResult> Edit(EditEventModel model)
    {
        if (ModelState.IsValid is false)
        {
            return View(model);
        }
        try
        {
            await _eventService.UpdateEventAsync(new EventDto()
            {
                Url = model.Url,
                Path=model.Path,
                Id=model.Id,
                DescriptionEn = model.DescriptionEn,
                DescriptionFa = model.DescriptionFa,
                File = model.File,
                TitleEn = model.TitleEn,
                TitleFa = model.TitleFa,
                VideoUrls = model.VideoUrls,
            });
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {

            ViewBag.Alert = ex.Message;
            return View(model);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] DeleteModel input)
    {
        try
        {

            await _eventService.DeleteEventAsync(input.Id);
            return new JsonResult(new
            {
                IsSuccess = true,
                Message = string.Empty,
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                IsSuccess = false,
                Message = ex.Message,
            });
        }
    }
    [HttpPost]
    public async Task<IActionResult> DeleteImage([FromBody] DeleteModel input)
    {
        try
        {

            await _eventService.DeleteEventImageAsync(input.Id);
            return new JsonResult(new
            {
                IsSuccess = true,
                Message = string.Empty,
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                IsSuccess = false,
                Message = ex.Message,
            });
        }
    }
    [HttpGet]
    public async Task<IActionResult> Gallery(Guid EventId)
    {
        ViewBag.EventId = EventId;
        IReadOnlyList<EventImageDto> images=
            await _eventService.GetImagesByEventIdAsync(EventId);
        return View(images.Adapt<IReadOnlyList<EventImageViewModel>>());
    }
    [HttpGet]
    public IActionResult CreateImage(Guid EventId)
    {
		ViewBag.EventId = EventId;
		return View();
    }

	[HttpPost]
	public async Task<IActionResult> CreateImage(CreateEventImageModel model)
	{
		if (!ModelState.IsValid)
		{
			return View(model);
		}
		try
		{
			await _eventService.InsertEventImageAsync(new EventImageDto()
			{
				File = model.File,
                EventId = model.EventId
			});
			return RedirectToAction(nameof(Gallery),new {EventId=model.EventId});
		}
		catch (InternalException ex)
		{
			ViewBag.Alert = ex.Message; return View(model);
		}
	}

}
