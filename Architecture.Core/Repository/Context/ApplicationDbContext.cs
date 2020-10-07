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


        #region Lookup Table
        public DbSet<Gender> Gender { get; set; }
        public DbSet<MeriatalStatus> MeriatalStatus { get; set; }
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

            #region Lookup mapping
            modelBuilder.Entity<Gender>().ToTable("LU_Gender");
            modelBuilder.Entity<Gender>(gender => {
                gender.HasKey(g => g.GenderId);
                gender.Property(g => g.Name).HasMaxLength(100);
                gender.HasData(
                    new Gender { GenderId = 1, Name = "Male", IsActive = true }
                );
            });

            modelBuilder.Entity<MeriatalStatus>().ToTable("LU_MeriatalStatus");
            modelBuilder.Entity<MeriatalStatus>(ms => {
                ms.HasKey(g => g.MeritalStatusId);
                ms.Property(g => g.Name).HasMaxLength(100);
                ms.HasData(
                    new MeriatalStatus { MeritalStatusId = 1, Name = "Single", IsActive = true },
                    new MeriatalStatus { MeritalStatusId = 2, Name = "Marrid", IsActive = true },
                    new MeriatalStatus { MeritalStatusId = 3, Name = "Divorce", IsActive = true }
                );
            });

            modelBuilder.Entity<DocumentType>().ToTable("LU_DocumentType");
            modelBuilder.Entity<DocumentType>(ms => {
                ms.HasKey(g => g.DocumentTypeId);
                ms.Property(g => g.DocumentName).HasMaxLength(100);
                ms.HasData(
                    new DocumentType { DocumentTypeId = 1, DocumentName = "Passport", IsActive = true },
                    new DocumentType { DocumentTypeId = 2, DocumentName = "Driving License", IsActive = true },
                    new DocumentType { DocumentTypeId = 3, DocumentName = "National Id", IsActive = true }
                );
            });

            modelBuilder.Entity<OccupationPosition>().ToTable("LU_OccupationPosition");
            modelBuilder.Entity<OccupationPosition>(ms => {
                ms.HasKey(g => g.OccupationPositionId);
                ms.Property(g => g.OccupationPositionName).HasMaxLength(100);
                ms.HasData(
                    new OccupationPosition { OccupationPositionId = 1, OccupationPositionName = "UnEmployed", IsActive = true },
                    new OccupationPosition { OccupationPositionId = 2, OccupationPositionName = "Employed", IsActive = true },
                    new OccupationPosition { OccupationPositionId = 3, OccupationPositionName = "Shareholder", IsActive = true }
                );
            });

            modelBuilder.Entity<JobType>().ToTable("LU_JobType");
            modelBuilder.Entity<JobType>(ms => {
                ms.HasKey(g => g.JobTypeId);
                ms.Property(g => g.JobTypeName).HasMaxLength(100);
                ms.HasData(
                    new JobType { JobTypeId = 1, JobTypeName = "Part-Time", IsActive = true },
                    new JobType { JobTypeId = 2, JobTypeName = "Full-Time", IsActive = true },
                    new JobType { JobTypeId = 3, JobTypeName = "Occational", IsActive = true }
                );
            });

            modelBuilder.Entity<ContractType>().ToTable("LU_ContractType");
            modelBuilder.Entity<ContractType>(ms => {
                ms.HasKey(g => g.ContractTypeId);
                ms.Property(g => g.ContractTypeName).HasMaxLength(100);
                ms.HasData(
                    new ContractType { ContractTypeId = 1, ContractTypeName = "No Limit", IsActive = true },
                    new ContractType { ContractTypeId = 2, ContractTypeName = "Limited", IsActive = true },
                    new ContractType { ContractTypeId = 3, ContractTypeName = "Occational", IsActive = true }
                );
            });

            modelBuilder.Entity<HouseType>().ToTable("LU_HouseType");
            modelBuilder.Entity<HouseType>(ms => {
                ms.HasKey(g => g.HouseTypeId);
                ms.Property(g => g.HouseTypeName).HasMaxLength(100);
                ms.HasData(
                    new HouseType { HouseTypeId = 1, HouseTypeName = "Rent", IsActive = true },
                    new HouseType { HouseTypeId = 2, HouseTypeName = "Owner", IsActive = true },
                    new HouseType { HouseTypeId = 3, HouseTypeName = "Shared Rent", IsActive = true }
                );
            });

            modelBuilder.Entity<LoanInterestType>().ToTable("LU_LoanInterestType");
            modelBuilder.Entity<LoanInterestType>(ms => {
                ms.HasKey(g => g.LoanInterestTypeId);
                ms.Property(g => g.LoanInterestTypeName).HasMaxLength(100);
                ms.HasData(
                    new LoanInterestType { LoanInterestTypeId = 1, LoanInterestTypeName = "Fixed Interest", IsActive = true },
                    new LoanInterestType { LoanInterestTypeId = 2, LoanInterestTypeName = "Variable Interest", IsActive = true },
                    new LoanInterestType { LoanInterestTypeId = 3, LoanInterestTypeName = "No Interest", IsActive = true }
                );
            });

            modelBuilder.Entity<ResidenceScope>().ToTable("LU_ResidenceScope");
            modelBuilder.Entity<ResidenceScope>(ms => {
                ms.HasKey(g => g.ResidenceScopeId);
                ms.Property(g => g.ResidenceScopeName).HasMaxLength(100);
                ms.HasData(
                    new ResidenceScope { ResidenceScopeId = 1, ResidenceScopeName = "Itally", IsActive = true },
                    new ResidenceScope { ResidenceScopeId = 2, ResidenceScopeName = "Out of Itally", IsActive = true },
                    new ResidenceScope { ResidenceScopeId = 3, ResidenceScopeName = "Not Permanent", IsActive = true }
                );
            });

            modelBuilder.Entity<RelationType>().ToTable("LU_RelationType");
            modelBuilder.Entity<RelationType>(ms => {
                ms.HasKey(g => g.RelationTypeId);
                ms.Property(g => g.RelationTypeName).HasMaxLength(100);
                ms.HasData(
                    new RelationType { RelationTypeId = 1, RelationTypeName = "Father", IsActive = true },
                    new RelationType { RelationTypeId = 2, RelationTypeName = "Mother", IsActive = true },
                    new RelationType { RelationTypeId = 3, RelationTypeName = "Son", IsActive = true }
                );
            });

            modelBuilder.Entity<NationalIdType>().ToTable("LU_NationalIdType");
            modelBuilder.Entity<NationalIdType>(ms => {
                ms.HasKey(g => g.NationalIdTypeId);
                ms.Property(g => g.NationalIdTypeName).HasMaxLength(100);
                ms.HasData(
                    new NationalIdType { NationalIdTypeId = 1, NationalIdTypeName = "Smart", IsActive = true },
                    new NationalIdType { NationalIdTypeId = 2, NationalIdTypeName = "Paper", IsActive = true },
                    new NationalIdType { NationalIdTypeId = 3, NationalIdTypeName = "Pending", IsActive = true }
                );
            });

            modelBuilder.Entity<IncomeType>().ToTable("LU_IncomeType");
            modelBuilder.Entity<IncomeType>(ms => {
                ms.HasKey(g => g.IncomeTypeId);
                ms.Property(g => g.IncomeTypeName).HasMaxLength(100);
                ms.HasData(
                    new IncomeType { IncomeTypeId = 1, IncomeTypeName = "Single Income", IsActive = true },
                    new IncomeType { IncomeTypeId = 2, IncomeTypeName = "Double Income", IsActive = true },
                    new IncomeType { IncomeTypeId = 3, IncomeTypeName = "Business Income", IsActive = true }
                );
            });

            modelBuilder.Entity<HouseCategory>().ToTable("LU_HouseCategory");
            modelBuilder.Entity<HouseCategory>(ms => {
                ms.HasKey(g => g.HouseCategoryId);
                ms.Property(g => g.HouseCategoryName).HasMaxLength(100);
                ms.HasData(
                    new HouseCategory { HouseCategoryId = 1, HouseCategoryName = "House Category 1", IsActive = true },
                    new HouseCategory { HouseCategoryId = 2, HouseCategoryName = "House Category 2", IsActive = true },
                    new HouseCategory { HouseCategoryId = 3, HouseCategoryName = "House Category 3", IsActive = true }
                );
            });

            modelBuilder.Entity<Nationality>().ToTable("LU_Nationality");
            modelBuilder.Entity<Nationality>(ms => {
                ms.HasKey(g => g.NationalityId);
                ms.Property(g => g.NationalityName).HasMaxLength(100);
                ms.HasData(
                    new Nationality { NationalityId = 1, NationalityName = "Bangladeshi", IsActive = true },
                    new Nationality { NationalityId = 2, NationalityName = "Italian", IsActive = true },
                    new Nationality { NationalityId = 3, NationalityName = "Indian", IsActive = true }
                );
            });

            modelBuilder.Entity<OccupationType>().ToTable("LU_OccupationType");
            modelBuilder.Entity<OccupationType>(ms => {
                ms.HasKey(g => g.OccupationTypeId);
                ms.Property(g => g.OccupationTypeName).HasMaxLength(100);
                ms.HasData(
                    new OccupationType { OccupationTypeId = 1, OccupationTypeName = "Occupation Type 1", IsActive = true },
                    new OccupationType { OccupationTypeId = 2, OccupationTypeName = "Occupation Type 2", IsActive = true },
                    new OccupationType { OccupationTypeId = 3, OccupationTypeName = "Occupation Type 3", IsActive = true }
                );
            });

             modelBuilder.Entity<EyeColor>().ToTable("LU_EyeColor");
            modelBuilder.Entity<EyeColor>(ms => {
                ms.HasKey(g => g.EyeColorId);
                ms.Property(g => g.Description).HasMaxLength(100);
                ms.HasData(
                    new EyeColor { EyeColorId = 1, Description = "Red", IsActive = true },
                    new EyeColor { EyeColorId = 2, Description = "Blue", IsActive = true },
                    new EyeColor { EyeColorId = 3, Description = "Normal", IsActive = true }
                );
            });

            #endregion


        }
    }
}