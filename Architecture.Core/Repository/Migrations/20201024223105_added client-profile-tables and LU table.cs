﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Core.Repository.Migrations
{
    public partial class addedclientprofiletablesandLUtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "ProfAssetInfos",
                columns: table => new
                {
                    AssetInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    AssetTypeId = table.Column<int>(nullable: true),
                    NumberOfAsset = table.Column<int>(nullable: false),
                    EquivalentMoneyMax = table.Column<int>(nullable: false),
                    EquivalentMoneyMin = table.Column<int>(nullable: false),
                    MoneyAverage = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    OwnerTypeId = table.Column<int>(nullable: false),
                    OwnershipPercentage = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    OwnerFromDate = table.Column<DateTime>(type: "Date", nullable: false),
                    RentAmount = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    UseAblePercentage = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
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
                name: "ProfDelegationInfos",
                columns: table => new
                {
                    DelegationInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
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
                name: "ProfDocumentInfos",
                columns: table => new
                {
                    DocumentInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    DocumentTypeId = table.Column<int>(nullable: true),
                    PurposeofDocument = table.Column<string>(maxLength: 100, nullable: false),
                    IssuedBy = table.Column<string>(maxLength: 100, nullable: true),
                    IssueDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfDocumentInfos", x => x.DocumentInfoId);
                    table.ForeignKey(
                        name: "FK_ProfDocumentInfos_LU_DocumentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "LU_DocumentType",
                        principalColumn: "DocumentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfDocumentInfos_ProfBasicInfos_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "ProfBasicInfos",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfDocumentInfos_RecordStatus_RecordStatusId",
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
                    Created = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    IncomeTypeId = table.Column<int>(nullable: true),
                    YearlyIncome = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    MontlyIncome = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
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
                name: "ProfISEEInfos",
                columns: table => new
                {
                    ISEEInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    ISEEClassTypeId = table.Column<int>(nullable: true),
                    ISEEValue = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Point = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    ISEEFamilyIncome = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ISPAmount = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    ISEAmount = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    ISRAmount = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    IdentificationNumber = table.Column<string>(maxLength: 100, nullable: false),
                    SumittedDate = table.Column<DateTime>(type: "Date", nullable: false),
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
                name: "ProfOccupationInfo",
                columns: table => new
                {
                    OccupationInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    JobTypeId = table.Column<int>(nullable: true),
                    JobHour = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
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
                    PercentageOfShare = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
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
                    Created = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    WorkerTypeId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    SurName = table.Column<string>(maxLength: 100, nullable: false),
                    TaxCode = table.Column<string>(maxLength: 100, nullable: false),
                    ContractNumber = table.Column<string>(maxLength: 100, nullable: false),
                    MonthlySalary = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Active = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "ProfAddressInfos",
                columns: table => new
                {
                    AddressInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    AddressTypeId = table.Column<int>(nullable: true),
                    RoadName = table.Column<string>(maxLength: 100, nullable: false),
                    RoadNo = table.Column<string>(maxLength: 100, nullable: false),
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
                name: "ProfBankInfos",
                columns: table => new
                {
                    BankInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    BankNameId = table.Column<int>(nullable: true),
                    BranchName = table.Column<string>(maxLength: 100, nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 100, nullable: true),
                    SwiftNumber = table.Column<string>(maxLength: 100, nullable: true),
                    Active = table.Column<string>(nullable: true)
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
                name: "ProfLegalInfos",
                columns: table => new
                {
                    LegalInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
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
                    Created = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
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
                name: "ProfEducationInfos",
                columns: table => new
                {
                    EducationInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
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
                name: "ProfInsuranceInfos",
                columns: table => new
                {
                    InsuranceInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true, computedColumnSql: "GetUtcDate()"),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    InsuranceTypeId = table.Column<int>(nullable: true),
                    InsuranceTitle = table.Column<string>(maxLength: 100, nullable: false),
                    InsuranceAmount = table.Column<decimal>(type: "decimal(8,2)", nullable: false, defaultValue: 0m),
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
                name: "ProfHouseRentInfos",
                columns: table => new
                {
                    HouseRentInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    RecordStatusId = table.Column<int>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    ContractDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ContractTypeId = table.Column<int>(nullable: true),
                    HouseTypeId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: true),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: true),
                    MonthlyRentAmount = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    ServiceChargeAmount = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    RegistrationInfo = table.Column<string>(maxLength: 100, nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "Date", nullable: true),
                    RegistrationOffice = table.Column<string>(maxLength: 100, nullable: true),
                    RegistrationCode = table.Column<string>(maxLength: 100, nullable: true),
                    RegistrationNo = table.Column<string>(maxLength: 100, nullable: true),
                    RegistrationCity = table.Column<string>(maxLength: 100, nullable: true),
                    IsJoined = table.Column<bool>(nullable: true),
                    SharePercent = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
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
                    LoanAmount = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    LoanInterestTypeId = table.Column<int>(nullable: false),
                    LoanPeriod = table.Column<int>(nullable: true),
                    IsRentByOwner = table.Column<bool>(nullable: false),
                    RentAmount = table.Column<decimal>(type: "decimal(3,2)", nullable: false)
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
                table: "LU_BankName",
                columns: new[] { "BankNameId", "BankDescription", "IsActive" },
                values: new object[,]
                {
                    { 1, "UniCredit Bank", true },
                    { 2, "Intesa San Paolo", true },
                    { 3, "UBI Bank", true }
                });

            migrationBuilder.InsertData(
                table: "LU_CountryName",
                columns: new[] { "CountryNameId", "CountryDescription", "IsActive" },
                values: new object[,]
                {
                    { 1, "Italy", true },
                    { 2, "Bangladesh", true },
                    { 3, "Germany", true }
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
                table: "LU_InsuranceType",
                columns: new[] { "InsuranceTypeId", "Description", "IsActive" },
                values: new object[,]
                {
                    { 1, "Car Insurance", true },
                    { 2, "Home Insurance", true },
                    { 3, "Health Insurance", true }
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
                table: "LU_OccupationPositionType",
                columns: new[] { "OccupationPositionId", "Description", "IsActive" },
                values: new object[,]
                {
                    { 1, "Manager", true },
                    { 2, "Worker", true },
                    { 3, "Employee", true }
                });

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
                name: "IX_ProfDelegationInfos_ProfileId",
                table: "ProfDelegationInfos",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfDelegationInfos_RecordStatusId",
                table: "ProfDelegationInfos",
                column: "RecordStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfDocumentInfos_DocumentTypeId",
                table: "ProfDocumentInfos",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfDocumentInfos_ProfileId",
                table: "ProfDocumentInfos",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfDocumentInfos_RecordStatusId",
                table: "ProfDocumentInfos",
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
                name: "ProfDocumentInfos");

            migrationBuilder.DropTable(
                name: "ProfEducationInfos");

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
                name: "LU_AddressType");

            migrationBuilder.DropTable(
                name: "LU_BankName");

            migrationBuilder.DropTable(
                name: "LU_DegreeType");

            migrationBuilder.DropTable(
                name: "LU_LoanStatusType");

            migrationBuilder.DropTable(
                name: "LU_InsuranceType");

            migrationBuilder.DropTable(
                name: "LU_CountryName");
        }
    }
}