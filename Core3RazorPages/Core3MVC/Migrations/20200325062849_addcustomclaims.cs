using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core3MVC.Migrations
{
    public partial class addcustomclaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "AspNetUserClaims",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "AspNetUserClaims",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AspNetUserClaims",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SiteId",
                table: "AspNetUserClaims",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UId",
                table: "AspNetUserClaims",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "UId",
                table: "AspNetUserClaims");
        }
    }
}
