using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PTSchool.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Data.Configuration
{
    class ClubStudentConfiguration : IEntityTypeConfiguration<ClubStudent>
    {
        public void Configure(EntityTypeBuilder<ClubStudent> clubsStudents)
        {
            clubsStudents
                .HasKey(cs => new { cs.ClubId, cs.StudentId });

            clubsStudents
                .HasOne(cS => cS.Club)
                .WithMany(cl => cl.Students)
                .HasForeignKey(cl => cl.ClubId)
                .OnDelete(DeleteBehavior.Restrict);

            clubsStudents
                .HasOne(cS => cS.Student)
                .WithMany(st => st.Clubs)
                .HasForeignKey(cl => cl.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
