using Application.Common.CustomException;
using Application.DataTransferObject;
using Application.Services.Identity.User;
using EndPoint_Ui.Models.Identity;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Controllers;

public class IdentityController : Controller
{
    readonly IUserService _userService;
    public IdentityController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    [Route("/SignIn")]
    public IActionResult SignIn()
    {
        if (User.Identity!.IsAuthenticated)
        {
            return Redirect("/");
        }
       
        return View();
    }


    [HttpPost]
    [Route("/SignIn")]
    public async Task<IActionResult> SignIn(SignInModel model)
    {
        if (!ModelState.IsValid)
        {

            return View(model);
        }
      



        try
        {
            await _userService.SignInAsync(model.Adapt<UserDto>());
            return RedirectToAction("Index", "UserPanel");
        }
        catch (InternalException ex)
        {
            if (string.IsNullOrEmpty(ex.Message))
            {
                ViewBag.ErrorMessage = CultureInfo.CurrentCulture.Name ==
                    "en-US" ? "It is not possible to access the website" : "امکان ورود به سایت وجود ندارد";
            }
            else
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View(model);
        }
    }

    [HttpGet]
    [Route("/SignUp")]
    public IActionResult SignUp()
    {
        if (User.Identity!.IsAuthenticated)
        {
            return Redirect("/");
        }
        return View();
    }
    [HttpPost]
    [Route("/SignUp")]
    public async Task<IActionResult>SignUp(SignUpModel model)
    {
        if (!ModelState.IsValid)
        {
           
            return View(model);
        }
        if(model.Terms is false)
        {
            ModelState.AddModelError("Terms",

                CultureInfo.CurrentCulture.Name ==
                    "en-US" ? "Acceptance of the rules is required" : "پذیرش قوانین الزامی است"

                ); return View(model);
        }



        try
        {
            await _userService.SignUpAsync(model.Adapt<UserDto>());
            return RedirectToAction("Index", "UserPanel");
        } 
        catch (InternalException ex)
        {
            if (string.IsNullOrEmpty(ex.Message)) 
            {
                ViewBag.ErrorMessage = CultureInfo.CurrentCulture.Name == 
                    "en-US"? "Registration is currently unavailable" : "در حال حاضر امکان ثبت نام وجود ندارد";
            }
            else
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View(model);
        }
    }
    [Route("/SignOut")]
    public async Task<IActionResult> SignOut()
    {
        if (User.Identity!.IsAuthenticated)
        {
            await _userService.SignOutAsync();
           
        }
            return Redirect("/");
      
    }
}
