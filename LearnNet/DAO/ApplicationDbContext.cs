using LearnNet.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace LearnNet.DAO
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> db) : base(db)
        {

        }
       public DbSet<AssessmentEntity> AssessmentEntities { get; set; }
        public DbSet<CommentEntity> CommentEntities { get; set; }
        public DbSet<CourseEntity> CourseEntities { get; set;}
        public DbSet<DiscussionForumEntity> DiscussionForumEntities { get; set; }
        public DbSet<EnrollmentEntity> EnrollmentEntities { get; set; }
        public DbSet<ModuleEntity> ModuleEntities { get; set; }
        public DbSet<PostEntity> PostEntities { get; set; }
        public DbSet<ResourceEntity> ResourceEntities { get; set; }
        public DbSet<SubmissionEntity> SubmissionEntities { get; set; }

        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<VideoEntity> VideoEntities { get; set; }


    }
}
