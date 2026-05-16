namespace Application.DataTransferObject;
public sealed record GeneralNumberDto
{
    public int TemplateCode { get; set; }

    public string? PhoneNumber { get; set; }

    public List<SmsParameterDto>? Parameters { get; set; }
}
public sealed record SmsParameterDto
{
    public string? Key { get; set; }
    public string? Value { get; set; }
}
