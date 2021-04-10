using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class Addedcolumninfamilyinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "ProfFamilyInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "ProfFamilyInfo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfFamilyInfo_GenderId",
                table: "ProfFamilyInfo",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfFamilyInfo_ProvinceId",
                table: "ProfFamilyInfo",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfFamilyInfo_LU_Gender_GenderId",
                table: "ProfFamilyInfo",
                column: "GenderId",
                principalTable: "LU_Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfFamilyInfo_LU_Province_ProvinceId",
                table: "ProfFamilyInfo",
                column: "ProvinceId",
                principalTable: "LU_Province",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfFamilyInfo_LU_Gender_GenderId",
                table: "ProfFamilyInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfFamilyInfo_LU_Province_ProvinceId",
                table: "ProfFamilyInfo");

            migrationBuilder.DropIndex(
                name: "IX_ProfFamilyInfo_GenderId",
                table: "ProfFamilyInfo");

            migrationBuilder.DropIndex(
                name: "IX_ProfFamilyInfo_ProvinceId",
                table: "ProfFamilyInfo");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "ProfFamilyInfo");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "ProfFamilyInfo");
        }
    }
}
