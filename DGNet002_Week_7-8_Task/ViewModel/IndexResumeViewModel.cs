using DGNet002_Week_7_8_Task.Models;

namespace DGNet002_Week_7_8_Task.ViewModel
{
    public class IndexResumeViewModel
    {
        public Resume? Resumes {  get; set; }
        public List<Education> Educations { get; set; }
        public List<WorkExperience> WorkExperiences { get; set; }

        public IndexResumeViewModel()
        {
            Educations = new List<Education>();
            WorkExperiences = new List<WorkExperience>();
        }
    }

    
}
