using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class AddedColumnOperatorBranchId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OperatorBranchId",
                table: "OperatorBranches",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperatorBranches",
                table: "OperatorBranches",
                column: "OperatorBranchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OperatorBranches",
                table: "OperatorBranches");

            migrationBuilder.DropColumn(
                name: "OperatorBranchId",
                table: "OperatorBranches");
        }
    }
}
