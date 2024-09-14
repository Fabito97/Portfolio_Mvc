using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DGNet002_Week_7_8_Task.Models
{
    public class Skill
    {
        public int? SkillId { get; set; }
        [Required]
        public string SkillName { get; set; }
        [Required]
        public string Description { get; set; }
      
	}
}
