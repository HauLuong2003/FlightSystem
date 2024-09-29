using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back_End.Migrations
{
    /// <inheritdoc />
    public partial class VD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            

            migrationBuilder.DropPrimaryKey(
                name: "PK_permissions",
                table: "permissions");

         

            migrationBuilder.RenameTable(
                name: "permissions",
                newName: "Permissions");

            migrationBuilder.RenameIndex(
                name: "IX_permissions_GroupId",
                table: "Permissions",
                newName: "IX_Permissions_GroupId");

            migrationBuilder.RenameColumn(
                name: "Update_File",
                table: "Documents",
                newName: "Update_at");

            migrationBuilder.RenameColumn(
                name: "Create_File",
                table: "Documents",
                newName: "Create_at");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_Flight_No",
                table: "Documents",
                column: "Flight_No");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Flights_Flight_No",
                table: "Documents",
                column: "Flight_No",
                principalTable: "Flights",
                principalColumn: "Flight_No",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Groups_GroupId",
                table: "Permissions",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Flights_Flight_No",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Groups_GroupId",
                table: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Documents_Flight_No",
                table: "Documents");

            migrationBuilder.RenameTable(
                name: "Permissions",
                newName: "permissions");

            migrationBuilder.RenameIndex(
                name: "IX_Permissions_GroupId",
                table: "permissions",
                newName: "IX_permissions_GroupId");

            migrationBuilder.RenameColumn(
                name: "Update_at",
                table: "Documents",
                newName: "Update_File");

            migrationBuilder.RenameColumn(
                name: "Create_at",
                table: "Documents",
                newName: "Create_File");

            migrationBuilder.AddColumn<Guid>(
                name: "Flight_No1",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_permissions",
                table: "permissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_Flight_No1",
                table: "Documents",
                column: "Flight_No1");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Flights_Flight_No1",
                table: "Documents",
                column: "Flight_No1",
                principalTable: "Flights",
                principalColumn: "Flight_No",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_permissions_Groups_GroupId",
                table: "permissions",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
