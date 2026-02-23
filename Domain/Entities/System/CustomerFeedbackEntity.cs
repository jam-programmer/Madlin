using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.System
{
    public class CustomerFeedbackEntity : BaseEntity, IDelete
    {
        public string? CustomerName { get; set; }
        public string? Title {  get; set; }
        public string? Comment {  get; set; }
        public int Rating {  get; set; }
        public bool IsDeleted { get; set; }=false;
    }
}
