using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LearnNet.Models.DataModels
{
    [Table("tbl_Courses")]
    public class CourseEntity: BaseEntity
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
