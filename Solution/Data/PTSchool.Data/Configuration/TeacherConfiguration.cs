using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PTSchool.Data.Models;

namespace PTSchool.Data.Configuration
{
    class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> teacher)
        {
            teacher
                .HasMany(t => t.Marks)
                .WithOne(m => m.Teacher)
                .HasForeignKey(m => m.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            teacher
                .HasMany(t => t.Notes)
                .WithOne(n => n.Teacher)
                .HasForeignKey(n => n.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
