using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.System
{
    public class QuestionEntity:BaseEntity,IDelete
    {
        public string? TitleFa {  get; set; }
        public string? DescriptionFa { get; set; }
        public string? TitleEn {  get; set; }
        public string? DescriptionEn { get; set; }
        public bool IsDeleted {  get; set; }=false;
    }
}
