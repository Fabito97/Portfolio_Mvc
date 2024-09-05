using System.ComponentModel.DataAnnotations;

namespace DGNet002_Week_7_8_Task.Models
{
    public class ContactDetail
    {
        
        public int ContactDetailId { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public int Order { get; set; }
    }
}
