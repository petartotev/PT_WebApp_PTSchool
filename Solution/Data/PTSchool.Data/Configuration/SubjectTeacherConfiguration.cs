using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PTSchool.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Data.Configuration
{
    public class SubjectTeacherConfiguration : IEntityTypeConfiguration<SubjectTeacher>
    {
        public void Configure(EntityTypeBuilder<SubjectTeacher> subjectTeacher)
        {
            subjectTeacher
                .HasKey(subT => new { subT.SubjectId, subT.TeacherId });

            subjectTeacher
                .HasOne(subT => subT.Teacher)
                .WithMany(t => t.Subjects)
                .HasForeignKey(subT => subT.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            subjectTeacher
                .HasOne(subT => subT.Subject)
                .WithMany(sub => sub.Teachers)
                .HasForeignKey(subT => subT.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
