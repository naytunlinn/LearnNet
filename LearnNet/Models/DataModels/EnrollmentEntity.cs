using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnNet.Models.DataModels
{
    [Table("tbl_Enrollments")]
    public class EnrollmentEntity : BaseEntity
    {
        [Key]
        [StringLength(36)]
        public string EnrollmentId { get; set; }

        [Required]
        [ForeignKey("Student")]
        [StringLength(36)]
        public string StudentId { get; set; }

        [Required]
        [ForeignKey("Course")]
        [StringLength(36)]
        public string CourseId { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        // Add other enrollment-related properties
    }
}