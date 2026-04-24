using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Setting;

public interface ISettingService
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<GeneralDto> GetGeneralAsync();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task UpdateGeneralAsync(GeneralDto general, CancellationToken cancellation=default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<FooterDto> GetFooterInformationAsync
        (CancellationToken cancellation=default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<SocialDto> GetSocialsAsync(CancellationToken cancellation=default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<string>GetLogoAsync(CancellationToken cancellation=default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<RegistrationRuleDto> GetRegistrationRulesAsync(CancellationToken cancellation=default);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<AdvertisingBannerDto> GetAdvertisingBannerAsync(CancellationToken cancellation=default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancelled"></param>
    /// <returns></returns>
    Task UpdateAdvertisingBannerAsync(AdvertisingBannerDto advertisingBanner,
        CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<string>GetSliderBannerAsync(CancellationToken cancellation=default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<HeaderDto> GetHeaderAsync(CancellationToken cancellation=default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="header"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task UpdateHeaderAsync(HeaderDto header, CancellationToken cancellation=default);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<string> GetBannerForProductsSidebarAsync();
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<string> GetBannerForBlogsSidebarAsync();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<SectionHeaderDto> GetCategoryHeaderAsync();
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<SectionHeaderDto> GetProductHeaderAsync();
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<SectionHeaderDto> GetBlogHeaderAsync();
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<SliderHeaderDto> GetSliderHeaderAsync();
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<SectionHeaderDto> GetGalleryHeaderAsync();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<ContactInformationDto> GetContactInformationAsync();
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<SeoDto> GetSeoAsync();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="seo"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task UpdateSeoAsync(SeoDto seo, CancellationToken cancellation=default);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<SliderTextTopDto> GetSliderTextTopAsync();
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<SliderTextDownDto> GetSliderTextDownAsync();
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<AboutDto> GetAboutAsync();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="about"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task UpdateAboutAsync(AboutDto about, CancellationToken cancellation=default);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<InformationDto>GetInformationAsync();  
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<SiteInfoDto>GetSiteInfoAsync();


    Task<string> GetHeaderAsync();
    Task<string> GetFooterAsync();
}
