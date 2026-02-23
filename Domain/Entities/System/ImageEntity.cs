using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.System
{
    public class ImageEntity : BaseEntity,IDelete
    {
        public string? TitleFa { get; set; }
        public string? TitleEn { get; set; }
        public string? FilePath { set; get; }
       
        public bool IsDeleted { get; set; } = false;
    }
}
