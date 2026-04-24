using Application.Common;
using Application.DataTransferObject;
using Application.Services.Message;
using EndPoint_Ui.Areas.Admin.Models.Message;
using Mapster;
using EndPoint_Ui.Attributes;
using Microsoft.AspNetCore.Mvc;
using EndPoint_Ui.Areas.Admin.Models.Common;

namespace EndPoint_Ui.Areas.Admin.Controllers;
[Area("Admin")]
[AdminAuthorize("Message")]
public class MessageController : Controller
{
    readonly IMessageService _messageService;
    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        ViewBag.Keyword = pagination.keyword;
        PaginatedList<MessageDto> model = await _messageService.
            GetMessagesAsync(pagination);
        return View(model.Adapt<PaginatedList<MessageViewModel>>());
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] DeleteModel input)
    {
        try
        {

            await _messageService.DeleteMessageAsync(input.Id);
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
