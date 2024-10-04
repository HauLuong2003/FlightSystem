using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class version4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentTypes_DocumentTypeTypeId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_DocumentTypeTypeId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentTypeTypeId",
                table: "Documents");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TypeId",
                table: "Documents",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentTypes_TypeId",
                table: "Documents",
                column: "TypeId",
                principalTable: "DocumentTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentTypes_TypeId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_TypeId",
                table: "Documents");

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentTypeTypeId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentTypeTypeId",
                table: "Documents",
                column: "DocumentTypeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentTypes_DocumentTypeTypeId",
                table: "Documents",
                column: "DocumentTypeTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
