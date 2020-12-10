using Microsoft.EntityFrameworkCore;
using PTSchool.Console.Seeder;
using PTSchool.Data;

namespace PTSchool.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            using var db = new PTSchoolDbContext(new DbContextOptionsBuilder<PTSchoolDbContext>()
            .UseSqlServer("Server=PT\\SQLEXPRESS;Database=PTSchoolDatabase;Integrated Security=True;")
            .Options);

            db.Database.Migrate();

            //// ADD 45 TEACHERS.
            //PTSchoolDbSeeder.SeedTeachers(db, 45);

            //// ADD 30 CLASSES FROM 8TH GRADE TO 12TH GRADE + CLASS NAMES FROM 'A' TO 'F'.
            //PTSchoolDbSeeder.SeedClasses(db);

            //// ADD STUDENTS TO THE 30 CLASSES.
            //PTSchoolDbSeeder.SeedStudents(db);

            //// ADD PARENTS.
            //PTSchoolDbSeeder.SeedParents(db);

            //// ADD STUDENT-PARENT.
            //PTSchoolDbSeeder.SeedParentsToStudentsRelation(db);

            //// ADD SUBJECTS.
            //PTSchoolDbSeeder.SeedSubjects(db);

            //// ADD CLUBS.
            //PTSchoolDbSeeder.SeedClubs(db);

            //// ADD SUBJECTS-TO-TEACHERS
            //PTSchoolDbSeeder.SeedTeachersToSubjectsRelation(db);

            //// ADD CLUBS-TO-TEACHERS
            //PTSchoolDbSeeder.SeedTeachersToClubsRelation(db);

            //// ADD STUDENTS-TO-CLUBS
            //PTSchoolDbSeeder.SeedStudentsToClubsRelation(db);

            //// ADD SUBJECTS-TO-CLASSES
            //PTSchoolDbSeeder.SeedSubjectsToClasses(db);

            //// ADD NOTES!
            //PTSchoolDbSeeder.SeedNotes(db);

            // ADD MARKS!
            PTSchoolDbSeeder.SeedMarks(db);
        }
    }
}
