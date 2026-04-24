namespace EndPoint_Ui.Models
{
    public sealed record CommentModel
    {
        public Guid productId { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public string username { get; set; }
        public string phonenumber { get; set; }
    }
}
