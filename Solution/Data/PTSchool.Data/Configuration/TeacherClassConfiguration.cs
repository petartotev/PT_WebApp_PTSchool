using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PTSchool.Data.Models;

namespace PTSchool.Data.Configuration
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
