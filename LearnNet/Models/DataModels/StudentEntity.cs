using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnNet.Models.DataModels
{
    [Table("tbl_Students")]
    public class StudentEntity : BaseEntity
    {
        [Key]
        [StringLength(36)]
        public string StudentId { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        public string Email { get; set; }

        // Add other user-related properties
    }
}