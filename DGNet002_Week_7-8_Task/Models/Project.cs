using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DGNet002_Week_7_8_Task.Models
{
    public class Project
    {       
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Title cannot be empty")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description cannot be empty")]
        public string Description { get; set; }        
        public string? Image { get; set; }
        public string ProjectLink { get; set; }        
        public string PublicId { get; set; }

	}
}
