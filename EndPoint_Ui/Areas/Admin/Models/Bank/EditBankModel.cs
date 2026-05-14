namespace EndPoint_Ui.Areas.Admin.Models.Bank
{
	public sealed record EditBankModel: CreateBankModel
	{
		public Guid Id { get; set; }
	}
}
