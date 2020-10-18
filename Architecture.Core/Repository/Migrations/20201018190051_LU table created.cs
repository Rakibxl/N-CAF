using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Repository.Migrations
{
    public partial class LUtablecreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LU_AssetType",
                columns: table => new
                {
                    AssetTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_AssetType", x => x.AssetTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_ISEEClassType",
                columns: table => new
                {
                    ISEEClassTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISEEClassTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_ISEEClassType", x => x.ISEEClassTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_JobDeliveryType",
                columns: table => new
                {
                    JobDeliveryTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobDeliveryTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_JobDeliveryType", x => x.JobDeliveryTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_MotiveType",
                columns: table => new
                {
                    MotiveTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotiveTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_MotiveType", x => x.MotiveTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_OwnerType",
                columns: table => new
                {
                    OwnerTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_OwnerType", x => x.OwnerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_WorkerType",
                columns: table => new
                {
                    WorkerTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkerTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_WorkerType", x => x.WorkerTypeId);
                });

            migrationBuilder.InsertData(
                table: "LU_AssetType",
                columns: new[] { "AssetTypeId", "AssetTypeName", "IsActive" },
                values: new object[,]
                {
                    { 1, "House", true },
                    { 2, "Car", true }
                });

            migrationBuilder.InsertData(
                table: "LU_ISEEClassType",
                columns: new[] { "ISEEClassTypeId", "ISEEClassTypeName", "IsActive" },
                values: new object[,]
                {
                    { 1, "High", true },
                    { 2, "Middle", true },
                    { 3, "Low", true }
                });

            migrationBuilder.InsertData(
                table: "LU_JobDeliveryType",
                columns: new[] { "JobDeliveryTypeId", "IsActive", "JobDeliveryTypeName" },
                values: new object[,]
                {
                    { 1, true, "Quick" },
                    { 2, true, "Urgent" },
                    { 3, true, "Normal" }
                });

            migrationBuilder.InsertData(
                table: "LU_MotiveType",
                columns: new[] { "MotiveTypeId", "IsActive", "MotiveTypeName" },
                values: new object[,]
                {
                    { 1, true, "Occupation" },
                    { 2, true, "Family" },
                    { 3, true, "Worker" }
                });

            migrationBuilder.InsertData(
                table: "LU_OwnerType",
                columns: new[] { "OwnerTypeId", "IsActive", "OwnerTypeName" },
                values: new object[,]
                {
                    { 1, true, "By Birth" },
                    { 2, true, "Buy" }
                });

            migrationBuilder.InsertData(
                table: "LU_WorkerType",
                columns: new[] { "WorkerTypeId", "IsActive", "WorkerTypeName" },
                values: new object[,]
                {
                    { 1, true, "Company Worker" },
                    { 2, true, "Domestic Worker" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LU_AssetType");

            migrationBuilder.DropTable(
                name: "LU_ISEEClassType");

            migrationBuilder.DropTable(
                name: "LU_JobDeliveryType");

            migrationBuilder.DropTable(
                name: "LU_MotiveType");

            migrationBuilder.DropTable(
                name: "LU_OwnerType");

            migrationBuilder.DropTable(
                name: "LU_WorkerType");
        }
    }
}
