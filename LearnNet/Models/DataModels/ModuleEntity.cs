using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnNet.Models.DataModels
{
    [Table("tbl_Modules")]
    public class ModuleEntity : BaseEntity
    {
        [Key]
        [StringLength(36)]
        public string ModuleId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [ForeignKey("Course")]
        [StringLength(36)]
        public string CourseId { get; set; }

        [ForeignKey("CourseId")]
        public CourseEntity Course { get; set; }

        // Add other module-related properties
    }
}