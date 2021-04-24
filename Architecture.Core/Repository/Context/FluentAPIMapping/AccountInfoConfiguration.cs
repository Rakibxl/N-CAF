using Architecture.Core.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
   public class AccountInfoConfiguration: IEntityTypeConfiguration<AccountInfo>
    {
        public void Configure(EntityTypeBuilder<AccountInfo> obj)
        {
            obj.HasKey(bs => bs.AccountInfoId);
            obj.Property(bs => bs.AccountNumber).HasMaxLength(100).IsRequired();
            obj.Property(bs => bs.MasterId).HasMaxLength(100).IsRequired();
            obj.Property(bs => bs.AccountName).HasMaxLength(100);
            //obj.Property(bs => bs.Debit).HasColumnType("decimal(10,2)").HasDefaultValue(0.0);
            //obj.Property(bs => bs.Credit).HasColumnType("decimal(10,2)").HasDefaultValue(0.0);
        }

    }
}
