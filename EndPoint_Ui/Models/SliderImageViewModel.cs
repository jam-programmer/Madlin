namespace EndPoint_Ui.Models
{
    public sealed record SliderImageViewModel
    {
        public Guid Id { get; set; }
        public string? Path { get; set; }
        public string? Link { get; set; }
        public string? Title { get; set; }
    }
}
