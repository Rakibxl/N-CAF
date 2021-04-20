using Architecture.Core.Entities.Notification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
   public class NotificationInfoConfiguration : IEntityTypeConfiguration<NotificationInfo>
    {
        public void Configure(EntityTypeBuilder<NotificationInfo> mgs)
        {
            mgs.HasKey(dd => dd.NotificationInfoId);
            mgs.Property(bs => bs.Type).HasMaxLength(100);
            //mgs.Property(bs => bs.Modified).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
            //mgs.Property(bs => bs.Created).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
        }
    }
}
