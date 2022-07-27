using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercises.Migrations
{
    /// <inheritdoc />
    public partial class StudentPropChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Students_StudentsId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_EntryPass_EntryPassID",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "EntryPassID",
                table: "Students",
                newName: "EntryPassId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_EntryPassID",
                table: "Students",
                newName: "IX_Students_EntryPassId");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "CourseStudent",
                newName: "StudentsStudentId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudent_StudentsId",
                table: "CourseStudent",
                newName: "IX_CourseStudent_StudentsStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Students_StudentsStudentId",
                table: "CourseStudent",
                column: "StudentsStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_EntryPass_EntryPassId",
                table: "Students",
                column: "EntryPassId",
                principalTable: "EntryPass",
                principalColumn: "EntryPassId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Students_StudentsStudentId",
                table: "CourseStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_EntryPass_EntryPassId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "EntryPassId",
                table: "Students",
                newName: "EntryPassID");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Students",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Students_EntryPassId",
                table: "Students",
                newName: "IX_Students_EntryPassID");

            migrationBuilder.RenameColumn(
                name: "StudentsStudentId",
                table: "CourseStudent",
                newName: "StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudent_StudentsStudentId",
                table: "CourseStudent",
                newName: "IX_CourseStudent_StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Students_StudentsId",
                table: "CourseStudent",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_EntryPass_EntryPassID",
                table: "Students",
                column: "EntryPassID",
                principalTable: "EntryPass",
                principalColumn: "EntryPassId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
