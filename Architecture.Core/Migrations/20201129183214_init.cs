using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Examples",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LU_AddressType",
                columns: table => new
                {
                    AddressTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_AddressType", x => x.AddressTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_AppAppUserType",
                columns: table => new
                {
                    AppUserTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserTypeTitle = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_AppAppUserType", x => x.AppUserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_AppUserStatus",
                columns: table => new
                {
                    AppUserStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserStatusTitle = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_AppUserStatus", x => x.AppUserStatusId);
                });

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
                name: "LU_BankName",
                columns: table => new
                {
                    BankNameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankDescription = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_BankName", x => x.BankNameId);
                });

            migrationBuilder.CreateTable(
                name: "LU_ContractType",
                columns: table => new
                {
                    ContractTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_ContractType", x => x.ContractTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_CountryName",
                columns: table => new
                {
                    CountryNameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryDescription = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_CountryName", x => x.CountryNameId);
                });

            migrationBuilder.CreateTable(
                name: "LU_DegreeType",
                columns: table => new
                {
                    DegreeTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_DegreeType", x => x.DegreeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_DocumentType",
                columns: table => new
                {
                    DocumentTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_DocumentType", x => x.DocumentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_EyeColor",
                columns: table => new
                {
                    EyeColorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_EyeColor", x => x.EyeColorId);
                });

            migrationBuilder.CreateTable(
                name: "LU_Gender",
                columns: table => new
                {
                    GenderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
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
                    IsActive = table.Column<bool>(nullable: false)
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
                    IsActive = table.Column<bool>(nullable: false)
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
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_IncomeType", x => x.IncomeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_InsuranceType",
                columns: table => new
                {
                    InsuranceTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_InsuranceType", x => x.InsuranceTypeId);
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
                name: "LU_JobType",
                columns: table => new
                {
                    JobTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
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
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_LoanInterestType", x => x.LoanInterestTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_LoanStatusType",
                columns: table => new
                {
                    LoanStatusTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanStatusTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_LoanStatusType", x => x.LoanStatusTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LU_MeriatalStatus",
                columns: table => new
                {
                    MeritalStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_MeriatalStatus", x => x.MeritalStatusId);
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
                name: "LU_NationalIdType",
                columns: table => new
                {
                    NationalIdTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalIdTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
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
                    IsActive = table.Column<bool>(nullable: false)
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
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_OccupationPosition", x => x.OccupationPositionId);
                });

            migrationBuilder.CreateTable(
                name: "LU_OccupationPositionType",
                columns: table => new
                {
                    OccupationPositionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_OccupationPositionType", x => x.OccupationPositionId);
                });

            migrationBuilder.CreateTable(
                name: "LU_OccupationType",
                columns: table => new
                {
                    OccupationTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OccupationTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_OccupationType", x => x.OccupationTypeId);
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
                name: "LU_RelationType",
                columns: table => new
                {
                    RelationTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationTypeName = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
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
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LU_ResidenceScope", x => x.ResidenceScopeId);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SurName = table.Column<string>(nullable: true),
                    GenderId = table.Column<int>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    LastPassword = table.Column<string>(nullable: true),
                    LastPassChangeDate = table.Column<DateTime>(nullable: true),
                    AppUserStatusId = table.Column<int>(nullable: true),
                    AppUserTypeId = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    IsLocked = table.Column<bool>(nullable: false),
                    BranchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_LU_AppUserStatus_AppUserStatusId",
                        column: x => x.AppUserStatusId,
                        principalTable: "LU_AppUserStatus",
                        principalColumn: "AppUserStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_LU_AppAppUserType_AppUserTypeId",
                        column: x => x.AppUserTypeId,
                        principalTable: "LU_AppAppUserType",
                        principalColumn: "AppUserTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BranchInfos",
                columns: table => new
                {
                    BranchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    BranchLocation = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    ContactPerson = table.Column<string>(maxLength: 100, nullable: false),
                    ContactNumber = table.Column<string>(maxLength: 100, nullable: false),
                    AgreementStart = table.Column<DateTime>(type: "Date", nullable: true),
                    NumberOfUser = table.Column<int>(nullable: true),
                    IsLocked = table.Column<bool>(nullable: true, defaultValue: false),
                    Note = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchInfos", x => x.BranchId);
                    table.ForeignKey(
                        name: "FK_BranchInfos_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfBasicInfos",
                columns: table => new
                {
                    ProfileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    RefId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    SurName = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    TaxCode = table.Column<string>(maxLength: 100, nullable: false),
                    TaxCodeStartDate = table.Column<DateTime>(type: "Date", nullable: true),
                    TaxCodeEndDate = table.Column<DateTime>(type: "Date", nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 100, nullable: false),
                    GenderId = table.Column<int>(nullable: true),
                    MaritalStatusId = table.Column<int>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    PostalElectronicCertificate = table.Column<string>(maxLength: 100, nullable: true),
                    CityOfBirth = table.Column<string>(maxLength: 100, nullable: true),
                    StateOfBirth = table.Column<string>(maxLength: 100, nullable: true),
                    BirthStateCode = table.Column<string>(maxLength: 100, nullable: true),
                    NationalityId = table.Column<int>(nullable: true),
                    CitizenStateCode = table.Column<string>(maxLength: 100, nullable: true),
                    EyeColorId = table.Column<int>(nullable: true),
                    testData = table.Column<int>(nullable: true),
                    Height = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m),
                    ZipCode = table.Column<string>(maxLength: 100, nullable: true),
                    MotiveTypeId = table.Column<int>(nullable: true),
                    OccupationTypeId = table.Column<int>(nullable: true),
                    OccupationPositionId = table.Column<int>(nullable: true),
                    HasUnEmployedCertificate = table.Column<bool>(nullable: false, defaultValue: false),
                    UnEmployedCertificateIssuesDate = table.Column<DateTime>(type: "Date", nullable: true),
                    HasAnyUnEmployedFacility = table.Column<bool>(nullable: true, defaultValue: false),
                    ContractTypeId = table.Column<int>(nullable: true),
                    YearlyIncome = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m),
                    IsPregnant = table.Column<bool>(nullable: false, defaultValue: false),
                    ExpectedBabyBirthDate = table.Column<DateTime>(type: "Date", nullable: true),
                    IsRentHouse = table.Column<bool>(nullable: false, defaultValue: false),
                    HowManyHouseRent = table.Column<int>(nullable: true),
                    IsHouseOwner = table.Column<bool>(nullable: false, defaultValue: false),
                    HouseCountryName = table.Column<string>(maxLength: 100, nullable: true),
                    HouseCityName = table.Column<string>(maxLength: 100, nullable: true),
                    HasVehicle = table.Column<bool>(nullable: false, defaultValue: false),
                    CarSerialNumber = table.Column<string>(maxLength: 100, nullable: true),
                    CarNumberPlate = table.Column<string>(maxLength: 100, nullable: true),
                    HasVehicleInsurance = table.Column<bool>(nullable: true, defaultValue: false),
                    IsCompanyOwner = table.Column<bool>(nullable: false, defaultValue: false),
                    HasWorker = table.Column<bool>(nullable: true, defaultValue: false),
                    DigitalVatCode = table.Column<string>(maxLength: 100, nullable: true),
                    HasAppliedForCitizenship = table.Column<bool>(nullable: false, defaultValue: false),
                    BranchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfBasicInfos", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_ProfBasicInfos_LU_ContractType_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "LU_ContractType",
                        principalColumn: "ContractTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfBasicInfos_LU_EyeColor_EyeColorId",
                        column: x => x.EyeColorId,
                        principalTable: "LU_EyeColor",
                        principalColumn: "EyeColorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfBasicInfos_LU_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "LU_Gender",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfBasicInfos_LU_MeriatalStatus_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "LU_MeriatalStatus",
                        principalColumn: "MeritalStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfBasicInfos_LU_MotiveType_MotiveTypeId",
                        column: x => x.MotiveTypeId,
                        principalTable: "LU_MotiveType",
                        principalColumn: "MotiveTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfBasicInfos_LU_Nationality_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "LU_Nationality",
                        principalColumn: "NationalityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfBasicInfos_LU_OccupationPosition_OccupationPositionId",
                        column: x => x.OccupationPositionId,
                        principalTable: "LU_OccupationPosition",
                        principalColumn: "OccupationPositionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfBasicInfos_LU_OccupationType_OccupationTypeId",
                        column: x => x.OccupationTypeId,
                        principalTable: "LU_OccupationType",
                        principalColumn: "OccupationTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfBasicInfos_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfAddressInfos",
                columns: table => new
                {
                    AddressInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    AddressTypeId = table.Column<int>(nullable: true),
                    RoadName = table.Column<string>(maxLength: 100, nullable: false),
                    RoadNo = table.Column<string>(maxLength: 100, nullable: false),
                    BuildingNo = table.Column<string>(maxLength: 100, nullable: false),
                    FloorNo = table.Column<string>(maxLength: 100, nullable: true),
                    AppartmentNo = table.Column<string>(maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 100, nullable: false),
                    CityName = table.Column<string>(maxLength: 100, nullable: false),
                    Province = table.Column<string>(maxLength: 100, nullable: false),
                    State = table.Column<string>(maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Active = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfAddressInfos", x => x.AddressInfoId);
                    table.ForeignKey(
                        name: "FK_ProfAddressInfos_LU_AddressType_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "LU_AddressType",
                        principalColumn: "AddressTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfAddressInfos_ProfBasicInfos_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "ProfBasicInfos",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfAddressInfos_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfAssetInfos",
                columns: table => new
                {
                    AssetInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    AssetTypeId = table.Column<int>(nullable: true),
                    NumberOfAsset = table.Column<int>(nullable: false),
                    EquivalentMoneyMax = table.Column<int>(nullable: false),
                    EquivalentMoneyMin = table.Column<int>(nullable: false),
                    MoneyAverage = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    OwnerTypeId = table.Column<int>(nullable: false),
                    OwnershipPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    OwnerFromDate = table.Column<DateTime>(type: "Date", nullable: false),
                    RentAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    UseAblePercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    AnyRestrictionByGovt = table.Column<string>(maxLength: 100, nullable: true),
                    CityName = table.Column<string>(maxLength: 100, nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfAssetInfos", x => x.AssetInfoId);
                    table.ForeignKey(
                        name: "FK_ProfAssetInfos_LU_AssetType_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalTable: "LU_AssetType",
                        principalColumn: "AssetTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfAssetInfos_LU_OwnerType_OwnerTypeId",
                        column: x => x.OwnerTypeId,
                        principalTable: "LU_OwnerType",
                        principalColumn: "OwnerTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfAssetInfos_ProfBasicInfos_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "ProfBasicInfos",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfAssetInfos_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfBankInfos",
                columns: table => new
                {
                    BankInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    BankNameId = table.Column<int>(nullable: true),
                    BranchName = table.Column<string>(maxLength: 100, nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 100, nullable: true),
                    SwiftNumber = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfBankInfos", x => x.BankInfoId);
                    table.ForeignKey(
                        name: "FK_ProfBankInfos_LU_BankName_BankNameId",
                        column: x => x.BankNameId,
                        principalTable: "LU_BankName",
                        principalColumn: "BankNameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfBankInfos_ProfBasicInfos_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "ProfBasicInfos",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfBankInfos_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfDelegationInfos",
                columns: table => new
                {
                    DelegationInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    SurName = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    TaxCode = table.Column<string>(maxLength: 100, nullable: false),
                    RefNo = table.Column<string>(maxLength: 100, nullable: true),
                    Purpose = table.Column<string>(maxLength: 100, nullable: true),
                    DocumentIssueDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "Date", nullable: false),
                    IssuedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfDelegationInfos", x => x.DelegationInfoId);
                    table.ForeignKey(
                        name: "FK_ProfDelegationInfos_ProfBasicInfos_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "ProfBasicInfos",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfDelegationInfos_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfDocumentInfo",
                columns: table => new
                {
                    DocumentInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    DocumentTypeId = table.Column<int>(nullable: true),
                    DocumentName = table.Column<string>(nullable: true),
                    IssuedBy = table.Column<string>(maxLength: 100, nullable: true),
                    IssuedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "Date", nullable: false),
                    PurposeOfDocument = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfDocumentInfo", x => x.DocumentInfoId);
                    table.ForeignKey(
                        name: "FK_ProfDocumentInfo_LU_DocumentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "LU_DocumentType",
                        principalColumn: "DocumentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfDocumentInfo_ProfBasicInfos_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "ProfBasicInfos",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfDocumentInfo_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfEducationInfos",
                columns: table => new
                {
                    EducationInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    DegreeTypeId = table.Column<int>(nullable: true),
                    InstitutionName = table.Column<string>(maxLength: 100, nullable: false),
                    StartYear = table.Column<DateTime>(type: "Date", nullable: false),
                    EndYear = table.Column<DateTime>(type: "Date", nullable: false),
                    UniversityAddress = table.Column<string>(maxLength: 500, nullable: true),
                    ActivitiesAndSocieties = table.Column<string>(maxLength: 500, nullable: true),
                    Result = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfEducationInfos", x => x.EducationInfoId);
                    table.ForeignKey(
                        name: "FK_ProfEducationInfos_LU_DegreeType_DegreeTypeId",
                        column: x => x.DegreeTypeId,
                        principalTable: "LU_DegreeType",
                        principalColumn: "DegreeTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfEducationInfos_ProfBasicInfos_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "ProfBasicInfos",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfEducationInfos_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfFamilyInfo",
                columns: table => new
                {
                    FamilyInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
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
                    PreviousNationalityId = table.Column<int>(nullable: true),
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
                    table.PrimaryKey("PK_ProfFamilyInfo", x => x.FamilyInfoId);
                    table.ForeignKey(
                        name: "FK_ProfFamilyInfo_LU_Nationality_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "LU_Nationality",
                        principalColumn: "NationalityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfFamilyInfo_LU_OccupationType_OccupationTypeId",
                        column: x => x.OccupationTypeId,
                        principalTable: "LU_OccupationType",
                        principalColumn: "OccupationTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfFamilyInfo_LU_Nationality_PreviousNationalityId",
                        column: x => x.PreviousNationalityId,
                        principalTable: "LU_Nationality",
                        principalColumn: "NationalityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfFamilyInfo_ProfBasicInfos_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "ProfBasicInfos",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfFamilyInfo_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfFamilyInfo_LU_RelationType_RelationTypeId",
                        column: x => x.RelationTypeId,
                        principalTable: "LU_RelationType",
                        principalColumn: "RelationTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfFamilyInfo_LU_ResidenceScope_ResidenceScopeId",
                        column: x => x.ResidenceScopeId,
                        principalTable: "LU_ResidenceScope",
                        principalColumn: "ResidenceScopeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfHouseRentInfos",
                columns: table => new
                {
                    HouseRentInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    ContractDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ContractTypeId = table.Column<int>(nullable: true),
                    HouseTypeId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: true),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: true),
                    MonthlyRentAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ServiceChargeAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    RegistrationInfo = table.Column<string>(maxLength: 100, nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "Date", nullable: true),
                    RegistrationOffice = table.Column<string>(maxLength: 100, nullable: true),
                    RegistrationCode = table.Column<string>(maxLength: 100, nullable: true),
                    RegistrationNo = table.Column<string>(maxLength: 100, nullable: true),
                    RegistrationCity = table.Column<string>(maxLength: 100, nullable: true),
                    IsJoined = table.Column<bool>(nullable: true),
                    SharePercent = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    FoglioNo = table.Column<string>(maxLength: 100, nullable: true),
                    PartiocellaNo = table.Column<string>(maxLength: 100, nullable: true),
                    SubNo = table.Column<string>(maxLength: 100, nullable: true),
                    SectionNo = table.Column<string>(maxLength: 100, nullable: true),
                    HouseCategoryId = table.Column<int>(nullable: true),
                    Zona = table.Column<string>(maxLength: 100, nullable: true),
                    MicroZona = table.Column<string>(maxLength: 100, nullable: true),
                    Consistenza = table.Column<string>(maxLength: 100, nullable: true),
                    SuperficieCatastale = table.Column<string>(maxLength: 100, nullable: true),
                    Rendita = table.Column<string>(maxLength: 100, nullable: true),
                    NotaioInfo = table.Column<string>(maxLength: 100, nullable: true),
                    HasLoan = table.Column<bool>(nullable: true),
                    LoanStatusTypeID = table.Column<int>(nullable: false),
                    LoanStartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    LoanAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    LoanInterestTypeId = table.Column<int>(nullable: false),
                    LoanPeriod = table.Column<int>(nullable: true),
                    IsRentByOwner = table.Column<bool>(nullable: false),
                    RentAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfHouseRentInfos", x => x.HouseRentInfoId);
                    table.ForeignKey(
                        name: "FK_ProfHouseRentInfos_LU_ContractType_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "LU_ContractType",
                        principalColumn: "ContractTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfHouseRentInfos_LU_HouseCategory_HouseCategoryId",
                        column: x => x.HouseCategoryId,
                        principalTable: "LU_HouseCategory",
                        principalColumn: "HouseCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfHouseRentInfos_LU_HouseType_HouseTypeId",
                        column: x => x.HouseTypeId,
                        principalTable: "LU_HouseType",
                        principalColumn: "HouseTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfHouseRentInfos_LU_LoanInterestType_LoanInterestTypeId",
                        column: x => x.LoanInterestTypeId,
                        principalTable: "LU_LoanInterestType",
                        principalColumn: "LoanInterestTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfHouseRentInfos_LU_LoanStatusType_LoanStatusTypeID",
                        column: x => x.LoanStatusTypeID,
                        principalTable: "LU_LoanStatusType",
                        principalColumn: "LoanStatusTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfHouseRentInfos_ProfBasicInfos_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "ProfBasicInfos",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfHouseRentInfos_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfIncomeInfo",
                columns: table => new
                {
                    IncomeInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    IncomeTypeId = table.Column<int>(nullable: true),
                    YearlyIncome = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    MonthlyIncome = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Year = table.Column<DateTime>(type: "date", nullable: false),
                    Month = table.Column<DateTime>(type: "date", nullable: false),
                    Document = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfIncomeInfo", x => x.IncomeInfoId);
                    table.ForeignKey(
                        name: "FK_ProfIncomeInfo_LU_IncomeType_IncomeTypeId",
                        column: x => x.IncomeTypeId,
                        principalTable: "LU_IncomeType",
                        principalColumn: "IncomeTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfIncomeInfo_ProfBasicInfos_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "ProfBasicInfos",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfIncomeInfo_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfInsuranceInfos",
                columns: table => new
                {
                    InsuranceInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    InsuranceTypeId = table.Column<int>(nullable: true),
                    InsuranceTitle = table.Column<string>(maxLength: 100, nullable: false),
                    InsuranceAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m),
                    InsuranceReturnPercentage = table.Column<string>(maxLength: 100, nullable: true),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfInsuranceInfos", x => x.InsuranceInfoId);
                    table.ForeignKey(
                        name: "FK_ProfInsuranceInfos_LU_InsuranceType_InsuranceTypeId",
                        column: x => x.InsuranceTypeId,
                        principalTable: "LU_InsuranceType",
                        principalColumn: "InsuranceTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfInsuranceInfos_ProfBasicInfos_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "ProfBasicInfos",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfInsuranceInfos_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfISEEInfos",
                columns: table => new
                {
                    ISEEInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    ISEEClassTypeId = table.Column<int>(nullable: true),
                    ISEEValue = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Point = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ISEEFamilyIncome = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ISPAmount = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ISEAmount = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ISRAmount = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    IdentificationNumber = table.Column<string>(maxLength: 100, nullable: false),
                    SubmittedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfISEEInfos", x => x.ISEEInfoId);
                    table.ForeignKey(
                        name: "FK_ProfISEEInfos_LU_ISEEClassType_ISEEClassTypeId",
                        column: x => x.ISEEClassTypeId,
                        principalTable: "LU_ISEEClassType",
                        principalColumn: "ISEEClassTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfISEEInfos_ProfBasicInfos_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "ProfBasicInfos",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfISEEInfos_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfLegalInfos",
                columns: table => new
                {
                    LegalInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    CountryNameId = table.Column<int>(nullable: true),
                    CityName = table.Column<string>(maxLength: 100, nullable: false),
                    IsAnyCase = table.Column<bool>(nullable: true),
                    RefNo = table.Column<string>(maxLength: 100, nullable: true),
                    Reason = table.Column<string>(maxLength: 100, nullable: true),
                    Note = table.Column<string>(maxLength: 500, nullable: true),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfLegalInfos", x => x.LegalInfoId);
                    table.ForeignKey(
                        name: "FK_ProfLegalInfos_LU_CountryName_CountryNameId",
                        column: x => x.CountryNameId,
                        principalTable: "LU_CountryName",
                        principalColumn: "CountryNameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfLegalInfos_ProfBasicInfos_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "ProfBasicInfos",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfLegalInfos_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfMovementInfos",
                columns: table => new
                {
                    MovementInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    CountryNameId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Purpose = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfMovementInfos", x => x.MovementInfoId);
                    table.ForeignKey(
                        name: "FK_ProfMovementInfos_LU_CountryName_CountryNameId",
                        column: x => x.CountryNameId,
                        principalTable: "LU_CountryName",
                        principalColumn: "CountryNameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfMovementInfos_ProfBasicInfos_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "ProfBasicInfos",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfMovementInfos_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfOccupationInfo",
                columns: table => new
                {
                    OccupationInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    JobTypeId = table.Column<int>(nullable: true),
                    JobHour = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ContractTypeId = table.Column<int>(nullable: true),
                    ContractStartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ContractEndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    CompanyName = table.Column<string>(maxLength: 100, nullable: false),
                    VATNo = table.Column<string>(maxLength: 100, nullable: true),
                    LegalCompanyAddress = table.Column<string>(maxLength: 500, nullable: true),
                    OfficeAddress = table.Column<string>(maxLength: 500, nullable: true),
                    BranchAddress = table.Column<string>(maxLength: 500, nullable: true),
                    ChamberOfCommerceRegNo = table.Column<string>(maxLength: 100, nullable: true),
                    ChamberOfCommerceCityName = table.Column<string>(maxLength: 100, nullable: true),
                    REANo = table.Column<string>(maxLength: 100, nullable: true),
                    ATECONo = table.Column<string>(maxLength: 100, nullable: true),
                    SCIANo = table.Column<string>(maxLength: 100, nullable: true),
                    SCIACityName = table.Column<string>(maxLength: 100, nullable: true),
                    IsShareHolder = table.Column<bool>(nullable: true),
                    PercentageOfShare = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    NotaioInfo = table.Column<string>(maxLength: 100, nullable: true),
                    CompanyRepresentative = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfOccupationInfo", x => x.OccupationInfoId);
                    table.ForeignKey(
                        name: "FK_ProfOccupationInfo_LU_ContractType_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "LU_ContractType",
                        principalColumn: "ContractTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfOccupationInfo_LU_JobType_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "LU_JobType",
                        principalColumn: "JobTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfOccupationInfo_ProfBasicInfos_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "ProfBasicInfos",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfOccupationInfo_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfWorkerInfos",
                columns: table => new
                {
                    WorkerInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    WorkerTypeId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    SurName = table.Column<string>(maxLength: 100, nullable: false),
                    TaxCode = table.Column<string>(maxLength: 100, nullable: false),
                    ContractNumber = table.Column<string>(maxLength: 100, nullable: false),
                    MonthlySalary = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfWorkerInfos", x => x.WorkerInfoId);
                    table.ForeignKey(
                        name: "FK_ProfWorkerInfos_ProfBasicInfos_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "ProfBasicInfos",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfWorkerInfos_RecordStatus_RecordStatusId",
                        column: x => x.RecordStatusId,
                        principalTable: "RecordStatus",
                        principalColumn: "RecordStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfWorkerInfos_LU_WorkerType_WorkerTypeId",
                        column: x => x.WorkerTypeId,
                        principalTable: "LU_WorkerType",
                        principalColumn: "WorkerTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "LU_AddressType",
                columns: new[] { "AddressTypeId", "AddressTypeName", "IsActive" },
                values: new object[,]
                {
                    { 1, "Permanent", true },
                    { 2, "Temporary", true },
                    { 3, "Previous Permanent", true }
                });

            migrationBuilder.InsertData(
                table: "LU_AppAppUserType",
                columns: new[] { "AppUserTypeId", "AppUserTypeTitle", "IsActive" },
                values: new object[,]
                {
                    { 1, "Client", true },
                    { 2, "Branch User", true },
                    { 3, "Other", true }
                });

            migrationBuilder.InsertData(
                table: "LU_AppUserStatus",
                columns: new[] { "AppUserStatusId", "AppUserStatusTitle", "IsActive" },
                values: new object[,]
                {
                    { 1, "Approved", true },
                    { 2, "Rejected", true },
                    { 3, "Request For Approval", true }
                });

            migrationBuilder.InsertData(
                table: "LU_AssetType",
                columns: new[] { "AssetTypeId", "AssetTypeName", "IsActive" },
                values: new object[,]
                {
                    { 2, "Car", true },
                    { 1, "House", true }
                });

            migrationBuilder.InsertData(
                table: "LU_BankName",
                columns: new[] { "BankNameId", "BankDescription", "IsActive" },
                values: new object[,]
                {
                    { 1, "UniCredit Bank", true },
                    { 2, "Intesa San Paolo", true },
                    { 3, "UBI Bank", true }
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
                table: "LU_CountryName",
                columns: new[] { "CountryNameId", "CountryDescription", "IsActive" },
                values: new object[,]
                {
                    { 3, "Germany", true },
                    { 1, "Italy", true },
                    { 2, "Bangladesh", true }
                });

            migrationBuilder.InsertData(
                table: "LU_DegreeType",
                columns: new[] { "DegreeTypeId", "DegreeTypeName", "IsActive" },
                values: new object[,]
                {
                    { 3, "High School", true },
                    { 2, "Masters", true },
                    { 1, "Bachelor", true }
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
                table: "LU_EyeColor",
                columns: new[] { "EyeColorId", "Description", "IsActive" },
                values: new object[,]
                {
                    { 1, "Red", true },
                    { 2, "Blue", true },
                    { 3, "Normal", true }
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
                table: "LU_ISEEClassType",
                columns: new[] { "ISEEClassTypeId", "ISEEClassTypeName", "IsActive" },
                values: new object[,]
                {
                    { 1, "High", true },
                    { 2, "Middle", true },
                    { 3, "Low", true }
                });

            migrationBuilder.InsertData(
                table: "LU_IncomeType",
                columns: new[] { "IncomeTypeId", "IncomeTypeName", "IsActive" },
                values: new object[,]
                {
                    { 3, "Business Income", true },
                    { 1, "Single Income", true },
                    { 2, "Double Income", true }
                });

            migrationBuilder.InsertData(
                table: "LU_InsuranceType",
                columns: new[] { "InsuranceTypeId", "Description", "IsActive" },
                values: new object[,]
                {
                    { 3, "Health Insurance", true },
                    { 2, "Home Insurance", true },
                    { 1, "Car Insurance", true }
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
                table: "LU_JobType",
                columns: new[] { "JobTypeId", "IsActive", "JobTypeName" },
                values: new object[,]
                {
                    { 1, true, "Part-Time" },
                    { 2, true, "Full-Time" },
                    { 3, true, "Occational" }
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
                table: "LU_LoanStatusType",
                columns: new[] { "LoanStatusTypeId", "IsActive", "LoanStatusTypeName" },
                values: new object[,]
                {
                    { 1, true, "Pending" },
                    { 2, true, "Active" },
                    { 3, true, "Past Due" }
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
                table: "LU_MotiveType",
                columns: new[] { "MotiveTypeId", "IsActive", "MotiveTypeName" },
                values: new object[,]
                {
                    { 3, true, "Worker" },
                    { 1, true, "Occupation" },
                    { 2, true, "Family" }
                });

            migrationBuilder.InsertData(
                table: "LU_NationalIdType",
                columns: new[] { "NationalIdTypeId", "IsActive", "NationalIdTypeName" },
                values: new object[,]
                {
                    { 2, true, "Paper" },
                    { 3, true, "Pending" },
                    { 1, true, "Smart" }
                });

            migrationBuilder.InsertData(
                table: "LU_Nationality",
                columns: new[] { "NationalityId", "IsActive", "NationalityName" },
                values: new object[,]
                {
                    { 1, true, "Bangladeshi" },
                    { 2, true, "Italian" },
                    { 3, true, "Indian" }
                });

            migrationBuilder.InsertData(
                table: "LU_OccupationPosition",
                columns: new[] { "OccupationPositionId", "IsActive", "OccupationPositionName" },
                values: new object[,]
                {
                    { 1, true, "UnEmployed" },
                    { 2, true, "Employed" },
                    { 3, true, "Shareholder" }
                });

            migrationBuilder.InsertData(
                table: "LU_OccupationPositionType",
                columns: new[] { "OccupationPositionId", "Description", "IsActive" },
                values: new object[,]
                {
                    { 1, "Manager", true },
                    { 2, "Worker", true },
                    { 3, "Employee", true }
                });

            migrationBuilder.InsertData(
                table: "LU_OccupationType",
                columns: new[] { "OccupationTypeId", "IsActive", "OccupationTypeName" },
                values: new object[,]
                {
                    { 2, true, "Occupation Type 2" },
                    { 3, true, "Occupation Type 3" },
                    { 1, true, "Occupation Type 1" }
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
                table: "LU_RelationType",
                columns: new[] { "RelationTypeId", "IsActive", "RelationTypeName" },
                values: new object[,]
                {
                    { 1, true, "Father" },
                    { 2, true, "Mother" },
                    { 3, true, "Son" }
                });

            migrationBuilder.InsertData(
                table: "LU_ResidenceScope",
                columns: new[] { "ResidenceScopeId", "IsActive", "ResidenceScopeName" },
                values: new object[,]
                {
                    { 1, true, "Itally" },
                    { 2, true, "Out of Itally" },
                    { 3, true, "Not Permanent" }
                });

            migrationBuilder.InsertData(
                table: "LU_WorkerType",
                columns: new[] { "WorkerTypeId", "IsActive", "WorkerTypeName" },
                values: new object[,]
                {
                    { 1, true, "Company Worker" },
                    { 2, true, "Domestic Worker" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AppUserStatusId",
                table: "AspNetUsers",
                column: "AppUserStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AppUserTypeId",
                table: "AspNetUsers",
                column: "AppUserTypeId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BranchInfos_RecordStatusId",
                table: "BranchInfos",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfAddressInfos_AddressTypeId",
                table: "ProfAddressInfos",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfAddressInfos_ProfileId",
                table: "ProfAddressInfos",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfAddressInfos_RecordStatusId",
                table: "ProfAddressInfos",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfAssetInfos_AssetTypeId",
                table: "ProfAssetInfos",
                column: "AssetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfAssetInfos_OwnerTypeId",
                table: "ProfAssetInfos",
                column: "OwnerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfAssetInfos_ProfileId",
                table: "ProfAssetInfos",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfAssetInfos_RecordStatusId",
                table: "ProfAssetInfos",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfBankInfos_BankNameId",
                table: "ProfBankInfos",
                column: "BankNameId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfBankInfos_ProfileId",
                table: "ProfBankInfos",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfBankInfos_RecordStatusId",
                table: "ProfBankInfos",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfBasicInfos_ContractTypeId",
                table: "ProfBasicInfos",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfBasicInfos_EyeColorId",
                table: "ProfBasicInfos",
                column: "EyeColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfBasicInfos_GenderId",
                table: "ProfBasicInfos",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfBasicInfos_MaritalStatusId",
                table: "ProfBasicInfos",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfBasicInfos_MotiveTypeId",
                table: "ProfBasicInfos",
                column: "MotiveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfBasicInfos_NationalityId",
                table: "ProfBasicInfos",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfBasicInfos_OccupationPositionId",
                table: "ProfBasicInfos",
                column: "OccupationPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfBasicInfos_OccupationTypeId",
                table: "ProfBasicInfos",
                column: "OccupationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfBasicInfos_RecordStatusId",
                table: "ProfBasicInfos",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfDelegationInfos_ProfileId",
                table: "ProfDelegationInfos",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfDelegationInfos_RecordStatusId",
                table: "ProfDelegationInfos",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfDocumentInfo_DocumentTypeId",
                table: "ProfDocumentInfo",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfDocumentInfo_ProfileId",
                table: "ProfDocumentInfo",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfDocumentInfo_RecordStatusId",
                table: "ProfDocumentInfo",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfEducationInfos_DegreeTypeId",
                table: "ProfEducationInfos",
                column: "DegreeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfEducationInfos_ProfileId",
                table: "ProfEducationInfos",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfEducationInfos_RecordStatusId",
                table: "ProfEducationInfos",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfFamilyInfo_NationalityId",
                table: "ProfFamilyInfo",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfFamilyInfo_OccupationTypeId",
                table: "ProfFamilyInfo",
                column: "OccupationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfFamilyInfo_PreviousNationalityId",
                table: "ProfFamilyInfo",
                column: "PreviousNationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfFamilyInfo_ProfileId",
                table: "ProfFamilyInfo",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfFamilyInfo_RecordStatusId",
                table: "ProfFamilyInfo",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfFamilyInfo_RelationTypeId",
                table: "ProfFamilyInfo",
                column: "RelationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfFamilyInfo_ResidenceScopeId",
                table: "ProfFamilyInfo",
                column: "ResidenceScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfHouseRentInfos_ContractTypeId",
                table: "ProfHouseRentInfos",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfHouseRentInfos_HouseCategoryId",
                table: "ProfHouseRentInfos",
                column: "HouseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfHouseRentInfos_HouseTypeId",
                table: "ProfHouseRentInfos",
                column: "HouseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfHouseRentInfos_LoanInterestTypeId",
                table: "ProfHouseRentInfos",
                column: "LoanInterestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfHouseRentInfos_LoanStatusTypeID",
                table: "ProfHouseRentInfos",
                column: "LoanStatusTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProfHouseRentInfos_ProfileId",
                table: "ProfHouseRentInfos",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfHouseRentInfos_RecordStatusId",
                table: "ProfHouseRentInfos",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfIncomeInfo_IncomeTypeId",
                table: "ProfIncomeInfo",
                column: "IncomeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfIncomeInfo_ProfileId",
                table: "ProfIncomeInfo",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfIncomeInfo_RecordStatusId",
                table: "ProfIncomeInfo",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfInsuranceInfos_InsuranceTypeId",
                table: "ProfInsuranceInfos",
                column: "InsuranceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfInsuranceInfos_ProfileId",
                table: "ProfInsuranceInfos",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfInsuranceInfos_RecordStatusId",
                table: "ProfInsuranceInfos",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfISEEInfos_ISEEClassTypeId",
                table: "ProfISEEInfos",
                column: "ISEEClassTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfISEEInfos_ProfileId",
                table: "ProfISEEInfos",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfISEEInfos_RecordStatusId",
                table: "ProfISEEInfos",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfLegalInfos_CountryNameId",
                table: "ProfLegalInfos",
                column: "CountryNameId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfLegalInfos_ProfileId",
                table: "ProfLegalInfos",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfLegalInfos_RecordStatusId",
                table: "ProfLegalInfos",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfMovementInfos_CountryNameId",
                table: "ProfMovementInfos",
                column: "CountryNameId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfMovementInfos_ProfileId",
                table: "ProfMovementInfos",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfMovementInfos_RecordStatusId",
                table: "ProfMovementInfos",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfOccupationInfo_ContractTypeId",
                table: "ProfOccupationInfo",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfOccupationInfo_JobTypeId",
                table: "ProfOccupationInfo",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfOccupationInfo_ProfileId",
                table: "ProfOccupationInfo",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfOccupationInfo_RecordStatusId",
                table: "ProfOccupationInfo",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfWorkerInfos_ProfileId",
                table: "ProfWorkerInfos",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfWorkerInfos_RecordStatusId",
                table: "ProfWorkerInfos",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfWorkerInfos_WorkerTypeId",
                table: "ProfWorkerInfos",
                column: "WorkerTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BranchInfos");

            migrationBuilder.DropTable(
                name: "Examples");

            migrationBuilder.DropTable(
                name: "LU_JobDeliveryType");

            migrationBuilder.DropTable(
                name: "LU_NationalIdType");

            migrationBuilder.DropTable(
                name: "LU_OccupationPositionType");

            migrationBuilder.DropTable(
                name: "ProfAddressInfos");

            migrationBuilder.DropTable(
                name: "ProfAssetInfos");

            migrationBuilder.DropTable(
                name: "ProfBankInfos");

            migrationBuilder.DropTable(
                name: "ProfDelegationInfos");

            migrationBuilder.DropTable(
                name: "ProfDocumentInfo");

            migrationBuilder.DropTable(
                name: "ProfEducationInfos");

            migrationBuilder.DropTable(
                name: "ProfFamilyInfo");

            migrationBuilder.DropTable(
                name: "ProfHouseRentInfos");

            migrationBuilder.DropTable(
                name: "ProfIncomeInfo");

            migrationBuilder.DropTable(
                name: "ProfInsuranceInfos");

            migrationBuilder.DropTable(
                name: "ProfISEEInfos");

            migrationBuilder.DropTable(
                name: "ProfLegalInfos");

            migrationBuilder.DropTable(
                name: "ProfMovementInfos");

            migrationBuilder.DropTable(
                name: "ProfOccupationInfo");

            migrationBuilder.DropTable(
                name: "ProfWorkerInfos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "LU_AddressType");

            migrationBuilder.DropTable(
                name: "LU_AssetType");

            migrationBuilder.DropTable(
                name: "LU_OwnerType");

            migrationBuilder.DropTable(
                name: "LU_BankName");

            migrationBuilder.DropTable(
                name: "LU_DocumentType");

            migrationBuilder.DropTable(
                name: "LU_DegreeType");

            migrationBuilder.DropTable(
                name: "LU_RelationType");

            migrationBuilder.DropTable(
                name: "LU_ResidenceScope");

            migrationBuilder.DropTable(
                name: "LU_HouseCategory");

            migrationBuilder.DropTable(
                name: "LU_HouseType");

            migrationBuilder.DropTable(
                name: "LU_LoanInterestType");

            migrationBuilder.DropTable(
                name: "LU_LoanStatusType");

            migrationBuilder.DropTable(
                name: "LU_IncomeType");

            migrationBuilder.DropTable(
                name: "LU_InsuranceType");

            migrationBuilder.DropTable(
                name: "LU_ISEEClassType");

            migrationBuilder.DropTable(
                name: "LU_CountryName");

            migrationBuilder.DropTable(
                name: "LU_JobType");

            migrationBuilder.DropTable(
                name: "ProfBasicInfos");

            migrationBuilder.DropTable(
                name: "LU_WorkerType");

            migrationBuilder.DropTable(
                name: "LU_AppUserStatus");

            migrationBuilder.DropTable(
                name: "LU_AppAppUserType");

            migrationBuilder.DropTable(
                name: "LU_ContractType");

            migrationBuilder.DropTable(
                name: "LU_EyeColor");

            migrationBuilder.DropTable(
                name: "LU_Gender");

            migrationBuilder.DropTable(
                name: "LU_MeriatalStatus");

            migrationBuilder.DropTable(
                name: "LU_MotiveType");

            migrationBuilder.DropTable(
                name: "LU_Nationality");

            migrationBuilder.DropTable(
                name: "LU_OccupationPosition");

            migrationBuilder.DropTable(
                name: "LU_OccupationType");

            migrationBuilder.DropTable(
                name: "RecordStatus");
        }
    }
}
