using Application.DataTransferObject;
using Application.Services.Bank;
using Application.Services.Sms;
using EndPoint_Ui.Areas.Admin.Models.Sms;
using EndPoint_Ui.Attributes;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Areas.Admin.Controllers;
[Area("Admin")]
[AdminAuthorize("Sms")]
public class SmsController : Controller
{
    readonly ISmsService _smsService;
    readonly IBankService _bankService;
    public SmsController(IBankService bankService, ISmsService smsService)
    {
        _smsService = smsService;
        _bankService = bankService; 
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult ExclusiveNumberForm()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ExclusiveNumberForm(ExclusiveNumberModel  model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _smsService.
                    SendSmsWithExclusiveNumberAsync(model.Adapt<ExclusiveNumberDto>());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Alert = ex.Message; return View(model);
            }
        }
        return View(model);
    }


        [HttpGet]
    public IActionResult GeneralNumberForm()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GeneralNumberForm(GeneralNumberModel model)
    {
        if (ModelState.IsValid) 
        {
            try
            {
                await _smsService.
                    SendSmsWithGeneralNumberAsync(model.Adapt<GeneralNumberDto>());
                return RedirectToAction("Index");
            }
            catch (Exception ex) 
            {
                ViewBag.Alert=ex.Message; return View(model);
            }
        }
        return View(model);
    }


    public async Task<JsonResult> GetNumbers([FromQuery] string search)
    {
        var numbers = await _bankService.GetNumbersForDropDownAsync(search);
        return Json(numbers);
    }

}
