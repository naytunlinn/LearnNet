using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LearnNet.Models.DataModels
{
    [Table("tbl_DiscussionForums")]
     public class DiscussionForumEntity: BaseEntity
    {
        [Key]
        [StringLength(36)]
        public string DiscussionForumId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [ForeignKey("Course")]
        [StringLength(36)]
        public string CourseId { get; set; }

        [ForeignKey("CourseId")]
        public CourseEntity Course { get; set; }

        // Add other discussion forum-related properties
    }
}
