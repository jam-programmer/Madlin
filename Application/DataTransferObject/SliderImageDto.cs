using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject;

public sealed record SliderImageDto
{
    public Guid Id { get; set; }
    public string? Path { get; set; }
    public string? Link { get; set; }
    public string? Title { get; set; }
    public IFormFile File { get; set; }
   
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
}
