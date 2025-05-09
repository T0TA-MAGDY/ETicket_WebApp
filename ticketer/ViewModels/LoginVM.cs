using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ticketer.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="Email Adress")]
        [Required(ErrorMessage ="Email Adress is Required")]
        public string EmailAdress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
