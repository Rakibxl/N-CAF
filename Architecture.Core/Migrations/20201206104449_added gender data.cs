using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class addedgenderdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LU_Gender",
                columns: new[] { "GenderId", "IsActive", "Name" },
                values: new object[] { 2, true, "Female" });

            migrationBuilder.InsertData(
                table: "LU_Gender",
                columns: new[] { "GenderId", "IsActive", "Name" },
                values: new object[] { 3, true, "Other" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LU_Gender",
                keyColumn: "GenderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LU_Gender",
                keyColumn: "GenderId",
                keyValue: 3);
        }
    }
}
