using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class v2datbase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Members",
                table: "Groups",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Permission",
                table: "Document_Types",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Members",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Permission",
                table: "Document_Types");
        }
    }
}
