namespace EndPoint_Ui.Areas.Admin.Models.Event
{
    public sealed record EventViewModel
    {
        public Guid Id { get; set; }
        public string? TitleFa { set; get; }
        public string? Path { set; get; }
    }
}
