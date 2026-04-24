using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject
{
    public sealed record ProductItemDto
    {
        public string? TitleEn { get; set; }
        public string? TitleFa { get; set; }
        public string? MainImagePath { get; set; }
        public string? HoverImagePath { get; set; }
        public string? UrlName { get; set; }
        public ulong Price { get; set; }
        public Guid Id { get; set; }    
        public ulong? DiscountPrice { get; set; }
    }
}
