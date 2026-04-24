namespace EndPoint_Ui.Areas.Admin.Models.Comment
{
    public sealed record ReplyCommentModel
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public string? ProductTitleFa { get; set; }
        public string? UserPublicName { get; set; }
        public string? UserPhoneNumber { get; set; }
        public string? Reply { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedDate { get; set; }
    }
}
