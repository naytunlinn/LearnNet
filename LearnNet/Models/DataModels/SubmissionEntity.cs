using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnNet.Models.DataModels
{
    [Table("tbl_Submissions")]
    public class SubmissionEntity : BaseEntity
    {
        [Key]
        [StringLength(36)]
        public string SubmissionId { get; set; }

        [Required]
        [ForeignKey("Student")]
        [StringLength(36)]
        public string StudentId { get; set; }

        [Required]
        [ForeignKey("Assessment")]
        [StringLength(36)]
        public string AssessmentId { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        // Add other submission-related properties
    }
}