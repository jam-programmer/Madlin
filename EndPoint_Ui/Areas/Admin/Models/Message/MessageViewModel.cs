namespace EndPoint_Ui.Areas.Admin.Models.Message
{
    public sealed record MessageViewModel
    {
        public Guid Id { get; set; }    
        public string? CreatedAt { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
    }
}
