namespace EndPoint_Ui.Areas.Admin.Models.Page
{
    public sealed record EditPageModel: CreatePageModel
    {
        public string? Url { get; set; }
        public Guid Id { get; set; }
    }
}
