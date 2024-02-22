using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnNet.Migrations
{
    public partial class RemoveInstructor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Courses_tbl_Users_InstructorId",
                table: "tbl_Courses");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Courses_InstructorId",
                table: "tbl_Courses");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "tbl_Courses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstructorId",
                table: "tbl_Courses",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Courses_InstructorId",
                table: "tbl_Courses",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Courses_tbl_Users_InstructorId",
                table: "tbl_Courses",
                column: "InstructorId",
                principalTable: "tbl_Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
