using Microsoft.EntityFrameworkCore.Migrations;

namespace Core3MVC.Migrations
{
    public partial class nullableFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApiApplicants_Apis_ApiID",
                table: "ApiApplicants");

            migrationBuilder.AlterColumn<int>(
                name: "ApiID",
                table: "ApiApplicants",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ApiApplicants_Apis_ApiID",
                table: "ApiApplicants",
                column: "ApiID",
                principalTable: "Apis",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApiApplicants_Apis_ApiID",
                table: "ApiApplicants");

            migrationBuilder.AlterColumn<int>(
                name: "ApiID",
                table: "ApiApplicants",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApiApplicants_Apis_ApiID",
                table: "ApiApplicants",
                column: "ApiID",
                principalTable: "Apis",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
