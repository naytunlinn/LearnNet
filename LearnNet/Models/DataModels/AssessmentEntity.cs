using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LearnNet.Models.DataModels
{
    [Table("tbl_Assessments")]
    public class AssessmentEntity:BaseEntity
    {
        [Key]
        [StringLength(36)]
        public string AssessmentId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [ForeignKey("Course")]
        [StringLength(36)]
        public string CourseId { get; set; }

        [ForeignKey("CourseId")]
        public CourseEntity Course { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        // Add other assessment-related properties
    }
}
