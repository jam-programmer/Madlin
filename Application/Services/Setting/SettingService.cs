
using Application.Common.Extension;
using Application.Services.Cache;
using Domain.Entities.System;
using Mapster;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Services.Setting;

public class SettingService : ISettingService
{
    readonly IAboutRepository _aboutRepository;
    readonly IHeaderRepository _headerRepository;
    readonly IAdvertisingBannerRepository _advertisingBannerRepository;
    readonly IGeneralRepository _generalRepository;
    public SettingService(IGeneralRepository generalRepository,
        IHeaderRepository headerRepository,
      IAboutRepository aboutRepository,
        IAdvertisingBannerRepository advertisingBannerRepository)
    {
        _aboutRepository = aboutRepository;
        _advertisingBannerRepository = advertisingBannerRepository;
        _generalRepository = generalRepository;
        _headerRepository = headerRepository;
    }

    public async Task<AdvertisingBannerDto> GetAdvertisingBannerAsync(CancellationToken cancellation = default)
    {
        AdvertisingBannerEntity advertisingBanner = await
            _advertisingBannerRepository.GetAdvertisingBannerAsync(cancellation);
        return advertisingBanner.Adapt<AdvertisingBannerDto>();
    }

    public async Task<string> GetBannerForBlogsSidebarAsync()
    {
        AdvertisingBannerEntity advertisingBanner = await
        _advertisingBannerRepository.GetAdvertisingBannerAsync(default);
        return advertisingBanner.ImageFourPath;
    }

    public async Task<string> GetBannerForProductsSidebarAsync()
    {
        AdvertisingBannerEntity advertisingBanner = await
          _advertisingBannerRepository.GetAdvertisingBannerAsync(default);
        return advertisingBanner.ImageFivePath;
    }

    public async Task<SectionHeaderDto> GetBlogHeaderAsync()
    {
        HeaderEntity header = await _headerRepository.GetHeaderAsync(default);
        SectionHeaderDto sectionHeader = new()
        {
            TitleEn = header.BlogTitleEn,
            TitleFa = header.BlogTitleFa,
        };
        return sectionHeader;
    }

    public async Task<SectionHeaderDto> GetCategoryHeaderAsync()
    {
        HeaderEntity header = await _headerRepository.GetHeaderAsync(default);
        SectionHeaderDto sectionHeader = new()
        {
            TitleEn = header.CategoryTitleEn,
            TitleFa = header.CategoryTitleFa,
        };
        return sectionHeader;
    }

    public async Task<ContactInformationDto> GetContactInformationAsync()
    {
        GeneralEntity generalEntity = await _generalRepository.GetGeneralAsync();
        return generalEntity.Adapt<ContactInformationDto>();
    }

    public async Task<FooterDto> GetFooterInformationAsync(CancellationToken cancellation = default)
    {
        GeneralEntity generalEntity = await _generalRepository.GetGeneralAsync();
        return generalEntity.Adapt<FooterDto>();
    }

    public async Task<SectionHeaderDto> GetGalleryHeaderAsync()
    {
        HeaderEntity header = await _headerRepository.GetHeaderAsync(default);
        SectionHeaderDto sectionHeader = new()
        {
            TitleEn = header.GalleryTitleEn,
            TitleFa = header.GalleryTitleFa,
        };
        return sectionHeader;
    }

    public async Task<GeneralDto> GetGeneralAsync()
    {
        GeneralEntity generalEntity = await _generalRepository.GetGeneralAsync();
        return generalEntity.Adapt<GeneralDto>();
    }

    public async Task<HeaderDto> GetHeaderAsync(CancellationToken cancellation = default)
    {
        HeaderEntity header = await _headerRepository.GetHeaderAsync(cancellation);
        return header.Adapt<HeaderDto>();
    }

    public async Task<string> GetLogoAsync(CancellationToken cancellation = default)
    {
        GeneralEntity generalEntity = await _generalRepository.GetGeneralAsync();
        return generalEntity.LogoPath;
    }

    public async Task<SectionHeaderDto> GetProductHeaderAsync()
    {
        HeaderEntity header = await _headerRepository.GetHeaderAsync(default);
        SectionHeaderDto sectionHeader = new()
        {
            TitleEn = header.ProductTitleEn,
            TitleFa = header.ProductTitleFa,
        };
        return sectionHeader;

    }

    public async Task<RegistrationRuleDto> GetRegistrationRulesAsync(CancellationToken cancellation = default)
    {
        GeneralEntity generalEntity = await _generalRepository.GetGeneralAsync();
        return generalEntity.Adapt<RegistrationRuleDto>();
    }


    public async Task<string> GetSliderBannerAsync(CancellationToken cancellation = default)
    {
        AdvertisingBannerEntity advertisingBanner = await
                  _advertisingBannerRepository.GetAdvertisingBannerAsync(cancellation);
        return advertisingBanner.ImageThreePath!;
    }

    public async Task<SliderHeaderDto> GetSliderHeaderAsync()
    {
        HeaderEntity header = await _headerRepository.GetHeaderAsync(default);
        return header.Adapt<SliderHeaderDto>();
    }

    public async Task<SocialDto> GetSocialsAsync(CancellationToken cancellation = default)
    {
        GeneralEntity generalEntity = await _generalRepository.GetGeneralAsync();
        return generalEntity.Adapt<SocialDto>();
    }

    public async Task UpdateAdvertisingBannerAsync(AdvertisingBannerDto advertisingBanner,
        CancellationToken cancellation = default)
    {
        AdvertisingBannerEntity advertisingBannerEntity = await
            _advertisingBannerRepository.GetAdvertisingBannerAsync(cancellation);
        if (advertisingBanner.ImageOneFile != null)
        {
            advertisingBannerEntity.ImageOnePath = advertisingBanner.ImageOneFile.UploadImage("Setting");
            advertisingBanner.ImageOnePath!.RemoveImage("Setting");
        }
        if (advertisingBanner.ImageTwoFile != null)
        {
            advertisingBannerEntity.ImageTwoPath = advertisingBanner.ImageTwoFile.UploadImage("Setting");
            advertisingBanner.ImageTwoPath!.RemoveImage("Setting");
        }
        if (advertisingBanner.ImageThreeFile != null)
        {
            advertisingBannerEntity.ImageThreePath = advertisingBanner.ImageThreeFile.UploadImage("Setting");
            advertisingBanner.ImageThreePath!.RemoveImage("Setting");
        }

        if (advertisingBanner.ImageFourFile != null)
        {
            advertisingBannerEntity.ImageFourPath =
                advertisingBanner.ImageFourFile.UploadImage("Setting");
            advertisingBanner.ImageFourPath!.RemoveImage("Setting");
        }
        if (advertisingBanner.ImageFiveFile != null)
        {
            advertisingBannerEntity.ImageFivePath = advertisingBanner.ImageFiveFile.UploadImage("Setting");
            advertisingBanner.ImageFivePath!.RemoveImage("Setting");
        }



        await _advertisingBannerRepository.UpdateAsync(advertisingBannerEntity, cancellation);
    }

    public async Task UpdateGeneralAsync(GeneralDto general, CancellationToken cancellation = default)
    {
        GeneralEntity generalEntity = await _generalRepository.GetGeneralAsync();
        general.Adapt(generalEntity);
        if (general.LogoFile != null)
        {
            generalEntity.LogoPath = general.LogoFile.UploadImage("Setting");
            general.LogoPath!.RemoveImage("Setting");
        }

        if (general.FaviconFile != null)
        {
            generalEntity.FaviconPath = general.FaviconFile.UploadImage("Setting");
            general.FaviconPath!.RemoveImage("Setting");
        }
        await _generalRepository.UpdateAsync(generalEntity, cancellation);
    }

    public async Task UpdateHeaderAsync(HeaderDto header, CancellationToken cancellation = default)
    {
        HeaderEntity headerEntity = await _headerRepository.GetHeaderAsync(cancellation);
        header.Adapt(headerEntity);
        await _headerRepository.UpdateHeaderAsync(headerEntity, cancellation);
    }

    public async Task UpdateSeoAsync(SeoDto seo, CancellationToken cancellation = default)
    {
        SeoEntity seoEntity = await _generalRepository.GetSeoAsync();
        seo.Adapt(seoEntity);
        if (seo.OgImageFile != null)
        {
            seoEntity.OgImage = seo.OgImageFile.UploadImage("Seo");
            seo.OgImage!.RemoveImage("Seo");
        }
        if (seo.TwitterImageFile != null)
        {
            seoEntity.TwitterImage = seo.TwitterImageFile.UploadImage("Seo");
            seo.TwitterImage!.RemoveImage("Seo");
        }
        await _generalRepository.UpdateSeoAsync(seoEntity);
    }

    public async Task<SeoDto> GetSeoAsync()
    {
        SeoEntity seoEntity = await _generalRepository.GetSeoAsync();
        return seoEntity.Adapt<SeoDto>();
    }

    public async Task<SliderTextTopDto> GetSliderTextTopAsync()
    {
        HeaderEntity headerEntity = await _headerRepository.GetHeaderAsync(default);
        return headerEntity.Adapt<SliderTextTopDto>();
    }

    public async Task<SliderTextDownDto> GetSliderTextDownAsync()
    {

        HeaderEntity headerEntity = await _headerRepository.GetHeaderAsync(default);
        return headerEntity.Adapt<SliderTextDownDto>();
    }

    public async Task<AboutDto> GetAboutAsync()
    {
        AboutEntity about = await _aboutRepository.GetAboutAsync();
        return about.Adapt<AboutDto>();
    }

    public async Task UpdateAboutAsync(AboutDto about, CancellationToken cancellation = default)
    {
        AboutEntity aboutEntity = await _aboutRepository.GetAboutAsync();
        aboutEntity.TextEn=about.TextEn;
        aboutEntity.TextFa = about.TextFa;
        if (about.ImageFile != null) 
        {
            aboutEntity.ImagePath = about.ImageFile.UploadImage("Setting");
            about.ImagePath!.RemoveImage("Setting");
        }
        await _aboutRepository.UpdateAboutAsync(aboutEntity);
    }

    public async Task<InformationDto> GetInformationAsync()
    {
        GeneralEntity generalEntity = await _generalRepository.GetGeneralAsync();   
        return generalEntity.Adapt<InformationDto>();
    }

    public async Task<SiteInfoDto> GetSiteInfoAsync()
    {
        GeneralEntity generalEntity = await _generalRepository.GetGeneralAsync();
        return generalEntity.Adapt<SiteInfoDto>();
    }

    public async Task<string> GetHeaderAsync()
    {
        GeneralEntity generalEntity = await _generalRepository.GetGeneralAsync();
        return generalEntity.Header;
    }

    public async Task<string> GetFooterAsync()
    {
        GeneralEntity generalEntity = await _generalRepository.GetGeneralAsync();
        return generalEntity.Footer;
    }
}
