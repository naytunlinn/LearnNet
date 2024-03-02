using LearnNet.Models.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearnNet.DAO
{
    //IdentityDbContext<IdentityUser, IdentityRole, string>
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> db) : base(db)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Enable sensitive data logging and specify your database provider and connection string
            optionsBuilder
                .EnableSensitiveDataLogging()
                .UseSqlServer("server=Franco;Database=LearnNetDB;User Id=sa;Password=sasa");
        }

        public DbSet<AssessmentEntity> Assessments { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<DiscussionForumEntity> DiscussionForums { get; set; }
        public DbSet<EnrollmentEntity> Enrollments { get; set; }
        public DbSet<ModuleEntity> Modules { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<ResourceEntity> Resources { get; set; }
        public DbSet<SubmissionEntity> Submissions { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<VideoEntity> Videos { get; set; }
    }
}