namespace EndPoint_Ui.Areas.Admin.Models.Bank
{
	public sealed record BankViewModel
	{
		public Guid Id { get; set; }
		public string? Title { get; set; }
		public string? PhoneNumber { get; set; }
	}
}
