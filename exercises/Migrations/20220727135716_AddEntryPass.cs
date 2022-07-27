using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercises.Migrations
{
    /// <inheritdoc />
    public partial class AddEntryPass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_EntryPass_EntryPassDocId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "EntryPassDocId",
                table: "Students",
                newName: "EntryPassID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_EntryPassDocId",
                table: "Students",
                newName: "IX_Students_EntryPassID");

            migrationBuilder.RenameColumn(
                name: "DocId",
                table: "EntryPass",
                newName: "EntryPassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_EntryPass_EntryPassID",
                table: "Students",
                column: "EntryPassID",
                principalTable: "EntryPass",
                principalColumn: "EntryPassId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_EntryPass_EntryPassID",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "EntryPassID",
                table: "Students",
                newName: "EntryPassDocId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_EntryPassID",
                table: "Students",
                newName: "IX_Students_EntryPassDocId");

            migrationBuilder.RenameColumn(
                name: "EntryPassId",
                table: "EntryPass",
                newName: "DocId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_EntryPass_EntryPassDocId",
                table: "Students",
                column: "EntryPassDocId",
                principalTable: "EntryPass",
                principalColumn: "DocId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
