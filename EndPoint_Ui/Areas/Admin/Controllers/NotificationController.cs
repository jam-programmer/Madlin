using Application.Common;
using Application.DataTransferObject;
using Application.Services.Notification;
using EndPoint_Ui.Areas.Admin.Models.Common;
using EndPoint_Ui.Areas.Admin.Models.Notification;
using EndPoint_Ui.Attributes;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using Application.Common.Extension;
using Domain.Entities.System;
namespace EndPoint_Ui.Areas.Admin.Controllers;

[Area("Admin")]
[AdminAuthorize("Notification")]
public class NotificationController : Controller
{
    readonly INotificationService _notificationService;
    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        TypeAdapterConfig config = new();
        config.NewConfig<NotificationDto, NotificationViewModel>()
            .Map(d => d.TitleFa, s => s.TitleFa)
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.IsActive, s => s.IsActive)
            .Map(d => d.Path, s => s.Path)
            .Map(d => d.Start, s => s.Start!.Value.PersianDateWithOutTime())
            .Map(d => d.End, s => s.End!.Value.PersianDateWithOutTime())
                        .Compile();

        ViewBag.Keyword = pagination.keyword;
        PaginatedList<NotificationDto> model = await _notificationService.
            GetNotificationsAsync(pagination);
        return View(model.Adapt<PaginatedList<NotificationViewModel>>(config));
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Alert = null;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateNotificationModel model)
    {
        if (ModelState.IsValid is false)
        {
            return View(model);
        }
        try
        {
            await _notificationService.InsertNotificationAsync(new NotificationDto()
            {
                DescriptionEn=model.DescriptionEn,
                DescriptionFa=model.DescriptionFa,
                End=model.End.ConvertToGregorian(),
                File=model.File,
                IsActive=model.IsActive,
                Size=model.Size,
                Start= model.Start.ConvertToGregorian(),
                TitleEn=model.TitleEn,
                TitleFa=model.TitleFa,
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
        NotificationDto Notification = await _notificationService.GetNotificationByIdAsync(Id);
        return View(new EditNotificationModel()
        {
            Path = Notification.Path,
            DescriptionEn=Notification.DescriptionEn,
            DescriptionFa=Notification.DescriptionFa,
            Id=Id,
            TitleFa = Notification.TitleFa,
            TitleEn=Notification.TitleEn,
            IsActive = Notification.IsActive,
            Size = Notification.Size,
            End= Notification.End.Value.PersianDateWithOutTime(),
            Start= Notification.Start.Value.PersianDateWithOutTime(),
        });
    }
    [HttpPost]
    public async Task<IActionResult> Edit(EditNotificationModel model)
    {
        if (ModelState.IsValid is false)
        {
            return View(model);
        }
        try
        {
            await _notificationService.UpdateNotificationAsync(new NotificationDto()
            {
                Id=model.Id,
                Path=model.Path,
                DescriptionEn = model.DescriptionEn,
                DescriptionFa = model.DescriptionFa,
                End = model.End.ConvertToGregorian(),
                File = model.File,
                IsActive = model.IsActive,
                Size = model.Size,
                Start = model.Start.ConvertToGregorian(),
                TitleEn = model.TitleEn,
                TitleFa = model.TitleFa,
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

            await _notificationService.DeleteNotificationAsync(input.Id);
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
}
