using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class date1correction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfHouseRentInfos_LU_LoanInterestType_LoanInterestTypeId",
                table: "ProfHouseRentInfos");

            migrationBuilder.AlterColumn<int>(
                name: "LoanInterestTypeId",
                table: "ProfHouseRentInfos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfHouseRentInfos_LU_LoanInterestType_LoanInterestTypeId",
                table: "ProfHouseRentInfos",
                column: "LoanInterestTypeId",
                principalTable: "LU_LoanInterestType",
                principalColumn: "LoanInterestTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfHouseRentInfos_LU_LoanInterestType_LoanInterestTypeId",
                table: "ProfHouseRentInfos");

            migrationBuilder.AlterColumn<int>(
                name: "LoanInterestTypeId",
                table: "ProfHouseRentInfos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfHouseRentInfos_LU_LoanInterestType_LoanInterestTypeId",
                table: "ProfHouseRentInfos",
                column: "LoanInterestTypeId",
                principalTable: "LU_LoanInterestType",
                principalColumn: "LoanInterestTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
