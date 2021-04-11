using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class datedbupdated3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NationlityId",
                table: "ProfFamilyInfo");

            migrationBuilder.AddColumn<string>(
                name: "NationalityCode",
                table: "LU_Nationality",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "LU_Nationality",
                keyColumn: "NationalityId",
                keyValue: 1,
                column: "NationalityCode",
                value: "BD");

            migrationBuilder.UpdateData(
                table: "LU_Nationality",
                keyColumn: "NationalityId",
                keyValue: 2,
                column: "NationalityCode",
                value: "IT");

            migrationBuilder.UpdateData(
                table: "LU_Nationality",
                keyColumn: "NationalityId",
                keyValue: 3,
                column: "NationalityCode",
                value: "IN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NationalityCode",
                table: "LU_Nationality");

            migrationBuilder.AddColumn<int>(
                name: "NationlityId",
                table: "ProfFamilyInfo",
                type: "int",
                nullable: true);
        }
    }
}
