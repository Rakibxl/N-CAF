using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class documentdbupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PurposeOfDocument",
                table: "ProfDocumentInfo",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "ProfDocumentInfo",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "ProfDocumentInfo");

            migrationBuilder.AlterColumn<string>(
                name: "PurposeOfDocument",
                table: "ProfDocumentInfo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500);
        }
    }
}
