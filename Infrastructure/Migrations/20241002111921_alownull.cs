using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class alownull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AlterColumn<Guid>(
                name: "Flight_No",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Document_TypeTypeId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                       name: "PermissionId",
                       table: "Groups",
                       type: "uniqueidentifier",
                       nullable: true,
                       defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                       oldClrType: typeof(Guid),
                       oldType: "uniqueidentifier",
                       oldNullable: false);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
