using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnNet.Models.DataModels
{
    [Table("tbl_Comments")]
    public class CommentEntity : BaseEntity
    {
        [Key]
        [StringLength(36)]
        public string CommentId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [ForeignKey("Post")]
        [StringLength(36)]
        public string PostId { get; set; }

        [ForeignKey("UserId")]
        [StringLength(36)]
        public string StudentId { get; set; }

        [Required]
        public DateTime CommentDate { get; set; }

        [ForeignKey("PostId")]
        public PostEntity Post { get; set; }

        // Add other comment-related properties
    }
}