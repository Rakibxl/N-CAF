using Architecture.Core.Common.Enums;
using Architecture.Core.Entities;
using Architecture.Core.Entities.LU;
using Architecture.Core.Repository.Context.FluentAPIMapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Core.Repository.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid,
    IdentityUserClaim<Guid>, ApplicationUserRole, IdentityUserLogin<Guid>,
    IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        // Add DbSet here
        public DbSet<Example> Examples { get; set; }
        public DbSet<ProfBasicInfo> ProfBasicInfos { get; set; }
        public DbSet<ProfFamilyInfo> ProfFamilyInfo { get; set; }
        public DbSet<ProfDocumentInfo> ProfDocumentInfo { get; set; }
        public DbSet<ProfAddressInfo> ProfAddressInfos { get; set; }
        public DbSet<ProfAssetInfo> ProfAssetInfos { get; set; }
        public DbSet<ProfBankInfo> ProfBankInfos { get; set; }
        public DbSet<ProfLegalInfo> ProfLegalInfos { get; set; }
        public DbSet<ProfInsuranceInfo> ProfInsuranceInfos { get; set; }
        public DbSet<ProfWorkerInfo> ProfWorkerInfos { get; set; }
        public DbSet<ProfDelegationInfo> ProfDelegationInfos { get; set; }
        public DbSet<ProfISEEInfo> ProfISEEInfos { get; set; }
        public DbSet<ProfMovementInfo> ProfMovementInfos { get; set; }
        public DbSet<ProfDocumentInfo> ProfDocumentInfos { get; set; }
        public DbSet<ProfEducationInfo> ProfEducationInfos { get; set; }
        public DbSet<ProfHouseRentInfo> ProfHouseRentInfos { get; set; }
        public DbSet<BranchInfo> BranchInfos { get; set; }
        public DbSet<QuestionInfo> QuestionInfos { get; set; }
        public DbSet<JobInfo> JobInfos { get; set; }
        public DbSet<SectionLink> SectionLinks { get; set; }
        public DbSet<JobSectionLink> JobSectionLinks { get; set; }

        #region Lookup Table
        public DbSet<Gender> Gender { get; set; }
        public DbSet<MaritalStatus> MeriatalStatus { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<OccupationPosition> OccupationPosition { get; set; }
        public DbSet<JobType> JobType { get; set; }
        public DbSet<ContractType> ContractType { get; set; }
        public DbSet<HouseType> HouseType { get; set; }
        public DbSet<LoanInterestType> LoanInterestType { get; set; }
        public DbSet<ResidenceScope> ResidenceScope { get; set; }
        public DbSet<RelationType> RelationType { get; set; }
        public DbSet<NationalIdType> NationalIdType { get; set; }
        public DbSet<IncomeType> IncomeType { get; set; }
        public DbSet<HouseCategory> HouseCategory { get; set; }
        public DbSet<OccupationType> OccupationType { get; set; }
        public DbSet<EyeColor> EyeColor { get; set; }
        public DbSet<AppUserType> AppUserType { get; set; }
        public DbSet<AppUserStatus> AppUserStatus { get; set; }
        public DbSet<WorkerType> WorkerType { get; set; }
        public DbSet<AssetType> AssetType { get; set; }
        public DbSet<OwnerType> OwnerType { get; set; }
        public DbSet<ISEEClassType> ISEEClassType { get; set; }
        public DbSet<JobDeliveryType> JobDeliveryType { get; set; }
        public DbSet<MotiveType> MotiveType { get; set; }
        public DbSet<AddressType> AddressType { get; set; }
        public DbSet<OccupationPositionType> OccupationPositionType { get; set; }
        public DbSet<DegreeType> DegreeType { get; set; }
        public DbSet<LoanStatusType> LoanStatusType { get; set; }
        public DbSet<BankName> BankName { get; set; }
        public DbSet<CountryName> CountryName { get; set; }
        public DbSet<InsuranceType> InsuranceType { get; set; }
        public DbSet<SectionName> SectionName { get; set; }

        #endregion 

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            // Prof Basic Info
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            modelBuilder.Entity<Gender>().ToTable("LU_Gender");
            modelBuilder.Entity<Gender>(gender =>
            {
                gender.HasKey(g => g.GenderId);
                gender.Property(g => g.Name).HasMaxLength(100);
                gender.HasData(
                    new Gender { GenderId = 1, Name = "Male", IsActive = true },
                    new Gender { GenderId = 2, Name = "Female", IsActive = true },
                    new Gender { GenderId = 3, Name = "Other", IsActive = true }
                );
            });

            modelBuilder.Entity<MaritalStatus>().ToTable("LU_MeriatalStatus");
            modelBuilder.Entity<MaritalStatus>(ms =>
            {
                ms.HasKey(g => g.MeritalStatusId);
                ms.Property(g => g.Name).HasMaxLength(100);
                ms.HasData(
                    new MaritalStatus { MeritalStatusId = 1, Name = "Single", IsActive = true },
                    new MaritalStatus { MeritalStatusId = 2, Name = "Marrid", IsActive = true },
                    new MaritalStatus { MeritalStatusId = 3, Name = "Divorce", IsActive = true }
                );
            });

            modelBuilder.Entity<DocumentType>().ToTable("LU_DocumentType");
            modelBuilder.Entity<DocumentType>(ms =>
            {
                ms.HasKey(g => g.DocumentTypeId);
                ms.Property(g => g.DocumentName).HasMaxLength(100);
                ms.HasData(
                    new DocumentType { DocumentTypeId = 1, DocumentName = "Passport", IsActive = true },
                    new DocumentType { DocumentTypeId = 2, DocumentName = "Driving License", IsActive = true },
                    new DocumentType { DocumentTypeId = 3, DocumentName = "National Id", IsActive = true }
                );
            });

            modelBuilder.Entity<OccupationPosition>().ToTable("LU_OccupationPosition");
            modelBuilder.Entity<OccupationPosition>(ms =>
            {
                ms.HasKey(g => g.OccupationPositionId);
                ms.Property(g => g.OccupationPositionName).HasMaxLength(100);
                ms.HasData(
                    new OccupationPosition { OccupationPositionId = 1, OccupationPositionName = "UnEmployed", IsActive = true },
                    new OccupationPosition { OccupationPositionId = 2, OccupationPositionName = "Employed", IsActive = true },
                    new OccupationPosition { OccupationPositionId = 3, OccupationPositionName = "Shareholder", IsActive = true }
                );
            });

            modelBuilder.Entity<JobType>().ToTable("LU_JobType");
            modelBuilder.Entity<JobType>(ms =>
            {
                ms.HasKey(g => g.JobTypeId);
                ms.Property(g => g.JobTypeName).HasMaxLength(100);
                ms.HasData(
                    new JobType { JobTypeId = 1, JobTypeName = "Part-Time", IsActive = true },
                    new JobType { JobTypeId = 2, JobTypeName = "Full-Time", IsActive = true },
                    new JobType { JobTypeId = 3, JobTypeName = "Occational", IsActive = true }
                );
            });

            modelBuilder.Entity<ContractType>().ToTable("LU_ContractType");
            modelBuilder.Entity<ContractType>(ms =>
            {
                ms.HasKey(g => g.ContractTypeId);
                ms.Property(g => g.ContractTypeName).HasMaxLength(100);
                ms.HasData(
                    new ContractType { ContractTypeId = 1, ContractTypeName = "No Limit", IsActive = true },
                    new ContractType { ContractTypeId = 2, ContractTypeName = "Limited", IsActive = true },
                    new ContractType { ContractTypeId = 3, ContractTypeName = "Occational", IsActive = true }
                );
            });

            modelBuilder.Entity<HouseType>().ToTable("LU_HouseType");
            modelBuilder.Entity<HouseType>(ms =>
            {
                ms.HasKey(g => g.HouseTypeId);
                ms.Property(g => g.HouseTypeName).HasMaxLength(100);
                ms.HasData(
                    new HouseType { HouseTypeId = 1, HouseTypeName = "Rent", IsActive = true },
                    new HouseType { HouseTypeId = 2, HouseTypeName = "Owner", IsActive = true },
                    new HouseType { HouseTypeId = 3, HouseTypeName = "Shared Rent", IsActive = true }
                );
            });

            modelBuilder.Entity<LoanInterestType>().ToTable("LU_LoanInterestType");
            modelBuilder.Entity<LoanInterestType>(ms =>
            {
                ms.HasKey(g => g.LoanInterestTypeId);
                ms.Property(g => g.LoanInterestTypeName).HasMaxLength(100);
                ms.HasData(
                    new LoanInterestType { LoanInterestTypeId = 1, LoanInterestTypeName = "Fixed Interest", IsActive = true },
                    new LoanInterestType { LoanInterestTypeId = 2, LoanInterestTypeName = "Variable Interest", IsActive = true },
                    new LoanInterestType { LoanInterestTypeId = 3, LoanInterestTypeName = "No Interest", IsActive = true }
                );
            });

            modelBuilder.Entity<ResidenceScope>().ToTable("LU_ResidenceScope");
            modelBuilder.Entity<ResidenceScope>(ms =>
            {
                ms.HasKey(g => g.ResidenceScopeId);
                ms.Property(g => g.ResidenceScopeName).HasMaxLength(100);
                ms.HasData(
                    new ResidenceScope { ResidenceScopeId = 1, ResidenceScopeName = "Itally", IsActive = true },
                    new ResidenceScope { ResidenceScopeId = 2, ResidenceScopeName = "Out of Itally", IsActive = true },
                    new ResidenceScope { ResidenceScopeId = 3, ResidenceScopeName = "Not Permanent", IsActive = true }
                );
            });

            modelBuilder.Entity<RelationType>().ToTable("LU_RelationType");
            modelBuilder.Entity<RelationType>(ms =>
            {
                ms.HasKey(g => g.RelationTypeId);
                ms.Property(g => g.RelationTypeName).HasMaxLength(100);
                ms.HasData(
                    new RelationType { RelationTypeId = 1, RelationTypeName = "Father", IsActive = true },
                    new RelationType { RelationTypeId = 2, RelationTypeName = "Mother", IsActive = true },
                    new RelationType { RelationTypeId = 3, RelationTypeName = "Son", IsActive = true }
                );
            });

            modelBuilder.Entity<NationalIdType>().ToTable("LU_NationalIdType");
            modelBuilder.Entity<NationalIdType>(ms =>
            {
                ms.HasKey(g => g.NationalIdTypeId);
                ms.Property(g => g.NationalIdTypeName).HasMaxLength(100);
                ms.HasData(
                    new NationalIdType { NationalIdTypeId = 1, NationalIdTypeName = "Smart", IsActive = true },
                    new NationalIdType { NationalIdTypeId = 2, NationalIdTypeName = "Paper", IsActive = true },
                    new NationalIdType { NationalIdTypeId = 3, NationalIdTypeName = "Pending", IsActive = true }
                );
            });

            modelBuilder.Entity<IncomeType>().ToTable("LU_IncomeType");
            modelBuilder.Entity<IncomeType>(ms =>
            {
                ms.HasKey(g => g.IncomeTypeId);
                ms.Property(g => g.IncomeTypeName).HasMaxLength(100);
                ms.HasData(
                    new IncomeType { IncomeTypeId = 1, IncomeTypeName = "Single Income", IsActive = true },
                    new IncomeType { IncomeTypeId = 2, IncomeTypeName = "Double Income", IsActive = true },
                    new IncomeType { IncomeTypeId = 3, IncomeTypeName = "Business Income", IsActive = true }
                );
            });

            modelBuilder.Entity<HouseCategory>().ToTable("LU_HouseCategory");
            modelBuilder.Entity<HouseCategory>(ms =>
            {
                ms.HasKey(g => g.HouseCategoryId);
                ms.Property(g => g.HouseCategoryName).HasMaxLength(100);
                ms.HasData(
                    new HouseCategory { HouseCategoryId = 1, HouseCategoryName = "House Category 1", IsActive = true },
                    new HouseCategory { HouseCategoryId = 2, HouseCategoryName = "House Category 2", IsActive = true },
                    new HouseCategory { HouseCategoryId = 3, HouseCategoryName = "House Category 3", IsActive = true }
                );
            });

            modelBuilder.Entity<Nationality>().ToTable("LU_Nationality");
            modelBuilder.Entity<Nationality>(ms =>
            {
                ms.HasKey(g => g.NationalityId);
                ms.Property(g => g.NationalityName).HasMaxLength(100);
                ms.HasData(
                    new Nationality { NationalityId = 1, NationalityName = "Bangladeshi", IsActive = true },
                    new Nationality { NationalityId = 2, NationalityName = "Italian", IsActive = true },
                    new Nationality { NationalityId = 3, NationalityName = "Indian", IsActive = true }
                );
            });

            modelBuilder.Entity<OccupationType>().ToTable("LU_OccupationType");
            modelBuilder.Entity<OccupationType>(ms =>
            {
                ms.HasKey(g => g.OccupationTypeId);
                ms.Property(g => g.OccupationTypeName).HasMaxLength(100);
                ms.HasData(
                    new OccupationType { OccupationTypeId = 1, OccupationTypeName = "Occupation Type 1", IsActive = true },
                    new OccupationType { OccupationTypeId = 2, OccupationTypeName = "Occupation Type 2", IsActive = true },
                    new OccupationType { OccupationTypeId = 3, OccupationTypeName = "Occupation Type 3", IsActive = true }
                );
            });

            modelBuilder.Entity<EyeColor>().ToTable("LU_EyeColor");
            modelBuilder.Entity<EyeColor>(ms =>
            {
                ms.HasKey(g => g.EyeColorId);
                ms.Property(g => g.Description).HasMaxLength(100);
                ms.HasData(
                    new EyeColor { EyeColorId = 1, Description = "Red", IsActive = true },
                    new EyeColor { EyeColorId = 2, Description = "Blue", IsActive = true },
                    new EyeColor { EyeColorId = 3, Description = "Normal", IsActive = true }
                );
            });
            modelBuilder.Entity<AppUserStatus>().ToTable("LU_AppUserStatus");
            modelBuilder.Entity<AppUserStatus>(ms =>
            {
                ms.HasKey(g => g.AppUserStatusId);
                ms.Property(g => g.AppUserStatusTitle).HasMaxLength(100);
                ms.HasData(
                    new AppUserStatus { AppUserStatusId = 1, AppUserStatusTitle = "Approved", IsActive = true },
                    new AppUserStatus { AppUserStatusId = 2, AppUserStatusTitle = "Rejected", IsActive = true },
                    new AppUserStatus { AppUserStatusId = 3, AppUserStatusTitle = "Request For Approval", IsActive = true }
                );
            });
            modelBuilder.Entity<AppUserType>().ToTable("LU_AppAppUserType");
            modelBuilder.Entity<AppUserType>(ms =>
            {
                ms.HasKey(g => g.AppUserTypeId);
                ms.Property(g => g.AppUserTypeTitle).HasMaxLength(100);
                ms.HasData(
                    new AppUserType { AppUserTypeId = 1, AppUserTypeTitle = "Client", IsActive = true },
                    new AppUserType { AppUserTypeId = 2, AppUserTypeTitle = "Branch User", IsActive = true },
                    new AppUserType { AppUserTypeId = 3, AppUserTypeTitle = "Operator", IsActive = true },
                    new AppUserType { AppUserTypeId = 4, AppUserTypeTitle = "Admin", IsActive = true }
                );
            });
            modelBuilder.Entity<WorkerType>().ToTable("LU_WorkerType");
            modelBuilder.Entity<WorkerType>(ms =>
            {
                ms.HasKey(g => g.WorkerTypeId);
                ms.Property(g => g.WorkerTypeName).HasMaxLength(100);
                ms.HasData(
                    new WorkerType { WorkerTypeId = 1, WorkerTypeName = "Company Worker", IsActive = true },
                    new WorkerType { WorkerTypeId = 2, WorkerTypeName = "Domestic Worker", IsActive = true }
                );
            });
            modelBuilder.Entity<AssetType>().ToTable("LU_AssetType");
            modelBuilder.Entity<AssetType>(ms =>
            {
                ms.HasKey(g => g.AssetTypeId);
                ms.Property(g => g.AssetTypeName).HasMaxLength(100);
                ms.HasData(
                    new AssetType { AssetTypeId = 1, AssetTypeName = "House", IsActive = true },
                    new AssetType { AssetTypeId = 2, AssetTypeName = "Car", IsActive = true }
                );
            });
            modelBuilder.Entity<OwnerType>().ToTable("LU_OwnerType");
            modelBuilder.Entity<OwnerType>(ms =>
            {
                ms.HasKey(g => g.OwnerTypeId);
                ms.Property(g => g.OwnerTypeName).HasMaxLength(100);
                ms.HasData(
                    new OwnerType { OwnerTypeId = 1, OwnerTypeName = "By Birth", IsActive = true },
                    new OwnerType { OwnerTypeId = 2, OwnerTypeName = "Buy", IsActive = true }
                );
            });
            modelBuilder.Entity<ISEEClassType>().ToTable("LU_ISEEClassType");
            modelBuilder.Entity<ISEEClassType>(ms =>
            {
                ms.HasKey(g => g.ISEEClassTypeId);
                ms.Property(g => g.ISEEClassTypeName).HasMaxLength(100);
                ms.HasData(
                    new ISEEClassType { ISEEClassTypeId = 1, ISEEClassTypeName = "High", IsActive = true },
                    new ISEEClassType { ISEEClassTypeId = 2, ISEEClassTypeName = "Middle", IsActive = true },
                    new ISEEClassType { ISEEClassTypeId = 3, ISEEClassTypeName = "Low", IsActive = true }
                );
            });
            modelBuilder.Entity<JobDeliveryType>().ToTable("LU_JobDeliveryType");
            modelBuilder.Entity<JobDeliveryType>(ms =>
            {
                ms.HasKey(g => g.JobDeliveryTypeId);
                ms.Property(g => g.JobDeliveryTypeName).HasMaxLength(100);
                ms.HasData(
                    new JobDeliveryType { JobDeliveryTypeId = 1, JobDeliveryTypeName = "Normal", IsActive = true },
                    new JobDeliveryType { JobDeliveryTypeId = 2, JobDeliveryTypeName = "Standard", IsActive = true },
                    new JobDeliveryType { JobDeliveryTypeId = 3, JobDeliveryTypeName = "Urgent", IsActive = true }
                );
            });
            modelBuilder.Entity<MotiveType>().ToTable("LU_MotiveType");
            modelBuilder.Entity<MotiveType>(ms =>
            {
                ms.HasKey(g => g.MotiveTypeId);
                ms.Property(g => g.MotiveTypeName).HasMaxLength(100);
                ms.HasData(
                    new MotiveType { MotiveTypeId = 1, MotiveTypeName = "Occupation", IsActive = true },
                    new MotiveType { MotiveTypeId = 2, MotiveTypeName = "Family", IsActive = true },
                    new MotiveType { MotiveTypeId = 3, MotiveTypeName = "Worker", IsActive = true }
                );
            });
            modelBuilder.Entity<AddressType>().ToTable("LU_AddressType");
            modelBuilder.Entity<AddressType>(ms =>
            {
                ms.HasKey(g => g.AddressTypeId);
                ms.Property(g => g.AddressTypeName).HasMaxLength(100);
                ms.HasData(
                    new AddressType { AddressTypeId = 1, AddressTypeName = "Permanent", IsActive = true },
                    new AddressType { AddressTypeId = 2, AddressTypeName = "Temporary", IsActive = true },
                    new AddressType { AddressTypeId = 3, AddressTypeName = "Previous Permanent", IsActive = true }
                );
            });
            modelBuilder.Entity<OccupationPositionType>().ToTable("LU_OccupationPositionType");
            modelBuilder.Entity<OccupationPositionType>(ms =>
            {
                ms.HasKey(g => g.OccupationPositionId);
                ms.Property(g => g.Description).HasMaxLength(100);
                ms.HasData(
                    new OccupationPositionType { OccupationPositionId = 1, Description = "Manager", IsActive = true },
                    new OccupationPositionType { OccupationPositionId = 2, Description = "Worker", IsActive = true },
                    new OccupationPositionType { OccupationPositionId = 3, Description = "Employee", IsActive = true }
                );
            });
            modelBuilder.Entity<DegreeType>().ToTable("LU_DegreeType");
            modelBuilder.Entity<DegreeType>(ms =>
            {
                ms.HasKey(g => g.DegreeTypeId);
                ms.Property(g => g.DegreeTypeName).HasMaxLength(100);
                ms.HasData(
                    new DegreeType { DegreeTypeId = 1, DegreeTypeName = "Bachelor", IsActive = true },
                    new DegreeType { DegreeTypeId = 2, DegreeTypeName = "Masters", IsActive = true },
                    new DegreeType { DegreeTypeId = 3, DegreeTypeName = "High School", IsActive = true }
                );
            });
            modelBuilder.Entity<LoanStatusType>().ToTable("LU_LoanStatusType");
            modelBuilder.Entity<LoanStatusType>(ms =>
            {
                ms.HasKey(g => g.LoanStatusTypeId);
                ms.Property(g => g.LoanStatusTypeName).HasMaxLength(100);
                ms.HasData(
                    new LoanStatusType { LoanStatusTypeId = 1, LoanStatusTypeName = "Pending", IsActive = true },
                    new LoanStatusType { LoanStatusTypeId = 2, LoanStatusTypeName = "Active", IsActive = true },
                    new LoanStatusType { LoanStatusTypeId = 3, LoanStatusTypeName = "Past Due", IsActive = true }
                );
            });
            modelBuilder.Entity<BankName>().ToTable("LU_BankName");
            modelBuilder.Entity<BankName>(ms =>
            {
                ms.HasKey(g => g.BankNameId);
                ms.Property(g => g.BankDescription).HasMaxLength(100);
                ms.HasData(
                    new BankName { BankNameId = 1, BankDescription = "UniCredit Bank", IsActive = true },
                    new BankName { BankNameId = 2, BankDescription = "Intesa San Paolo", IsActive = true },
                    new BankName { BankNameId = 3, BankDescription = "UBI Bank", IsActive = true }
                );
            });
            modelBuilder.Entity<CountryName>().ToTable("LU_CountryName");
            modelBuilder.Entity<CountryName>(ms =>
            {
                ms.HasKey(g => g.CountryNameId);
                ms.Property(g => g.CountryDescription).HasMaxLength(100);
                ms.HasData(
                    new CountryName { CountryNameId = 1, CountryDescription = "Italy", IsActive = true },
                    new CountryName { CountryNameId = 2, CountryDescription = "Bangladesh", IsActive = true },
                    new CountryName { CountryNameId = 3, CountryDescription = "Germany", IsActive = true }
                );
            });
            modelBuilder.Entity<InsuranceType>().ToTable("LU_InsuranceType");
            modelBuilder.Entity<InsuranceType>(ms =>
            {
                ms.HasKey(g => g.InsuranceTypeId);
                ms.Property(g => g.Description).HasMaxLength(100);
                ms.HasData(
                    new InsuranceType { InsuranceTypeId = 1, Description = "Car Insurance", IsActive = true },
                    new InsuranceType { InsuranceTypeId = 2, Description = "Home Insurance", IsActive = true },
                    new InsuranceType { InsuranceTypeId = 3, Description = "Health Insurance", IsActive = true }
                );
            });
            modelBuilder.Entity<SectionName>().ToTable("LU_SectionName");
            modelBuilder.Entity<SectionName>(ms =>
            {
                ms.HasKey(g => g.SectionNameId);
                ms.Property(g => g.SectionDescription).HasMaxLength(150);
                ms.HasData(
                    new SectionName { SectionNameId = 1, SectionDescription = "Basic Info", IsActive = true },
                    new SectionName { SectionNameId = 2, SectionDescription = "Occupation Info", IsActive = true },
                    new SectionName { SectionNameId = 3, SectionDescription = "Family Info", IsActive = true },
                    new SectionName { SectionNameId = 4, SectionDescription = "Education Info", IsActive = true },
                    new SectionName { SectionNameId = 5, SectionDescription = "Address Info", IsActive = true },
                    new SectionName { SectionNameId = 6, SectionDescription = "House Rent Info", IsActive = true },
                    new SectionName { SectionNameId = 7, SectionDescription = "Document Info", IsActive = true },
                    new SectionName { SectionNameId = 8, SectionDescription = "Income Info", IsActive = true }
                );
            });




        }
    }
}