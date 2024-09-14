using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DGNet002_Week_7_8_Task.Models
{
    public class AdminUser : IdentityUser
    {
        public string Name { get; set; }      
        public string Address { get; set; }
        public string City { get; set; }
      
    }
}
