using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class changedquestiontablecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "QuestionInfos");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "QuestionInfos",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "QuestionInfos");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "QuestionInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
