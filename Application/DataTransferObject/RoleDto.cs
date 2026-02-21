namespace Application.DataTransferObject;
public sealed record RoleDto
{
	public Guid Id { get; set; }
	public string? Name { get; set; }
	public string? PersianName { get; set; }
	public bool IsCustomer { get; set; }
}
