using Application.DataTransferObject;
using Application.Services.Blog;
using Application.Services.Page;
using Application.Services.Setting;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.VisualBasic;

namespace EndPoint_Ui.Components;

public class ItemPageComponent : ViewComponent
{
    readonly IPageService _pageService;
    public ItemPageComponent(IPageService pageService)
    {
        _pageService = pageService;
    }
    public async Task<IViewComponentResult> InvokeAsync(PositionModel input)
    {
        string ViewName=string.Empty;   
        if (input.Position == 1)
        {
            ViewName = "ItemFooterPageComponent";
        }
        else
        {
            if (input.IsMobile)
            {
                ViewName = "ItemHeaderMobilePageComponent";
            }
            else
            {
                ViewName = "ItemHeaderPageComponent";
            }
        }



        IReadOnlyList<PageItemDto> model = await _pageService.GetItemPagesByPositionAsync(input.Position);

        return View($"/Views/Shared/ViewComponent/{ViewName}.cshtml",
            model.Adapt<IReadOnlyList<PageItemViewModel>>());
    }

    public class PositionModel
    {
        public PositionModel(int Position,bool IsMobile=false)
        {
            this.Position = Position;
            this.IsMobile = IsMobile;
        }
        public bool IsMobile { get; set; } =false;
        public int Position { get; set; }
    }
}
