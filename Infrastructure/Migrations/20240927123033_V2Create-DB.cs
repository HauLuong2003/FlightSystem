using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Document_Types",
                columns: table => new
                {
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document_Types", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Document_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Document_File = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Create_File = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update_File = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Flight_No = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rotue = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Departure_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total_Document = table.Column<int>(type: "int", nullable: false),
                    Point_Of_Loadding = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Point_Of_UnLoadding = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TimeFlight = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Flight_No);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    Permission_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Permission_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions", x => x.Permission_Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role_Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Setting_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Captcha = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Setting_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document_Types");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
