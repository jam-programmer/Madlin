using Application.Common;
using Application.Common.CustomException;
using Application.DataTransferObject;
using Application.Services.Identity.Role;
using Application.Services.Identity.Route;
using EndPoint_Ui.Areas.Admin.Models.Common;
using EndPoint_Ui.Areas.Admin.Models.Role;
using EndPoint_Ui.Attributes;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Areas.Admin.Controllers;

[Area("Admin")]
[AdminAuthorize("Role")]
public class RoleController(IRoleService roleService, IRouteService routeService) : Controller
{
    private readonly IRoleService _roleService = roleService;
    private readonly IRouteService _routeService=routeService;

    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] Pagination pagination)
    {
        PaginatedList<RoleDto> model =
            await _roleService.GetRolesAsync(pagination);
        PaginatedList<RoleViewModel> pageModel = model.Adapt<PaginatedList<RoleViewModel>>();
        ViewBag.Keyword = pageModel.Keyword;
        return View(pageModel);
    }
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Alert = null;
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateRoleModel roleModel)
    {
        if (ModelState.IsValid is false)
        {
            return View(roleModel);
        }

        try
        {
            await _roleService.InsertRoleAsync(roleModel.Adapt<RoleDto>());
            return RedirectToAction(nameof(Index));
        }
        catch (InternalException ex)
        {
            ViewBag.Alert = ex.Message;
            return View(roleModel);
        }
    }


    [HttpGet]
    public async Task<IActionResult> Edit(Guid Id)
    {
        RoleDto role = await _roleService.GetRoleByIdAsync(Id);
        ViewBag.Alert = null;
        return View(role.Adapt<EditRoleModel>());
    }
    [HttpPost]
    public async Task<IActionResult> Edit(EditRoleModel roleModel)
    {
        if (ModelState.IsValid is false)
        {
            return View(roleModel);
        }

        try
        {
            await _roleService.UpdateRoleAsync(roleModel.Adapt<RoleDto>());
            return RedirectToAction(nameof(Index));
        }
        catch (InternalException ex)
        {
            ViewBag.Alert = ex.Message;
            return View(roleModel);
        }
    }


    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] DeleteModel input)
    {
        try
        {

            await _roleService.DeleteRoleAsync(input.Id);
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
    public async Task<IActionResult> Access(Guid Id)
    {
        ViewBag.RoleId=Id;
        List<RouteDto> routes = await _routeService.GetRoutesAsync();
        ViewBag.Routes = routes.Adapt<List<RouteViewModel>>();
        ViewBag.RoleRoutes=await _routeService.GetRoutesByRoleIdAsync(Id);
        return View();
    } 
    
    [HttpPost]
    public async Task<IActionResult> Access(CreateRoleRouteModel model)
    {
        await _routeService.InsertRoleRouteAsync(model.Adapt<RoleRouteDto>());  
        return RedirectToAction(nameof(Index));
    }
}
