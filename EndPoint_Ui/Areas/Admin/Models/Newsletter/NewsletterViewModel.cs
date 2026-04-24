namespace EndPoint_Ui.Areas.Admin.Models.Newsletter
{
    public sealed record NewsletterViewModel
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
    }
}
