using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnNet.Models.DataModels
{
    [Table("tbl_Posts")]
    public class PostEntity : BaseEntity
    {
        [Key]
        [StringLength(36)]
        public string PostId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [ForeignKey("DiscussionForum")]
        [StringLength(36)]
        public string DiscussionForumId { get; set; }

        [ForeignKey("StudentId")]
        [StringLength(36)]
        public string StudentId { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        [ForeignKey("DiscussionForumId")]
        public DiscussionForumEntity DiscussionForum { get; set; }

        // Add other post-related properties
    }
}