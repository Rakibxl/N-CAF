using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Repository.Migrations
{
    public partial class addedprofBasicInfotable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Examples");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Examples");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Examples",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Examples",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Examples",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProfBasicInfos",
                columns: table => new
                {
                    ProfileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    SurName = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    TaxCode = table.Column<string>(maxLength: 100, nullable: false),
                    TaxCodeStartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    TaxCodeEndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 100, nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    MaritalStatusId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    PostalElectronicCertificate = table.Column<string>(maxLength: 100, nullable: true),
                    CityOfBirth = table.Column<string>(maxLength: 100, nullable: true),
                    StateOfBirth = table.Column<string>(maxLength: 100, nullable: true),
                    BirthStateCode = table.Column<string>(maxLength: 100, nullable: true),
                    NationalityId = table.Column<int>(nullable: false),
                    CitizenStateCode = table.Column<string>(maxLength: 100, nullable: true),
                    EyesColorId = table.Column<string>(nullable: true),
                    Height = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    ZipCode = table.Column<string>(maxLength: 100, nullable: true),
                    MotiveTypeId = table.Column<int>(nullable: false),
                    OccupationTypeId = table.Column<int>(nullable: false),
                    OccupationPositionId = table.Column<int>(nullable: false),
                    HasUnEmployedCertificate = table.Column<bool>(nullable: false),
                    UnEmployedCertificateIssuesDate = table.Column<DateTime>(type: "Date", nullable: false),
                    HasAnyUnEmployedFacility = table.Column<bool>(nullable: false),
                    ContractTypeId = table.Column<int>(nullable: false),
                    YearlyIncome = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    IsRentHouse = table.Column<bool>(nullable: false),
                    HowManyHouseRent = table.Column<int>(nullable: false),
                    IsHouseOwner = table.Column<bool>(nullable: false),
                    HouseCountryName = table.Column<string>(maxLength: 100, nullable: true),
                    HouseCityName = table.Column<string>(maxLength: 100, nullable: true),
                    HasVehicle = table.Column<bool>(nullable: false),
                    CarSerialNumber = table.Column<string>(maxLength: 100, nullable: true),
                    CarNumberPlate = table.Column<string>(maxLength: 100, nullable: true),
                    HasVehicleInsurance = table.Column<bool>(nullable: false),
                    IsCompanyOwner = table.Column<bool>(nullable: false),
                    HasWorker = table.Column<bool>(nullable: false),
                    DigitalVatCode = table.Column<string>(maxLength: 100, nullable: true),
                    HasAppliedForCitizenship = table.Column<bool>(nullable: false),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfBasicInfos", x => x.ProfileId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfBasicInfos");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Examples");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Examples");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Examples",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Examples",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedBy",
                table: "Examples",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
