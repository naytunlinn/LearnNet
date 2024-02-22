using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

        [ForeignKey("UserId")]
        [StringLength(36)]
        public string UserId { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        [ForeignKey("DiscussionForumId")]
        public DiscussionForumEntity DiscussionForum { get; set; }

        // Add other post-related properties
    }
}
