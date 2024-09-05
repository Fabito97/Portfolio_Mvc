using System.ComponentModel.DataAnnotations;

namespace DGNet002_Week_7_8_Task.Models
{
    public class Resume
    {
        [Key]
        public int ResumeSectionId { get; set; }
        public string SectionName {  get; set; }
        public string Content { get; set; }
        public string Order { get; set; }
    }
}
