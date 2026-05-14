namespace Application.DataTransferObject;

public sealed record BankDto
{
	public Guid Id { get; set; }
	public string? Title { get; set; }
	public string? PhoneNumber { get; set; }
}
