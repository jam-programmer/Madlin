using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject;

public sealed record ProductCategoryDto
{
    public Guid Id { get; set; }    
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
    public string? DescriptionEn { get; set; }
    public string? DescriptionFa { get; set; }
    public string? MainImagePath { get; set; }
    public IFormFile? MainImageFile { get; set; }
    public string? IconImagePath { get; set; }
    public IFormFile? IconImageFile { get; set; }
    public bool IsFeatured { get; set; }
}
