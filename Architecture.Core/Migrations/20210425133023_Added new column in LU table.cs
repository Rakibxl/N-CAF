using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class AddednewcolumninLUtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "VisibleForAdmin",
                table: "LU_AppUserType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "LU_AppUserType",
                keyColumn: "AppUserTypeId",
                keyValue: 1,
                column: "VisibleForAdmin",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_AppUserType",
                keyColumn: "AppUserTypeId",
                keyValue: 3,
                column: "VisibleForAdmin",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisibleForAdmin",
                table: "LU_AppUserType");
        }
    }
}
