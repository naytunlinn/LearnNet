namespace LearnNet.Models.ViewModels
{
    public class AssessmentViewModel
    {
        public string AssessmentId { get; set; }

        public string Title { get; set; }

        public string CourseId { get; set; }

        public string CourseTitle { get; set; }

        public DateTime DueDate { get; set; }
    }
}