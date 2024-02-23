using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnNet.Models.DataModels
{
	[Table("tbl_Videos")]
	public class VideoEntity : BaseEntity
	{
		[Key]
		[StringLength(36)]
		public string VideoId { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string VideoUrl { get; set; }

		[Required]
		[ForeignKey("Module")]
		[StringLength(36)]
		public string ModuleId { get; set; }

		[ForeignKey("Course")]
		[StringLength(36)]
		public string CourseId { get; set; }

		[Required]
		public DateTime UploadDate { get; set; }

		// Add other video-related properties
	}
}