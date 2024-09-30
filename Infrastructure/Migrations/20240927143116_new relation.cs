using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "Permissions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Flight_No",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Flight_No1",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_GroupId",
                table: "Permissions",
                column: "GroupId");

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
                name: "FK_Documents_Flights_Flight_No1",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Groups_GroupId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_GroupId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Documents_Flight_No1",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "Flight_No",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Flight_No1",
                table: "Documents");
        }
    }
}
