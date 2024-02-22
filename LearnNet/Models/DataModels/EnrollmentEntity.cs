using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LearnNet.Models.DataModels
{
    [Table("tbl_Enrollments")]
    public class EnrollmentEntity: BaseEntity
    {
        [Key]
        [StringLength(36)]
        public string EnrollmentId { get; set; }

        [Required]
        [ForeignKey("User")]
        [StringLength(36)]
        public string UserId { get; set; }

        [Required]
        [ForeignKey("Course")]
        [StringLength(36)]
        public string CourseId { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

      

        // Add other enrollment-related properties
    }
}
