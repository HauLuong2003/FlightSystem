using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class changeforegin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Groups_GroupId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_GroupId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Permissions");

            migrationBuilder.AddColumn<Guid>(
                name: "PermissionId",
                table: "Groups",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Groups_PermissionId",
                table: "Groups",
                column: "PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Permissions_PermissionId",
                table: "Groups",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "PermissionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Permissions_PermissionId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_PermissionId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "PermissionId",
                table: "Groups");

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_GroupId",
                table: "Permissions",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Groups_GroupId",
                table: "Permissions",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
