using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class lookupchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_LU_AppAppUserType_AppUserTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LU_AppAppUserType",
                table: "LU_AppAppUserType");

            migrationBuilder.RenameTable(
                name: "LU_AppAppUserType",
                newName: "LU_AppUserType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LU_AppUserType",
                table: "LU_AppUserType",
                column: "AppUserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_LU_AppUserType_AppUserTypeId",
                table: "AspNetUsers",
                column: "AppUserTypeId",
                principalTable: "LU_AppUserType",
                principalColumn: "AppUserTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_LU_AppUserType_AppUserTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LU_AppUserType",
                table: "LU_AppUserType");

            migrationBuilder.RenameTable(
                name: "LU_AppUserType",
                newName: "LU_AppAppUserType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LU_AppAppUserType",
                table: "LU_AppAppUserType",
                column: "AppUserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_LU_AppAppUserType_AppUserTypeId",
                table: "AspNetUsers",
                column: "AppUserTypeId",
                principalTable: "LU_AppAppUserType",
                principalColumn: "AppUserTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
