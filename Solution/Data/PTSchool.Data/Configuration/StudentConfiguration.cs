using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PTSchool.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Data.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> student)
        {
            student
                .HasOne(st => st.Class)
                .WithMany(c => c.Students)
                .HasForeignKey(st => st.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            student
                .HasMany(st => st.Marks)
                .WithOne(m => m.Student)
                .HasForeignKey(m => m.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            student
                .HasMany(st => st.Notes)
                .WithOne(n => n.Student)
                .HasForeignKey(n => n.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}