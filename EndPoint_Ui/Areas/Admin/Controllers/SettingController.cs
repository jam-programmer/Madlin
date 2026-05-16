using Application.DataTransferObject;
using Application.Services.Setting;
using EndPoint_Ui.Areas.Admin.Models.Setting;
using EndPoint_Ui.Attributes;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace EndPoint_Ui.Areas.Admin.Controllers;
[Area("Admin")]
[AdminAuthorize("Setting")]
public class SettingController : Controller
{
    readonly ISettingService _settingService;
    public SettingController(ISettingService settingService)
    {
        _settingService = settingService;
    }
    [HttpGet]
    public async Task<IActionResult> General()
    {
        SeoDto seoDto=await _settingService.GetSeoAsync();
        GeneralDto generalDto = await _settingService.GetGeneralAsync();
        GeneralModel model = generalDto.Adapt<GeneralModel>();
        #region Seo
        model.Canonical = seoDto.Canonical;
        model.SeoDescriptionEn = seoDto.DescriptionEn;
        model.SeoDescriptionFa = seoDto.DescriptionFa;
        model.KeywordsEn = seoDto.KeywordsEn;
        model.KeywordsFa = seoDto.KeywordsFa;
        model.OgDescriptionEn = seoDto.OgDescriptionEn;
        model.OgDescriptionFa = seoDto.OgDescriptionFa;
        model.OgImage = seoDto.OgImage;
        model.OgTitleEn = seoDto.OgTitleEn;
        model.OgTitleFa = seoDto.OgTitleFa;
        model.OgType = seoDto.OgType;
        model.OgUrl = seoDto.OgUrl;
        model.Robots = (Robots)seoDto.Robots ;
        model.ThemeColor = seoDto.ThemeColor;
        model.SeoTitleEn = seoDto.TitleEn;
        model.SeoTitleFa = seoDto.TitleFa;
        model.TwitterDescriptionEn = seoDto.TwitterDescriptionEn;
        model.TwitterDescriptionFa = seoDto.TwitterDescriptionFa;
        model.TwitterImage = seoDto.TwitterImage;
        model.TwitterTitleEn = seoDto.TwitterTitleEn;
        model.TwitterTitleFa = seoDto.TwitterTitleFa;
        #endregion
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> General(GeneralModel model)
    {
        await _settingService.UpdateSeoAsync(new SeoDto()
        {
            TwitterImageFile = model.TwitterImageFile,
            Canonical = model.Canonical,
            DescriptionEn = model.SeoDescriptionEn,
            DescriptionFa = model.SeoDescriptionFa,
            KeywordsEn = model.KeywordsEn,
            KeywordsFa = model.KeywordsFa,
            OgDescriptionEn = model.OgDescriptionEn,
            OgDescriptionFa = model.OgDescriptionFa,
            OgImage=model.OgImage,  
            OgImageFile=model.OgImageFile,
            OgTitleEn = model.OgTitleEn,
            OgTitleFa = model.OgTitleFa,
            OgType = model.OgType,
            OgUrl = model.OgUrl,    
            Robots=(int) model.Robots,
            ThemeColor = model.ThemeColor,
            TitleEn = model.SeoTitleEn,
            TitleFa = model.SeoTitleFa,
            TwitterDescriptionEn = model.TwitterDescriptionEn,
            TwitterDescriptionFa = model.TwitterDescriptionFa,
            TwitterImage = model.TwitterImage,
            TwitterTitleEn = model.TwitterTitleEn,
            TwitterTitleFa = model.TwitterTitleFa   
        });
        await _settingService.UpdateGeneralAsync(new GeneralDto()
        {
            ExclusiveNumber = model.ExclusiveNumber,
            SmsToken=model.SmsToken,
            FaviconPath = model.FaviconPath,
            FaviconFile = model.FaviconFile,
            AddressEn = model.AddressEn,
            AddressFa = model.AddressFa,
            Email = model.Email,
            Instagram = model.Instagram,
            Linkedin = model.Linkedin,
            LogoFile = model.LogoFile,
            LogoPath = model.LogoPath,
            PhoneNumber = model.PhoneNumber,
            Telegram = model.Telegram,
            TitleEn = model.TitleEn,
            TitleFa = model.TitleFa,
            WhatsApp = model.WhatsApp,
            DescriptionFa = model.DescriptionFa,
            DescriptionEn = model.DescriptionEn,
            RegistrationRulesEn = model.RegistrationRulesEn,
            RegistrationRulesFa = model.RegistrationRulesFa,
            Footer= model.Footer,
            Header= model.Header,
            
        });
        return RedirectToAction(nameof(General));
    }


    [HttpGet]
    public async Task<IActionResult> AdvertisingBanner()
    {
        AdvertisingBannerDto advertisingBanner =
            await _settingService.GetAdvertisingBannerAsync();
        return View(advertisingBanner.Adapt<AdvertisingBannerModel>());
    }

    [HttpPost]
    public async Task<IActionResult> AdvertisingBanner(AdvertisingBannerModel model)
    {
        await _settingService.UpdateAdvertisingBannerAsync(new AdvertisingBannerDto()
        {
            ImageOneFile = model.ImageOneFile,
            ImageTwoFile = model.ImageTwoFile,
            ImageOnePath = model.ImageOnePath,
            ImageTwoPath = model.ImageTwoPath,
            ImageThreePath = model.ImageThreePath,
            ImageThreeFile = model.ImageThreeFile,
            ImageFourPath = model.ImageFourPath,
            ImageFivePath = model.ImageFivePath,
            ImageFourFile = model.ImageFourFile,
            ImageFiveFile = model.ImageFiveFile,
        });
        return RedirectToAction(nameof(AdvertisingBanner));
    }


    [HttpGet]
    public async Task<IActionResult> Header()
    {
        HeaderDto headerDto = await _settingService.GetHeaderAsync(default);
        return View(headerDto.Adapt<HeaderModel>());
    }
    [HttpPost]
    public async Task<IActionResult> Header(HeaderModel model)
    {
        await _settingService.UpdateHeaderAsync(model.Adapt<HeaderDto>());
        return RedirectToAction(nameof(Header));
    }


    [HttpGet]
    public async Task<IActionResult> About()
    {
        AboutDto aboutDto = await _settingService.GetAboutAsync();  

        return View(aboutDto.Adapt<AboutModel>());
    }

    [HttpPost]
    public async Task<IActionResult> About(AboutModel model)
    {
        await _settingService.UpdateAboutAsync(new AboutDto()
        {
            ImageFile = model.ImageFile,
            ImagePath = model.ImagePath,
            TextEn = model.TextEn,
            TextFa = model.TextFa,
        });

        return RedirectToAction(nameof(About));
    }
}
