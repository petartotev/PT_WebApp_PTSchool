using PTSchool.Data;
using PTSchool.Services.Models.Class;
using System.Collections.Generic;
using System.Linq;

namespace PTSchool.Services.Implementations
{
    public class ClassService : IClassService
    {
        private readonly MvcSchoolDbContext db;

        public ClassService(MvcSchoolDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<ClassFullServiceModel> GetAllClasses()
        {
            return this.db.Classes.Select(x => new ClassFullServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                ImageXS = x.ImageXS,
                Description = x.Description,
                MasterTeacherId = x.ClassMasterTeacherId,
                MasterTeacherName = x.ClassMasterTeacher.FirstName + " " + x.ClassMasterTeacher.LastName,
                MasterTeacherImageXXS = x.ClassMasterTeacher.ImageXXS,
                CountStudents = x.Students.Count,
                CountGirls = x.Students.Where(y => (int)y.Gender == 0).Count(),
                CountBoys = x.Students.Where(y => (int)y.Gender == 1).Count(),
                StudentsAverageScores = x.Students.Select(y => y.Marks.Select(z => (double)z.ValueMark).Average()),
            });
        }



        public ClassFullServiceModel GetClassById(int id)
        {
            var classServiceModelToGet = this.db.Classes.Where(x => x.Id == id).Select(classToGet => new ClassFullServiceModel
            {
                Id = classToGet.Id,
                Name = classToGet.Name,
                ImageM = classToGet.ImageM,
                Description = classToGet.Description,
                MasterTeacherId = classToGet.ClassMasterTeacherId,
                MasterTeacherName = classToGet.ClassMasterTeacher.FirstName + " " + classToGet.ClassMasterTeacher.LastName,
                MasterTeacherImageXXS = classToGet.ClassMasterTeacher.ImageXXS,
                CountStudents = classToGet.Students.Count,
                CountGirls = classToGet.Students.Where(y => (int)y.Gender == 0).Count(),
                CountBoys = classToGet.Students.Where(y => (int)y.Gender == 1).Count(),
                StudentsAverageScores = classToGet.Students.Select(y => y.Marks.Select(z => (double)z.ValueMark).Average()),
                StudentsIds = classToGet.Students.Select(z => z.Id),
                //StudentsNames = classToGet.Students.Select(z => z.FirstName),
                //StudentsEmails = classToGet.Students.Select(z => z.Email),
                //StudentsImagesM = classToGet.Students.Select(z => z.ImageM),
                StudentsImagesXS = classToGet.Students.Select(z => z.ImageXS),
                //StudentsImagesXXS = classToGet.Students.Select(z => z.ImageXXS),
            });

            return classServiceModelToGet.FirstOrDefault();
        }
    }
}
