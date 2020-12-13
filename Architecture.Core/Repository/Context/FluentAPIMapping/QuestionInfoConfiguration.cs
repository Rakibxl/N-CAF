using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
    public class QuestionInfoConfiguration : IEntityTypeConfiguration<QuestionInfo>
    {
        public void Configure(EntityTypeBuilder<QuestionInfo> questionInfo)
        {
            questionInfo.HasKey(bs => bs.QuestionInfoId);
            questionInfo.Property(bs => bs.QuestionDescription).HasMaxLength(500).IsRequired();
            questionInfo.Property(bs => bs.PageToUrl).HasMaxLength(100).IsRequired(false);
            questionInfo.Property(bs => bs.Status).HasMaxLength(100);
            questionInfo.Property(bs => bs.Modified).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
            questionInfo.Property(bs => bs.Created).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
        }
    }
}
