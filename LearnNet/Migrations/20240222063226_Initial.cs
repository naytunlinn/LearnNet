using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnNet.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Enrollments", x => x.EnrollmentId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Submissions",
                columns: table => new
                {
                    SubmissionId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    AssessmentId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Submissions", x => x.SubmissionId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Videos",
                columns: table => new
                {
                    VideoId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuleId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Videos", x => x.VideoId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Courses",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstructorId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_tbl_Courses_tbl_Users_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "tbl_Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Assessments",
                columns: table => new
                {
                    AssessmentId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Assessments", x => x.AssessmentId);
                    table.ForeignKey(
                        name: "FK_tbl_Assessments_tbl_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "tbl_Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_DiscussionForums",
                columns: table => new
                {
                    DiscussionForumId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DiscussionForums", x => x.DiscussionForumId);
                    table.ForeignKey(
                        name: "FK_tbl_DiscussionForums_tbl_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "tbl_Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Modules",
                columns: table => new
                {
                    ModuleId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Modules", x => x.ModuleId);
                    table.ForeignKey(
                        name: "FK_tbl_Modules_tbl_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "tbl_Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Posts",
                columns: table => new
                {
                    PostId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscussionForumId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_tbl_Posts_tbl_DiscussionForums_DiscussionForumId",
                        column: x => x.DiscussionForumId,
                        principalTable: "tbl_DiscussionForums",
                        principalColumn: "DiscussionForumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Resources",
                columns: table => new
                {
                    ResourceId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuleId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Resources", x => x.ResourceId);
                    table.ForeignKey(
                        name: "FK_tbl_Resources_tbl_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "tbl_Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Comments",
                columns: table => new
                {
                    CommentId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_tbl_Comments_tbl_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "tbl_Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Assessments_CourseId",
                table: "tbl_Assessments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Comments_PostId",
                table: "tbl_Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Courses_InstructorId",
                table: "tbl_Courses",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DiscussionForums_CourseId",
                table: "tbl_DiscussionForums",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Modules_CourseId",
                table: "tbl_Modules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Posts_DiscussionForumId",
                table: "tbl_Posts",
                column: "DiscussionForumId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Resources_ModuleId",
                table: "tbl_Resources",
                column: "ModuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Assessments");

            migrationBuilder.DropTable(
                name: "tbl_Comments");

            migrationBuilder.DropTable(
                name: "tbl_Enrollments");

            migrationBuilder.DropTable(
                name: "tbl_Resources");

            migrationBuilder.DropTable(
                name: "tbl_Submissions");

            migrationBuilder.DropTable(
                name: "tbl_Videos");

            migrationBuilder.DropTable(
                name: "tbl_Posts");

            migrationBuilder.DropTable(
                name: "tbl_Modules");

            migrationBuilder.DropTable(
                name: "tbl_DiscussionForums");

            migrationBuilder.DropTable(
                name: "tbl_Courses");

            migrationBuilder.DropTable(
                name: "tbl_Users");
        }
    }
}
