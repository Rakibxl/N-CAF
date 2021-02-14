using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
   public class OperatorBranchInfoConfiguration : IEntityTypeConfiguration<OperatorBranchInfo>
    {
        public void Configure(EntityTypeBuilder<OperatorBranchInfo> operatorBranchInfo)
        {
            operatorBranchInfo.HasNoKey();
            operatorBranchInfo.Property(bs => bs.ApplicationUserId).IsRequired();
            operatorBranchInfo.Property(bs => bs.BranchInfoId).IsRequired();
        }
    }
}
