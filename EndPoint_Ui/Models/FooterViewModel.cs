namespace EndPoint_Ui.Models
{
    public sealed record FooterViewModel: SocialViewModel
    {
        public string? DescriptionFa { get; set; }
        public string? DescriptionEn { get; set; }
        public string? LogoPath { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AddressFa { get; set; }
        public string? AddressEn { get; set; }
 
    }
}
