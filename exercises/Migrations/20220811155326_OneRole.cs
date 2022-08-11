using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercises.Migrations
{
    /// <inheritdoc />
    public partial class OneRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Students_StudentId",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Roles",
                newName: "StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_StudentId",
                table: "Roles",
                newName: "IX_Roles_StudentID");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "StudentID",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Students_StudentID",
                table: "Roles",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Students_StudentID",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Roles",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_StudentID",
                table: "Roles",
                newName: "IX_Roles_StudentId");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Roles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Students_StudentId",
                table: "Roles",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId");
        }
    }
}
