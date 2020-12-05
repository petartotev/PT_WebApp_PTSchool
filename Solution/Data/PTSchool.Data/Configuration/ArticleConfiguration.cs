using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PTSchool.Data.Models.ApiNews;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Data.Configuration
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> article)
        {
            article
                .HasOne(art => art.Source)
                .WithMany(src => src.Articles)
                .HasForeignKey(art => art.SourceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
