using Application.DataTransferObject;
using Application.Services.Identity.User;
using Application.Services.Product;
using EndPoint_Ui.Areas.User.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EndPoint_Ui.Areas.User.Controllers;

[Area("User")]
[Authorize]
public class UserPanelController : Controller
{
    readonly IProductService _productService;
    readonly IUserService _userService;
    public UserPanelController(IUserService userService, IProductService productService)
    {
        _productService = productService;
        _userService = userService;
    }
    [Route("/userpanel")]
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    [Route("/userpanel/myprofile")]
    public async Task<IActionResult> MyProfile()
    {
        string? currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        ProfileDto profile = await _userService.GetProfileInformationAsync(Guid.Parse(currentUserId));
        return View(profile.Adapt<ProfileModel>());
    }
    [HttpPost]
    [Route("/userpanel/myprofile")]
    public async Task<IActionResult> MyProfile(ProfileModel model)
    {
        if (ModelState.IsValid is false)
        {
            return View(model);
        }
        try
        {
            model.Id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _userService.UpdateProfileAsync(model.Adapt<ProfileDto>());
            return Redirect("/userpanel");
        }
        catch (Exception ex)
        {
            ViewBag.Alert = ex.Message;
            return View(model);
        }

    }

    [HttpGet]
    [Route("/userpanel/myfavorites")]
    public async Task<IActionResult> MyFavorites()
    {
        string? currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        IReadOnlyList< ProductItemDto >products=await _productService
            .GetProductsFromWishListAsync(Guid.Parse(currentUserId!));
        return View(products.Adapt<IReadOnlyList<FavoriteProductViewModel>>());
    }


}
