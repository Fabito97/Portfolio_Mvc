using System.ComponentModel.DataAnnotations;

namespace DGNet002_Week_7_8_Task.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email address is required. Please provide your email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
