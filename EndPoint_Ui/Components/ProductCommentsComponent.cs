using Application.DataTransferObject;
using Application.Services.Comment;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class ProductCommentsComponent:ViewComponent
{
    readonly ICommentService _commentService;
    public ProductCommentsComponent(ICommentService commentService)
    {
        _commentService = commentService; 
    }
    public async Task<IViewComponentResult> InvokeAsync(Guid Id)
    {
        IReadOnlyList<ProductCommentDto> comments =
            await _commentService.GetCommentsByProductIdAsync(Id);
        return View("/Views/Shared/ViewComponent/ProductCommentsComponent.cshtml",
            comments.Adapt<IReadOnlyList<ProductCommentViewModel>>());

    }
}
