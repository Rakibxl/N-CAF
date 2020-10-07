using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Repository.Migrations
{
    public partial class addedlookuptable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LU_ContractType",
                columns: table => new
                {
                    ContractTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_ContractType", x => x.ContractTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_DocumentType",
                columns: table => new
                {
                    DocumentTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_DocumentType", x => x.DocumentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_Gender",
                columns: table => new
                {
                    GenderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_Gender", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "LU_HouseCategory",
                columns: table => new
                {
                    HouseCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseCategoryName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_HouseCategory", x => x.HouseCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "LU_HouseType",
                columns: table => new
                {
                    HouseTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_HouseType", x => x.HouseTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_IncomeType",
                columns: table => new
                {
                    IncomeTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncomeTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_IncomeType", x => x.IncomeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_JobType",
                columns: table => new
                {
                    JobTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_JobType", x => x.JobTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_LoanInterestType",
                columns: table => new
                {
                    LoanInterestTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanInterestTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_LoanInterestType", x => x.LoanInterestTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_MeriatalStatus",
                columns: table => new
                {
                    MeritalStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_MeriatalStatus", x => x.MeritalStatusId);
                });

            migrationBuilder.CreateTable(
                name: "LU_NationalIdType",
                columns: table => new
                {
                    NationalIdTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalIdTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_NationalIdType", x => x.NationalIdTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_Nationality",
                columns: table => new
                {
                    NationalityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalityName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_Nationality", x => x.NationalityId);
                });

            migrationBuilder.CreateTable(
                name: "LU_OccupationPosition",
                columns: table => new
                {
                    OccupationPositionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OccupationPositionName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_OccupationPosition", x => x.OccupationPositionId);
                });

            migrationBuilder.CreateTable(
                name: "LU_OccupationType",
                columns: table => new
                {
                    OccupationTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OccupationTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_OccupationType", x => x.OccupationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_RelationType",
                columns: table => new
                {
                    RelationTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_RelationType", x => x.RelationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_ResidenceScope",
                columns: table => new
                {
                    ResidenceScopeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResidenceScopeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_ResidenceScope", x => x.ResidenceScopeId);
                });

            migrationBuilder.InsertData(
                table: "LU_ContractType",
                columns: new[] { "ContractTypeId", "ContractTypeName", "IsActive" },
                values: new object[,]
                {
                    { 1, "No Limit", true },
                    { 2, "Limited", true },
                    { 3, "Occational", true }
                });

            migrationBuilder.InsertData(
                table: "LU_DocumentType",
                columns: new[] { "DocumentTypeId", "DocumentName", "IsActive" },
                values: new object[,]
                {
                    { 1, "Passport", true },
                    { 2, "Driving License", true },
                    { 3, "National Id", true }
                });

            migrationBuilder.InsertData(
                table: "LU_Gender",
                columns: new[] { "GenderId", "IsActive", "Name" },
                values: new object[] { 1, true, "Male" });

            migrationBuilder.InsertData(
                table: "LU_HouseCategory",
                columns: new[] { "HouseCategoryId", "HouseCategoryName", "IsActive" },
                values: new object[,]
                {
                    { 2, "House Category 2", true },
                    { 3, "House Category 3", true },
                    { 1, "House Category 1", true }
                });

            migrationBuilder.InsertData(
                table: "LU_HouseType",
                columns: new[] { "HouseTypeId", "HouseTypeName", "IsActive" },
                values: new object[,]
                {
                    { 1, "Rent", true },
                    { 2, "Owner", true },
                    { 3, "Shared Rent", true }
                });

            migrationBuilder.InsertData(
                table: "LU_IncomeType",
                columns: new[] { "IncomeTypeId", "IncomeTypeName", "IsActive" },
                values: new object[,]
                {
                    { 1, "Single Income", true },
                    { 2, "Double Income", true },
                    { 3, "Business Income", true }
                });

            migrationBuilder.InsertData(
                table: "LU_JobType",
                columns: new[] { "JobTypeId", "IsActive", "JobTypeName" },
                values: new object[,]
                {
                    { 3, true, "Occational" },
                    { 1, true, "Part-Time" },
                    { 2, true, "Full-Time" }
                });

            migrationBuilder.InsertData(
                table: "LU_LoanInterestType",
                columns: new[] { "LoanInterestTypeId", "IsActive", "LoanInterestTypeName" },
                values: new object[,]
                {
                    { 2, true, "Variable Interest" },
                    { 3, true, "No Interest" },
                    { 1, true, "Fixed Interest" }
                });

            migrationBuilder.InsertData(
                table: "LU_MeriatalStatus",
                columns: new[] { "MeritalStatusId", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Single" },
                    { 2, true, "Marrid" },
                    { 3, true, "Divorce" }
                });

            migrationBuilder.InsertData(
                table: "LU_NationalIdType",
                columns: new[] { "NationalIdTypeId", "IsActive", "NationalIdTypeName" },
                values: new object[,]
                {
                    { 1, true, "Smart" },
                    { 2, true, "Paper" },
                    { 3, true, "Pending" }
                });

            migrationBuilder.InsertData(
                table: "LU_Nationality",
                columns: new[] { "NationalityId", "IsActive", "NationalityName" },
                values: new object[,]
                {
                    { 3, true, "Indian" },
                    { 1, true, "Bangladeshi" },
                    { 2, true, "Italian" }
                });

            migrationBuilder.InsertData(
                table: "LU_OccupationPosition",
                columns: new[] { "OccupationPositionId", "IsActive", "OccupationPositionName" },
                values: new object[,]
                {
                    { 3, true, "Shareholder" },
                    { 1, true, "UnEmployed" },
                    { 2, true, "Employed" }
                });

            migrationBuilder.InsertData(
                table: "LU_OccupationType",
                columns: new[] { "OccupationTypeId", "IsActive", "OccupationTypeName" },
                values: new object[,]
                {
                    { 1, true, "Occupation Type 1" },
                    { 2, true, "Occupation Type 2" },
                    { 3, true, "Occupation Type 3" }
                });

            migrationBuilder.InsertData(
                table: "LU_RelationType",
                columns: new[] { "RelationTypeId", "IsActive", "RelationTypeName" },
                values: new object[,]
                {
                    { 2, true, "Mother" },
                    { 1, true, "Father" },
                    { 3, true, "Son" }
                });

            migrationBuilder.InsertData(
                table: "LU_ResidenceScope",
                columns: new[] { "ResidenceScopeId", "IsActive", "ResidenceScopeName" },
                values: new object[,]
                {
                    { 2, true, "Out of Itally" },
                    { 1, true, "Itally" },
                    { 3, true, "Not Permanent" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LU_ContractType");

            migrationBuilder.DropTable(
                name: "LU_DocumentType");

            migrationBuilder.DropTable(
                name: "LU_Gender");

            migrationBuilder.DropTable(
                name: "LU_HouseCategory");

            migrationBuilder.DropTable(
                name: "LU_HouseType");

            migrationBuilder.DropTable(
                name: "LU_IncomeType");

            migrationBuilder.DropTable(
                name: "LU_JobType");

            migrationBuilder.DropTable(
                name: "LU_LoanInterestType");

            migrationBuilder.DropTable(
                name: "LU_MeriatalStatus");

            migrationBuilder.DropTable(
                name: "LU_NationalIdType");

            migrationBuilder.DropTable(
                name: "LU_Nationality");

            migrationBuilder.DropTable(
                name: "LU_OccupationPosition");

            migrationBuilder.DropTable(
                name: "LU_OccupationType");

            migrationBuilder.DropTable(
                name: "LU_RelationType");

            migrationBuilder.DropTable(
                name: "LU_ResidenceScope");
        }
    }
}
