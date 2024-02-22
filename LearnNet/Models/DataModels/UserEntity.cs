using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LearnNet.Models.DataModels
{
    [Table("tbl_Users")]
    public class UserEntity : BaseEntity
    {
        [Key]
        [StringLength(36)]
        public string UserId { get; set; }


        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        // Add other user-related properties
    }
}
