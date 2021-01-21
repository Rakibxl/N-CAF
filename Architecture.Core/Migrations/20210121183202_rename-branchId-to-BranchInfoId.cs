using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class renamebranchIdtoBranchInfoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BranchInfos",
                table: "BranchInfos");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "BranchInfos");

            migrationBuilder.AddColumn<int>(
                name: "BranchInfoId",
                table: "BranchInfos",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BranchInfos",
                table: "BranchInfos",
                column: "BranchInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BranchInfos",
                table: "BranchInfos");

            migrationBuilder.DropColumn(
                name: "BranchInfoId",
                table: "BranchInfos");

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "BranchInfos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BranchInfos",
                table: "BranchInfos",
                column: "BranchId");
        }
    }
}
