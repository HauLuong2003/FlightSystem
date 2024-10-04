using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Document_Types_Document_TypeTypeId",
                table: "Documents");

 

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_TypeTypeId",
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

            migrationBuilder.AlterColumn<Guid>(
                name: "Document_TypeTypeId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Document_Types_Document_TypeTypeId",
                table: "Documents",
                column: "Document_TypeTypeId",
                principalTable: "Document_Types",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
