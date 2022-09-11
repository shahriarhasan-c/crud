using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagement.Migrations
{
    public partial class Teachertableupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_Teacher_TeacherId",
                table: "students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "teachers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_teachers",
                table: "teachers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_students_teachers_TeacherId",
                table: "students",
                column: "TeacherId",
                principalTable: "teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_teachers_TeacherId",
                table: "students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_teachers",
                table: "teachers");

            migrationBuilder.RenameTable(
                name: "teachers",
                newName: "Teacher");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_students_Teacher_TeacherId",
                table: "students",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
