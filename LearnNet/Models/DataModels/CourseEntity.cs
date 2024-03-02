using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnNet.Models.DataModels
{
    [Table("tbl_Courses")]
    public class CourseEntity : BaseEntity
    {
        [Key]
        [StringLength(36)]
        public string CourseId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        // Add other course-related properties
    }
}