using LearnNet.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace LearnNet.DAO
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> db) : base(db)
        {

        }
        DbSet<AssessmentEntity> AssessmentEntities { get; set; }
        DbSet<CommentEntity> CommentEntities { get; set; }
        DbSet<CourseEntity> CourseEntities { get; set;}
        DbSet<DiscussionForumEntity> DiscussionForumEntities { get; set; }
        DbSet<EnrollmentEntity> EnrollmentEntities { get; set; }
        DbSet<ModuleEntity> ModuleEntities { get; set; }
        DbSet<PostEntity> PostEntities { get; set; }
        DbSet<ResourceEntity> ResourceEntities { get; set; }    
        DbSet<SubmissionEntity> SubmissionEntities { get; set; }

        DbSet<UserEntity> UserEntities { get; set; }
        DbSet<VideoEntity> VideoEntities { get; set; }


    }
}
