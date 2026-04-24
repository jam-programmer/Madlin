namespace EndPoint_Ui.Areas.Admin.Models.Setting
{
    public  record SeoModel
    {
        public string? OgTitleFa { get; set; }
        public string? OgType { get; set; }
        public string? OgTitleEn { get; set; }
        public string? OgUrl { get; set; }

        public string? OgDescriptionFa { get; set; }
        public string? OgDescriptionEn { get; set; }
        public string? TwitterTitleEn { get; set; }
        public string? TwitterDescriptionEn { get; set; }
        public string? TwitterTitleFa { get; set; }
        public string? TwitterDescriptionFa { get; set; }




        public string? OgImage { get; set; }
        public IFormFile? OgImageFile { get; set; }
        public string? TwitterImage { get; set; }

        public IFormFile? TwitterImageFile { get; set; }
        public Robots? Robots { get; set; }
        public string? ThemeColor { get; set; }
        public string? KeywordsEn { get; set; }
        public string? KeywordsFa { get; set; }
        public string? Canonical { get; set; }
        public string? SeoTitleFa { get; set; }
        public string? SeoDescriptionFa { get; set; }
        public string? SeoTitleEn { get; set; }
        public string? SeoDescriptionEn { get; set; }
    }
}
