using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
   public class ProfDocumentInfoConfiguration : IEntityTypeConfiguration<ProfDocumentInfo>
    {       
        public void Configure(EntityTypeBuilder<ProfDocumentInfo> documentInfo)
        {
            // Prof Family Info
            documentInfo.HasKey(bs => bs.DocumentId);
                //documentInfo.HasOne(v => v.ProfBasicInfo).WithMany(m => m.ProfFamilyInfos).HasForeignKey(f => f.ProfileId).OnDelete(DeleteBehavior.Cascade);

                documentInfo.Property(bs => bs.DocumentName).HasMaxLength(100).IsRequired();
                documentInfo.Property(bs => bs.IssuedBy).HasMaxLength(100);
                documentInfo.Property(bs => bs.PurposeOfDocument).HasMaxLength(500);
                documentInfo.Property(bs => bs.Modified).ValueGeneratedOnUpdate().HasComputedColumnSql("GetUtcDate()");
                documentInfo.Property(bs => bs.Created).ValueGeneratedOnAdd().HasComputedColumnSql("GetUtcDate()");
        }
    }
}
