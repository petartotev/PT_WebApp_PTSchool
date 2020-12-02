using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PTSchool.Data.Models;

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
                .HasOne(cl => cl.MasterTeacher)
                .WithOne(clMT => clMT.ClassMastered)
                .HasForeignKey<Class>(cl => cl.MasterTeacherId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
