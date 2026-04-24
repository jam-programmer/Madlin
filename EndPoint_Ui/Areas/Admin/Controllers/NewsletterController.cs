using Application.Common;
using Application.DataTransferObject;
using Application.Services.Newsletter;
using EndPoint_Ui.Areas.Admin.Models.Common;
using EndPoint_Ui.Areas.Admin.Models.Newsletter;
using EndPoint_Ui.Attributes;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Areas.Admin.Controllers;
[Area("Admin")]
[AdminAuthorize("Newsletter")]
public class NewsletterController : Controller
{
    readonly INewsletterService _newsletterService;
    public NewsletterController(INewsletterService newsletterService)
    {
        _newsletterService = newsletterService;
    }
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        ViewBag.Keyword = pagination.keyword;
        PaginatedList<NewsletterDto> model = await _newsletterService.GetNewslettersAsync(pagination);
        return View(model.Adapt<PaginatedList<NewsletterViewModel>>());
    }
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] DeleteModel input)
    {
        try
        {
            await _newsletterService.DeleteNewsletterAsync(input.Id);
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
