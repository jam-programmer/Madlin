using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject
{
    public sealed record QuestionDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "عنوان سوال الزامی است")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "پاسخ سوال الزامی است")]
        public string? Description { get; set; }
    }
}
