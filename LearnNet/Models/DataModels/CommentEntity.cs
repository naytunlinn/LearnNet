using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LearnNet.Models.DataModels
{
    [Table("tbl_Comments")]
    public class CommentEntity: BaseEntity
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
        public string UserId { get; set; }

        [Required]
        public DateTime CommentDate { get; set; }

        [ForeignKey("PostId")]
        public PostEntity Post { get; set; }

        // Add other comment-related properties
    }
}
