using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Repository.Migrations
{
    public partial class addedeyecolorlu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LU_EyeColor",
                columns: table => new
                {
                    EyeColorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_EyeColor", x => x.EyeColorId);
                });

            migrationBuilder.UpdateData(
                table: "LU_ContractType",
                keyColumn: "ContractTypeId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_ContractType",
                keyColumn: "ContractTypeId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_ContractType",
                keyColumn: "ContractTypeId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.InsertData(
                table: "LU_EyeColor",
                columns: new[] { "EyeColorId", "Description", "IsActive" },
                values: new object[,]
                {
                    { 1, "Red", true },
                    { 2, "Blue", true },
                    { 3, "Normal", true }
                });

            migrationBuilder.UpdateData(
                table: "LU_Gender",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_HouseCategory",
                keyColumn: "HouseCategoryId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_HouseCategory",
                keyColumn: "HouseCategoryId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_HouseCategory",
                keyColumn: "HouseCategoryId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_HouseType",
                keyColumn: "HouseTypeId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_HouseType",
                keyColumn: "HouseTypeId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_HouseType",
                keyColumn: "HouseTypeId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_IncomeType",
                keyColumn: "IncomeTypeId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_IncomeType",
                keyColumn: "IncomeTypeId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_IncomeType",
                keyColumn: "IncomeTypeId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_JobType",
                keyColumn: "JobTypeId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_JobType",
                keyColumn: "JobTypeId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_JobType",
                keyColumn: "JobTypeId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_LoanInterestType",
                keyColumn: "LoanInterestTypeId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_LoanInterestType",
                keyColumn: "LoanInterestTypeId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_LoanInterestType",
                keyColumn: "LoanInterestTypeId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_MeriatalStatus",
                keyColumn: "MeritalStatusId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_MeriatalStatus",
                keyColumn: "MeritalStatusId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_MeriatalStatus",
                keyColumn: "MeritalStatusId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_NationalIdType",
                keyColumn: "NationalIdTypeId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_NationalIdType",
                keyColumn: "NationalIdTypeId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_NationalIdType",
                keyColumn: "NationalIdTypeId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_Nationality",
                keyColumn: "NationalityId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_Nationality",
                keyColumn: "NationalityId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_Nationality",
                keyColumn: "NationalityId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_OccupationPosition",
                keyColumn: "OccupationPositionId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_OccupationPosition",
                keyColumn: "OccupationPositionId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_OccupationPosition",
                keyColumn: "OccupationPositionId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_OccupationType",
                keyColumn: "OccupationTypeId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_OccupationType",
                keyColumn: "OccupationTypeId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_OccupationType",
                keyColumn: "OccupationTypeId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_ResidenceScope",
                keyColumn: "ResidenceScopeId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_ResidenceScope",
                keyColumn: "ResidenceScopeId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_ResidenceScope",
                keyColumn: "ResidenceScopeId",
                keyValue: 3,
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LU_EyeColor");

            migrationBuilder.UpdateData(
                table: "LU_ContractType",
                keyColumn: "ContractTypeId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_ContractType",
                keyColumn: "ContractTypeId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_ContractType",
                keyColumn: "ContractTypeId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_DocumentType",
                keyColumn: "DocumentTypeId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_Gender",
                keyColumn: "GenderId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_HouseCategory",
                keyColumn: "HouseCategoryId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_HouseCategory",
                keyColumn: "HouseCategoryId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_HouseCategory",
                keyColumn: "HouseCategoryId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_HouseType",
                keyColumn: "HouseTypeId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_HouseType",
                keyColumn: "HouseTypeId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_HouseType",
                keyColumn: "HouseTypeId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_IncomeType",
                keyColumn: "IncomeTypeId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_IncomeType",
                keyColumn: "IncomeTypeId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_IncomeType",
                keyColumn: "IncomeTypeId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_JobType",
                keyColumn: "JobTypeId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_JobType",
                keyColumn: "JobTypeId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_JobType",
                keyColumn: "JobTypeId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_LoanInterestType",
                keyColumn: "LoanInterestTypeId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_LoanInterestType",
                keyColumn: "LoanInterestTypeId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_LoanInterestType",
                keyColumn: "LoanInterestTypeId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_MeriatalStatus",
                keyColumn: "MeritalStatusId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_MeriatalStatus",
                keyColumn: "MeritalStatusId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_MeriatalStatus",
                keyColumn: "MeritalStatusId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_NationalIdType",
                keyColumn: "NationalIdTypeId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_NationalIdType",
                keyColumn: "NationalIdTypeId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_NationalIdType",
                keyColumn: "NationalIdTypeId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_Nationality",
                keyColumn: "NationalityId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_Nationality",
                keyColumn: "NationalityId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_Nationality",
                keyColumn: "NationalityId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_OccupationPosition",
                keyColumn: "OccupationPositionId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_OccupationPosition",
                keyColumn: "OccupationPositionId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_OccupationPosition",
                keyColumn: "OccupationPositionId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_OccupationType",
                keyColumn: "OccupationTypeId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_OccupationType",
                keyColumn: "OccupationTypeId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_OccupationType",
                keyColumn: "OccupationTypeId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_RelationType",
                keyColumn: "RelationTypeId",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_ResidenceScope",
                keyColumn: "ResidenceScopeId",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_ResidenceScope",
                keyColumn: "ResidenceScopeId",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "LU_ResidenceScope",
                keyColumn: "ResidenceScopeId",
                keyValue: 3,
                column: "IsActive",
                value: true);
        }
    }
}
