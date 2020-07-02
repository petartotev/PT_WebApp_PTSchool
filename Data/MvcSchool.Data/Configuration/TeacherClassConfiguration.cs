using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcSchool.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvcSchool.Data.Configuration
{
    class TeacherClassConfiguration : IEntityTypeConfiguration<TeacherClass>
    {
        public void Configure(EntityTypeBuilder<TeacherClass> teacherClass)
        {
            teacherClass
                .HasKey(tc => new { tc.ClassId, tc.TeacherId });

            teacherClass
                .HasOne(t => t.Class)
                .WithMany(cl => cl.Teachers)
                .HasForeignKey(t => t.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            teacherClass
                .HasOne(cl => cl.Teacher)
                .WithMany(t => t.Classes)
                .HasForeignKey(cl => cl.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
