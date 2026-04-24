using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject;

public sealed record ProductCommentDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
    public string? ResponseText { get; set; }
    public string? UserPublicName { get; set; }
    public string? CreatedDate { get; set; }
    public string? ResponseCreatedDate { get; set; }
}
