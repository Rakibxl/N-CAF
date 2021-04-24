using Architecture.Core.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
   public class TransactionConfiguration: IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> obj)
        {
            obj.HasKey(bs => bs.TransactionId);
            obj.Property(bs => bs.TransactionPurpose).HasMaxLength(500);
            obj.Property(bs => bs.Amount).HasColumnType("decimal(10,2)").HasDefaultValue(0.0);
        }

    }
}
