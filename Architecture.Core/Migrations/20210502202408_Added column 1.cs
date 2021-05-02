using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class Addedcolumn1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LU_RecordStatus",
                columns: new[] { "RecordStatusId", "IsActive", "Name" },
                values: new object[] { 7, true, "Rejected" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LU_RecordStatus",
                keyColumn: "RecordStatusId",
                keyValue: 7);
        }
    }
}
