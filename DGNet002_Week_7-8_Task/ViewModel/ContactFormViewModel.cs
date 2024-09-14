using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DGNet002_Week_7_8_Task.ViewModel
{
    public class ContactFormViewModel
    {
        public int ContactFormId { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        [DisplayName("Phone Number")]
        [Phone]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter your Message")]
        public string Message { get; set; }
        public DateTime DateSubmitted { get; set; }
    }
}
