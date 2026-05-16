namespace EndPoint_Ui.Areas.Admin.Models.Event
{
    public sealed record EditEventModel:CreateEventModel
    {
        public string? Url { get; set; }
        public new IFormFile? File { get; set; }
        public string? Path { get; set; }
        public Guid Id { get; set; }
    }
}
