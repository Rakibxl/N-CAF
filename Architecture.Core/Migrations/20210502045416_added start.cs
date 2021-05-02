using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class addedstart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LU_RecordStatus",
                columns: new[] { "RecordStatusId", "IsActive", "Name" },
                values: new object[] { 6, true, "Pending" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LU_RecordStatus",
                keyColumn: "RecordStatusId",
                keyValue: 6);
        }
    }
}
