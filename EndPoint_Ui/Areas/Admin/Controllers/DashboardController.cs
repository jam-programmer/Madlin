using EndPoint_Ui.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize]
public class DashboardController : Controller
{
    [Route("/Admin")]
    public IActionResult Index()
    {
        return View();
    }
    [Route("/PermissionDenied")]
    public IActionResult PermissionDenied()
    {
        return View();
    }

}
