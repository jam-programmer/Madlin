using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Blog;

public class TagEntity : BaseEntity, IDelete
{
    public string? Key { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
    public bool IsDeleted { get ; set ; }=false;
    public ICollection<BlogTagEntity>? BlogTags { get; set; }

}
