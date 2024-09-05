using System.ComponentModel.DataAnnotations;

namespace DGNet002_Week_7_8_Task.Models
{
    public class Portfolio
    {
        [Key]
        public int ProjectItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ProjectLink { get; set; }

    }
}
