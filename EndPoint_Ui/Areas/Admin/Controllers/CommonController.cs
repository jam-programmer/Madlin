using Application.Common.Extension;
using Microsoft.AspNetCore.Mvc;
namespace EndPoint_Ui.Areas.Admin.Controllers;

[Area("Admin")]
public class CommonController : Controller
{
    #region CKEDITOR
    [HttpPost]
    public async Task<IActionResult> UploadImage(IFormFile upload)
    {
        if (upload == null)
        {
            return null;
        }
        string fileName = upload.UploadImage("common");
        string url = $"/gallery/common/{fileName}";
        return Json(new { uploaded = true, url });
    }
    #endregion
}
