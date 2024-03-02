namespace LearnNet.Models.ViewModels
{
    public class CommentViewModel
    {
        public string CommentId { get; set; }

        public string Content { get; set; }

        public string PostId { get; set; }

        public string StudentId { get; set; }

        public DateTime CommentDate { get; set; }

        public string PostContent { get; set; }

        public DateTime PostDate { get; set; }
    }
}