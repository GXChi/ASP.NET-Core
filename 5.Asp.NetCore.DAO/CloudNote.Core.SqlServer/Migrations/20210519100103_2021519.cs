using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudNote.Core.SqlServer.Migrations
{
    public partial class _2021519 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastLoginDate",
                table: "Users",
                newName: "LastLoginDate");

            migrationBuilder.AddColumn<Guid>(
                name: "UserEntityId",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoleEntityId",
                table: "RoleAuthoritys",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserEntityId",
                table: "UserRoles",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAuthoritys_RoleEntityId",
                table: "RoleAuthoritys",
                column: "RoleEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAuthoritys_Roles_RoleEntityId",
                table: "RoleAuthoritys",
                column: "RoleEntityId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserEntityId",
                table: "UserRoles",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleAuthoritys_Roles_RoleEntityId",
                table: "RoleAuthoritys");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserEntityId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_UserEntityId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_RoleAuthoritys_RoleEntityId",
                table: "RoleAuthoritys");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "RoleEntityId",
                table: "RoleAuthoritys");
        }
    }
}
