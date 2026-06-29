using System.ComponentModel.DataAnnotations;

namespace _19_Login_Register_Practice.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="User name is required.")]
        public string UserName { get; set; }
        [EmailAddress(ErrorMessage ="Enter valid email.")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage ="confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
