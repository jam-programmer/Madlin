namespace EndPoint_Ui.Areas.Admin.Models.Comment
{
    public sealed record CommentViewModel
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? ProductTitle { get; set; }
        public string? UserPublicName { get; set; }
        public string? UserPhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedDate { get; set; }
    }
}
