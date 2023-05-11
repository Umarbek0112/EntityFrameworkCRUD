using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfTemplateApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class FKConfMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentCourses_StudentCourseId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_TeacherStudents_TeacherStudentId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_TeacherCourses_TeacherCourseId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_TeacherStudents_TeacherStudentId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_TeacherCourseId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_TeacherStudentId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentCourseId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_TeacherStudentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TeacherCourseId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "TeacherStudentId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "StudentCourseId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TeacherStudentId",
                table: "Students");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherCourseId",
                table: "Teachers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherStudentId",
                table: "Teachers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentCourseId",
                table: "Students",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherStudentId",
                table: "Students",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_TeacherCourseId",
                table: "Teachers",
                column: "TeacherCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_TeacherStudentId",
                table: "Teachers",
                column: "TeacherStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentCourseId",
                table: "Students",
                column: "StudentCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_TeacherStudentId",
                table: "Students",
                column: "TeacherStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentCourses_StudentCourseId",
                table: "Students",
                column: "StudentCourseId",
                principalTable: "StudentCourses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_TeacherStudents_TeacherStudentId",
                table: "Students",
                column: "TeacherStudentId",
                principalTable: "TeacherStudents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_TeacherCourses_TeacherCourseId",
                table: "Teachers",
                column: "TeacherCourseId",
                principalTable: "TeacherCourses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_TeacherStudents_TeacherStudentId",
                table: "Teachers",
                column: "TeacherStudentId",
                principalTable: "TeacherStudents",
                principalColumn: "Id");
        }
    }
}
