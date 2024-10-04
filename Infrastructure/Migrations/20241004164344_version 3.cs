using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class version3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TypeId",
                table: "Documents",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_TypeId",
                table: "Documents",
                column: "TypeId",
                principalTable: "Document_Types",
                principalColumn: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Document_Types_Document_TypeTypeId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_Document_TypeTypeId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Document_TypeTypeId",
                table: "Documents");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TypeId",
                table: "Documents",
                column: "TypeId");


        }
    }
}
