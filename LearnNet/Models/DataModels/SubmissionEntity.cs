using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LearnNet.Models.DataModels
{
    [Table("tbl_Submissions")]
    public class SubmissionEntity : BaseEntity
    {
        [Key]
        [StringLength(36)]
        public string SubmissionId { get; set; }

        [Required]
        [ForeignKey("User")]
        [StringLength(36)]
        public string UserId { get; set; }

        [Required]
        [ForeignKey("Assessment")]
        [StringLength(36)]
        public string AssessmentId { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

       

        // Add other submission-related properties
    }
}
