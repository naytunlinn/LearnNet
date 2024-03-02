namespace LearnNet.Models.ViewModels
{
    public class StudentViewModel
    {
        public string StudentId { get; set; }

        public string StudentName { get; set; }

        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}