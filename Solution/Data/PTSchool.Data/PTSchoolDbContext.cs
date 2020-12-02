using Microsoft.EntityFrameworkCore;
using PTSchool.Data.Models;

namespace PTSchool.Data
{
    public class PTSchoolDbContext : DbContext
    {
        public DbSet<Class> Classes { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<ClubStudent> ClubsStudents { get; set; }

        public DbSet<ClubTeacher> ClubsTeachers { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Parent> Parents { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentParent> StudentsParents { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<SubjectClass> SubjectsClasses { get; set; }

        public DbSet<SubjectTeacher> SubjectsTeachers { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<TeacherClass> TeachersClasses { get; set; }

        public DbSet<Tictactoe> Tictactoe { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(PTSchoolDataSettings.DefaultConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
