using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudNote.Core.SqlServer.Migrations
{
    public partial class _20210331 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Note",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Note",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "Note");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Note",
                newName: "Name");
        }
    }
}
