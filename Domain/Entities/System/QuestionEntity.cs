using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.System
{
    public class QuestionEntity:BaseEntity,IDelete
    {
        public string? Title {  get; set; }
        public string? Description { get; set; }
        public bool IsDeleted {  get; set; }=false;
    }
}
