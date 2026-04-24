using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Blog;

[Table("BlogTagMap")]
public class BlogTagEntity : BaseEntity
{
    public BlogEntity? Blog { get; set; }
    public TagEntity? Tag { get; set; } 
    
    public Guid BlogId { get; set; }
    public Guid TagId { get; set; }  


}
