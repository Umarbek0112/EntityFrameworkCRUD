using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfTemplateApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CoursesId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourses_Courses_CoursesId",
                table: "TeacherCourses");

            migrationBuilder.DropIndex(
                name: "IX_TeacherCourses_CoursesId",
                table: "TeacherCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_CoursesId",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "CoursesId",
                table: "TeacherCourses");

            migrationBuilder.DropColumn(
                name: "CoursesId",
                table: "StudentCourses");

            migrationBuilder.RenameColumn(
                name: "InsertAt",
                table: "TeacherStudents",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "InsertAt",
                table: "Teachers",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "InsertAt",
                table: "TeacherCourses",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "InsertAt",
                table: "Students",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "InsertAt",
                table: "StudentCourses",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "InsertAt",
                table: "Courses",
                newName: "CreateAt");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_CourseId",
                table: "TeacherCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourses_Courses_CourseId",
                table: "TeacherCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourses_Courses_CourseId",
                table: "TeacherCourses");

            migrationBuilder.DropIndex(
                name: "IX_TeacherCourses_CourseId",
                table: "TeacherCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "TeacherStudents",
                newName: "InsertAt");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Teachers",
                newName: "InsertAt");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "TeacherCourses",
                newName: "InsertAt");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Students",
                newName: "InsertAt");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "StudentCourses",
                newName: "InsertAt");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Courses",
                newName: "InsertAt");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teachers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Teachers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "CoursesId",
                table: "TeacherCourses",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Students",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "CoursesId",
                table: "StudentCourses",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_CoursesId",
                table: "TeacherCourses",
                column: "CoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CoursesId",
                table: "StudentCourses",
                column: "CoursesId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CoursesId",
                table: "StudentCourses",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourses_Courses_CoursesId",
                table: "TeacherCourses",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}
