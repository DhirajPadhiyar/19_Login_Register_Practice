using System.ComponentModel.DataAnnotations;

namespace _19_Login_Register_Practice.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="UserName is required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
