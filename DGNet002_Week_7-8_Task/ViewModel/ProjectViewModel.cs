using System.ComponentModel.DataAnnotations;

namespace DGNet002_Week_7_8_Task.ViewModel
{
	public class ProjectViewModel
	{
		[Key]
		public int ProjectItemId { get; set; }

		[Required(ErrorMessage = "Title cannot be empty")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Description cannot be empty")]
		public string Description { get; set; }

		[Required(ErrorMessage = "Please upload an image")]
		public IFormFile Image { get; set; }
		public string? ProjectLink { get; set; }
		public string? PublicId { get; set; }
		public string? ProjectUrl { get; set; }

	}
}
