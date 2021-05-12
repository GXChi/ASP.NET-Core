using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudNote.Core.SqlServer.Migrations
{
    public partial class _202158 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsreName",
                table: "User",
                newName: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "User",
                newName: "UsreName");
        }
    }
}
