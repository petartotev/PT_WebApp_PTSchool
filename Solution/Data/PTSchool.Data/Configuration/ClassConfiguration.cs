using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PTSchool.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Data.Configuration
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> classs)
        {
            classs
                .HasMany(cl => cl.Students)
                .WithOne(st => st.Class)
                .HasForeignKey(st => st.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            classs
                .HasOne(cl => cl.ClassMasterTeacher)
                .WithOne(clMT => clMT.ClassMastered)
                .HasForeignKey<Class>(cl => cl.ClassMasterTeacherId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
