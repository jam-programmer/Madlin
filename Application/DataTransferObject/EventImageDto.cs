using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject
{
    public sealed record EventImageDto
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public string? Path { get; set; }
        public IFormFile File { get; set; }
    }
}
