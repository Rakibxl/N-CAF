using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class BranchInfoIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "ProfBasicInfos");

            migrationBuilder.AddColumn<int>(
                name: "BranchInfoId",
                table: "ProfBasicInfos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchInfoId",
                table: "ProfBasicInfos");

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "ProfBasicInfos",
                type: "int",
                nullable: true);
        }
    }
}
