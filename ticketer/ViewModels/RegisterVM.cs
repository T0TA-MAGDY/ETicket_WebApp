using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ticketer.ViewModels
{
    public class RegisterVM
    {
        [Display(Name="Full Name")]
        [Required(ErrorMessage ="Full Name is Required")]
        public string Name { get; set; }
        [Display(Name="Email Adress")]
        [Required(ErrorMessage ="Email Adress is required")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }


    }
}
