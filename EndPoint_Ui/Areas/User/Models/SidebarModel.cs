namespace EndPoint_Ui.Areas.User.Models
{
    public sealed record SidebarModel
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
    }
}
