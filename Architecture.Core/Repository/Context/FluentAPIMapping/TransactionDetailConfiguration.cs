using Architecture.Core.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
    public class TransactionDetailConfiguration: IEntityTypeConfiguration<TransactionDetail>
    {
        public void Configure(EntityTypeBuilder<TransactionDetail> obj)
        {
            obj.HasKey(bs => bs.TransactionDetailId);
            obj.Property(bs => bs.Debit).HasColumnType("decimal(10,2)").HasDefaultValue(0.0);
            obj.Property(bs => bs.Credit).HasColumnType("decimal(10,2)").HasDefaultValue(0.0);
        }
    }
}
