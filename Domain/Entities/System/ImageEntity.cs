using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.System
{
    public class ImageEntity : BaseEntity,IDelete
    {
        public string? FilePath { set; get; }
       
        public bool IsDeleted { get; set; } = false;
    }
}
