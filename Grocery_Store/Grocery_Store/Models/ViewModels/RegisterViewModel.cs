using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Grocery_Store.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password and Confrim Password does not match.")]
        public string ConfirmPassword { get; set; }

    }
}
