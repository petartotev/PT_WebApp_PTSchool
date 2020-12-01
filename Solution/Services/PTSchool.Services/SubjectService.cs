using PTSchool.Data;
using PTSchool.Services.Models.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTSchool.Services.Implementations
{
    public class SubjectService : ISubjectService
    {
        private readonly MvcSchoolDbContext db;

        public SubjectService(MvcSchoolDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SubjectServiceModel> GetAllSubjects()
        {
            return this.db.Subjects.Select(x => new SubjectServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                ImageXS = x.ImageXS,
                Description = x.Description,
                TeachersIds = x.Teachers.Select(y => y.TeacherId),
                //TeachersImagesXXS = x.Teachers.Select(y => y.Teacher.ImageXXS),
                ClassesIds = x.Classes.Select(z => z.ClassId),
                //ClassesImagesXXS = x.Classes.Select(z => z.Class.ImageXXS)
            });
        }

        public SubjectServiceModel GetSubjectById(int id)
        {
            return this.db.Subjects.Where(x => x.Id == id).Select(x => new SubjectServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                ImageM = x.ImageM,
                Description = x.Description,
                TeachersIds = x.Teachers.Select(y => y.TeacherId),
                TeachersImagesXXS = x.Teachers.Select(y => y.Teacher.ImageXXS),
                ClassesIds = x.Classes.Select(z => z.ClassId),
                ClassesImagesXXS = x.Classes.Select(z => z.Class.ImageXXS),
            }).FirstOrDefault();
        }
    }
}
