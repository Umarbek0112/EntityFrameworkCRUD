﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfTemplateApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstsss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourses_Teachers_TeacherId",
                table: "TeacherCourses");

            migrationBuilder.DropColumn(
                name: "TicherId",
                table: "TeacherCourses");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "TeacherCourses",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourses_Teachers_TeacherId",
                table: "TeacherCourses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherCourses_Teachers_TeacherId",
                table: "TeacherCourses");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "TeacherCourses",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "TicherId",
                table: "TeacherCourses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherCourses_Teachers_TeacherId",
                table: "TeacherCourses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
