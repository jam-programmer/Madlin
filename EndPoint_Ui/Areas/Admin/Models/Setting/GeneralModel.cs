namespace EndPoint_Ui.Areas.Admin.Models.Setting;

public sealed record GeneralModel: SeoModel
{
    public string? RegistrationRulesFa { get; set; }
    public string? RegistrationRulesEn { get; set; }
    public string? DescriptionFa { get; set; }
    public string? DescriptionEn { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
    public string? FaviconPath { get; set; }
    public string? Header { get; set; }
    public string? Footer { get; set; }
    public IFormFile? FaviconFile { get; set; }
    public string? LogoPath { get; set; }
    public IFormFile? LogoFile { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? AddressFa { get; set; }
    public string? AddressEn { get; set; }
    public string? Telegram { get; set; }
    public string? WhatsApp { get; set; }
    public string? Instagram { get; set; }
    public string? Linkedin { get; set; }
}
