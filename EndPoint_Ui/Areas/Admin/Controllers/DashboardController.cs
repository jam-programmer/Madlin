using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Areas.Admin.Controllers;
[Area("Admin")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
