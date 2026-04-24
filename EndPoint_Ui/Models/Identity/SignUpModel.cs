

using EndPoint_Ui.Resources.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Models.Identity
{
    public class SignUpModel
    {


        [Required(ErrorMessageResourceName = "UserName", ErrorMessageResourceType = typeof(SignUpResource))]

        public string? UserName { get; set; }

        [Required(ErrorMessageResourceName = "Email", ErrorMessageResourceType = typeof(SignUpResource))]

        public string? Email { get; set; }

        [Required(ErrorMessageResourceName = "PhoneNumber", ErrorMessageResourceType = typeof(SignUpResource))]

        public string? PhoneNumber { get; set; }

        [Required(ErrorMessageResourceName = "Password", ErrorMessageResourceType = typeof(SignUpResource))]

        public string? Password { get; set; }

        [Required(ErrorMessageResourceName = "Terms", ErrorMessageResourceType = typeof(SignUpResource))]

        public bool Terms { get; set; }
    }
}
