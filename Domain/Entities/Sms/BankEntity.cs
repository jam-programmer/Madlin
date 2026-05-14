namespace Domain.Entities.Sms;

public class BankEntity : BaseEntity, IDelete
{

	public string? Title { get; set; }
	public string? PhoneNumber { get; set; }
	public bool IsDeleted { get; set; } = false;
}
