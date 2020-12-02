using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PTSchool.Data.Models;

namespace PTSchool.Data.Configuration
{
    public class StudentParentConfiguration : IEntityTypeConfiguration<StudentParent>
    {
        public void Configure(EntityTypeBuilder<StudentParent> studentParent)
        {
            studentParent
                .HasKey(sp => new { sp.StudentId, sp.ParentId });

            studentParent
                .HasOne(sp => sp.Student)
                .WithMany(s => s.Parents)
                .HasForeignKey(sp => sp.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            studentParent
                .HasOne(sp => sp.Parent)
                .WithMany(s => s.Students)
                .HasForeignKey(sp => sp.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
