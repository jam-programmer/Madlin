using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject;

public sealed record CommentDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
    public string? Reply { get; set; }
    public string? UserPublicName { get; set; }
    public string? CreatedDate { get; set; }
    public string? ProductTitleFa { get; set; }   
    public string? UserPhoneNumber { get; set; }

    public bool IsActive { get; set; }
    public Guid ProductId { get; set; }
 

}
