using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject
{
    public sealed record CustomerFeedbackDto
    {
        public Guid Id { get; set; }
        public string? CustomerName { get; set; }
        public string? Title { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }
    }
}
