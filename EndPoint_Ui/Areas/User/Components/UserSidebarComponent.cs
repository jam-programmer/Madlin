using Application.DataTransferObject;
using Application.Services.Identity.User;
using EndPoint_Ui.Areas.User.Models;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Areas.User.Components;

public class UserSidebarComponent:ViewComponent
{
    readonly IUserService _userService;
    public UserSidebarComponent(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<IViewComponentResult> InvokeAsync(Guid Id)
    {
        SidebarDto model=await _userService.GetProfileInfoForSidebarAsync(Id,default);
        return View("/Areas/User/Views/Shared/ViewComponent/UserSidebarComponent.cshtml",
            model.Adapt<SidebarModel>());
    }
}
