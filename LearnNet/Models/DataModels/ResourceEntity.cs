using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LearnNet.Models.DataModels
{
    [Table("tbl_Resources")]
    public class ResourceEntity : BaseEntity
    {
        [Key]
        [StringLength(36)]
        public string ResourceId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [ForeignKey("Module")]
        [StringLength(36)]
        public string ModuleId { get; set; }

        [ForeignKey("ModuleId")]
        public ModuleEntity Module { get; set; }

        [Required]
        public string Type { get; set; } // Example: Video, PDF, etc.

        // Add other resource-related properties
    }
}
