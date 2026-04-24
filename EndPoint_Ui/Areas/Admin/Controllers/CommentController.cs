using Application.Common;
using Application.DataTransferObject;
using Application.Services.Comment;
using EndPoint_Ui.Areas.Admin.Models.Common;
using EndPoint_Ui.Attributes;
using Microsoft.AspNetCore.Mvc;
using EndPoint_Ui.Areas.Admin.Models.Comment;
using Mapster;

namespace EndPoint_Ui.Areas.Admin.Controllers;

[Area("Admin")]
[AdminAuthorize("Comment")]
public class CommentController : Controller
{
    readonly ICommentService _commentService;
    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        ViewBag.Keyword = pagination.keyword;
        PaginatedList<CommentDto> model = await _commentService.
            GetCommentsAsync(pagination);
        return View(model.Adapt<PaginatedList<CommentViewModel>>());
    }

  

    [HttpGet]
    public async Task<IActionResult> Reply(Guid Id)
    {
        ViewBag.Alert = null;
        CommentDto Comment = await _commentService.GetCommentByIdAsync(Id);
        return View(Comment.Adapt<ReplyCommentModel>());
    }
    [HttpPost]
    public async Task<IActionResult> Reply(ReplyCommentModel model)
    {
        if (ModelState.IsValid is false)
        {
            return View(model);
        }
        try
        {
            await _commentService.UpdateCommentAsync(model.Adapt<CommentDto>());
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
            //DeleteCommentAsync
            await _commentService.DeleteCommentAsync(input.Id);
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
