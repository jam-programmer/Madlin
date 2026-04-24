namespace EndPoint_Ui.Areas.Admin.Models.Role
{
    public sealed record RouteViewModel
    {
        public Guid? Id { get; set; }
        public Guid? ParentId { get; set; }

        public int Order { get; set; }
        public string? Name { get; set; }
    }
}
