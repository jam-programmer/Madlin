using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product;

public class ResponseEntity:BaseEntity
{
    public string? Text { get; set; }
    public DateTime? CreatedDate { get; set; } = DateTime.Now;
    public Guid CommentId { get; set; }
    public CommentEntity? Comment { get; set; }
}
