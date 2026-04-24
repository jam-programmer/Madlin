using Application.Common;
using Application.DataTransferObject;
using Application.Services.Identity.Role;
using Application.Services.Identity.User;
using EndPoint_Ui.Areas.Admin.Models.Common;
using EndPoint_Ui.Areas.Admin.Models.User;
using EndPoint_Ui.Attributes;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Areas.Admin.Controllers;

[Area("Admin")]
[AdminAuthorize("User")]
public class UserController(IUserService userService, IRoleService roleService) : Controller
{
    readonly IRoleService _roleService = roleService;
    readonly IUserService _userService = userService;
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        PaginatedList<UserDto> model =
            await _userService.GetUsersAsync(pagination);
        PaginatedList<UserViewModel> pageModel = new();
        pageModel = model.Adapt<PaginatedList<UserViewModel>>(); ViewBag.Keyword = pageModel.Keyword;

        return View(pageModel);
    }
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Alert = null;
        await Roles();
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserModel userModel)
    {
        if (ModelState.IsValid is false)
        {
            await Roles();
            return View(userModel);
        }
        try
        {
            await _userService.InsertUserAsync(userModel.Adapt<UserDto>());
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            await Roles();
            ViewBag.Alert = ex.Message; return View(userModel);
        }
    }





    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {
        UserDto userDto = await _userService.GetUserByIdAsync(Id);
        ViewBag.Alert = null;
        await Roles();
        return View(userDto.Adapt<EditUserModel>());
    }
    [HttpPost]
    public async Task<IActionResult> Edit(EditUserModel userModel)
    {
        if (ModelState.IsValid is false)
        {
            await Roles();
            return View(userModel);
        }
        try
        {
            await _userService.UpdateUserAsync(userModel.Adapt<UserDto>());
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            await Roles();
            ViewBag.Alert = ex.Message; return View(userModel);
        }
    }
    async Task Roles() => ViewBag.Roles = await _roleService.GetRolesForDropDownAsync();
    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] DeleteModel input)
    {
        try
        {

            await _userService.DeleteUserAsync(input.Id);
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
