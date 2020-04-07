using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core3MVC.Migrations
{
    public partial class Apis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apis",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apis", x => x.ID);
                });

           

           

            migrationBuilder.CreateTable(
                name: "ApiApplicants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiID = table.Column<int>(nullable: false),
                    ApplicantId = table.Column<int>(nullable: false),
                    ApiRequestDated = table.Column<int>(nullable: false),
                    gateId = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiApplicants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiApplicants_Apis_ApiID",
                        column: x => x.ApiID,
                        principalTable: "Apis",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

           
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiApplicants");

          

            migrationBuilder.DropTable(
                name: "Apis");

        }
    }
}
