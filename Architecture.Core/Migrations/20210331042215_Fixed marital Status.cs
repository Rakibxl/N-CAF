using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class FixedmaritalStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfBasicInfos_LU_MeriatalStatus_MaritalStatusId",
                table: "ProfBasicInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LU_MeriatalStatus",
                table: "LU_MeriatalStatus");

            migrationBuilder.DeleteData(
                table: "LU_MeriatalStatus",
                keyColumn: "MeritalStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LU_MeriatalStatus",
                keyColumn: "MeritalStatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LU_MeriatalStatus",
                keyColumn: "MeritalStatusId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "MeritalStatusId",
                table: "LU_MeriatalStatus");

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatusId",
                table: "LU_MeriatalStatus",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LU_MeriatalStatus",
                table: "LU_MeriatalStatus",
                column: "MaritalStatusId");

            migrationBuilder.InsertData(
                table: "LU_MeriatalStatus",
                columns: new[] { "MaritalStatusId", "IsActive", "Name" },
                values: new object[] { 1, true, "Single" });

            migrationBuilder.InsertData(
                table: "LU_MeriatalStatus",
                columns: new[] { "MaritalStatusId", "IsActive", "Name" },
                values: new object[] { 2, true, "Marrid" });

            migrationBuilder.InsertData(
                table: "LU_MeriatalStatus",
                columns: new[] { "MaritalStatusId", "IsActive", "Name" },
                values: new object[] { 3, true, "Divorce" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProfBasicInfos_LU_MeriatalStatus_MaritalStatusId",
                table: "ProfBasicInfos",
                column: "MaritalStatusId",
                principalTable: "LU_MeriatalStatus",
                principalColumn: "MaritalStatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfBasicInfos_LU_MeriatalStatus_MaritalStatusId",
                table: "ProfBasicInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LU_MeriatalStatus",
                table: "LU_MeriatalStatus");

            migrationBuilder.DeleteData(
                table: "LU_MeriatalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LU_MeriatalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LU_MeriatalStatus",
                keyColumn: "MaritalStatusId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "MaritalStatusId",
                table: "LU_MeriatalStatus");

            migrationBuilder.AddColumn<int>(
                name: "MeritalStatusId",
                table: "LU_MeriatalStatus",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LU_MeriatalStatus",
                table: "LU_MeriatalStatus",
                column: "MeritalStatusId");

            migrationBuilder.InsertData(
                table: "LU_MeriatalStatus",
                columns: new[] { "MeritalStatusId", "IsActive", "Name" },
                values: new object[] { 1, true, "Single" });

            migrationBuilder.InsertData(
                table: "LU_MeriatalStatus",
                columns: new[] { "MeritalStatusId", "IsActive", "Name" },
                values: new object[] { 2, true, "Marrid" });

            migrationBuilder.InsertData(
                table: "LU_MeriatalStatus",
                columns: new[] { "MeritalStatusId", "IsActive", "Name" },
                values: new object[] { 3, true, "Divorce" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProfBasicInfos_LU_MeriatalStatus_MaritalStatusId",
                table: "ProfBasicInfos",
                column: "MaritalStatusId",
                principalTable: "LU_MeriatalStatus",
                principalColumn: "MeritalStatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
