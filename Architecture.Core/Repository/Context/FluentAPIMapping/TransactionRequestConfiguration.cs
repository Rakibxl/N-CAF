using Architecture.Core.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
   public class TransactionRequestConfiguration: IEntityTypeConfiguration<TransactionRequest>
    {
        public void Configure(EntityTypeBuilder<TransactionRequest> obj)
        {
            obj.HasKey(bs => bs.TransactionRequestId);
            obj.Property(bs => bs.Purpose).HasMaxLength(500).IsRequired();
            obj.Property(bs => bs.Amount).HasColumnType("decimal(10,2)").HasDefaultValue(0.0);
            obj.Property(bs => bs.PaymentReceivedBy).HasMaxLength(300).IsRequired(false);
        }
    }
}
