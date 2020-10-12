using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Repository.Migrations
{
    public partial class CreatedFamilyInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecordStatusId",
                table: "ProfBasicInfos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RecordStatus",
                columns: table => new
                {
                    RecordStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordStatus", x => x.RecordStatusId);
                });

            migrationBuilder.CreateTable(
                name: "ProfFamilyInfos",
                columns: table => new
                {
                    FamilyInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    RelationTypeId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    SurName = table.Column<string>(maxLength: 100, nullable: false),
                    TaxCode = table.Column<string>(maxLength: 100, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    PlaceOfBirth = table.Column<string>(maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 100, nullable: true),
                    OccupationTypeId = table.Column<int>(nullable: true),
                    NationlityId = table.Column<int>(nullable: true),
                    NationalityId = table.Column<int>(nullable: true),
                    PreviousNationality = table.Column<string>(maxLength: 100, nullable: true),
                    ResidenceScopeId = table.Column<int>(nullable: true),
                    IsDependent = table.Column<bool>(nullable: false),
                    DependentPercentage = table.Column<decimal>(type: "decimal(3,2)", nullable: false, defaultValue: 0m),
                    IsDisabled = table.Column<bool>(nullable: false),
                    DisabledPercentage = table.Column<decimal>(type: "decimal(3,2)", nullable: false, defaultValue: 0m),
                    YearlyIncome = table.Column<decimal>(type: "decimal(8,2)", nullable: false, defaultValue: 0m),
                    IsAppliedForCitizenship = table.Column<bool>(nullable: false),
                    ApplicationCode = table.Column<string>(maxLength: 100, nullable: true),
                    ApplicationDate = table.Column<DateTime>(nullable: true),
                    ApplicationCity = table.Column<string>(maxLength: 100, nullable: true),
                    ApplicationPlacedAddress = table.Column<string>(maxLength: 500, nullable: true),
                    ApplicationFileNumber = table.Column<string>(maxLength: 100, nullable: true),
                    ApplicationPlacedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfFamilyInfos", x => x.FamilyInfoId);
                    table.ForeignKey(
                        name: "FK_ProfFamilyInfos_LU_Nationality_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "LU_Nationality",
                        principalColumn: "NationalityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfFamilyInfos_LU_OccupationType_OccupationTypeId",
                        column: x => x.OccupationTypeId,
                        principalTable: "LU_OccupationType",
                        principalColumn: "OccupationTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfFamilyInfos_ProfBasicInfos_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "ProfBasicInfos",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfFamilyInfos_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfFamilyInfos_LU_RelationType_RelationTypeId",
                        column: x => x.RelationTypeId,
                        principalTable: "LU_RelationType",
                        principalColumn: "RelationTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfFamilyInfos_LU_ResidenceScope_ResidenceScopeId",
                        column: x => x.ResidenceScopeId,
                        principalTable: "LU_ResidenceScope",
                        principalColumn: "ResidenceScopeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfBasicInfos_RecordStatusId",
                table: "ProfBasicInfos",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfFamilyInfos_NationalityId",
                table: "ProfFamilyInfos",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfFamilyInfos_OccupationTypeId",
                table: "ProfFamilyInfos",
                column: "OccupationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfFamilyInfos_ProfileId",
                table: "ProfFamilyInfos",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfFamilyInfos_RecordStatusId",
                table: "ProfFamilyInfos",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfFamilyInfos_RelationTypeId",
                table: "ProfFamilyInfos",
                column: "RelationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfFamilyInfos_ResidenceScopeId",
                table: "ProfFamilyInfos",
                column: "ResidenceScopeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfBasicInfos_RecordStatus_RecordStatusId",
                table: "ProfBasicInfos",
                column: "RecordStatusId",
                principalTable: "RecordStatus",
                principalColumn: "RecordStatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfBasicInfos_RecordStatus_RecordStatusId",
                table: "ProfBasicInfos");

            migrationBuilder.DropTable(
                name: "ProfFamilyInfos");

            migrationBuilder.DropTable(
                name: "RecordStatus");

            migrationBuilder.DropIndex(
                name: "IX_ProfBasicInfos_RecordStatusId",
                table: "ProfBasicInfos");

            migrationBuilder.DropColumn(
                name: "RecordStatusId",
                table: "ProfBasicInfos");
        }
    }
}
