using System.ComponentModel.DataAnnotations.Schema;

namespace DGNet002_Week_7_8_Task.Models
{
	public class Education
	{
		public int EducationId { get; set; }
		public string InstitutionName { get; set; }
		public string Degree { get; set; }
		public DateTime GraduationDate { get; set; }

	}
}
