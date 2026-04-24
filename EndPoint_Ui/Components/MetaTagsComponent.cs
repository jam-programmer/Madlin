using Application.DataTransferObject;
using Application.Services.Setting;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace EndPointUI.Components
{
    public class MetaTagsComponent : ViewComponent
    {
       readonly ISettingService _settingService;
        public MetaTagsComponent(ISettingService settingService)
        {
          _settingService = settingService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            SeoDto seo = await _settingService.GetSeoAsync();
           
            return View("/Views/Shared/ViewComponent/MetaTagsComponent.cshtml", seo.Adapt<SeoViewModel>());
        }
    }
}
