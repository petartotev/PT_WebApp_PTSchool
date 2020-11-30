using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PTSchool.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Data.Configuration
{
    class ClubTeacherConfiguration : IEntityTypeConfiguration<ClubTeacher>
    {
        public void Configure(EntityTypeBuilder<ClubTeacher> clubTeacher)
        {
            clubTeacher
                .HasKey(ct => new { ct.ClubId, ct.TeacherId });

            clubTeacher
                .HasOne(ct => ct.Club)
                .WithMany(cl => cl.Teachers)
                .HasForeignKey(ct => ct.ClubId)
                .OnDelete(DeleteBehavior.Restrict);

            clubTeacher
                .HasOne(ct => ct.Teacher)
                .WithMany(t => t.Clubs)
                .HasForeignKey(ct => ct.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
