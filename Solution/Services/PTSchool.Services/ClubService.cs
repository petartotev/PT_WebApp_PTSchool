using PTSchool.Data;
using PTSchool.Services.Models.Club;
using System.Collections.Generic;
using System.Linq;

namespace PTSchool.Services.Implementations
{
    public class ClubService : IClubService
    {
        private readonly MvcSchoolDbContext db;

        public ClubService(MvcSchoolDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<ClubFullServiceModel> GetAllClubs()
        {
            return this.db.Clubs.Select(x => new ClubFullServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                ImageXS = x.ImageXS,
                Description = x.Description,
                DateOfEstablishment = x.DateOfEstablishment,
                CountStudents = x.Students.Count,
                CountGirls = x.Students.Select(y => y.Student).Where(z => (int)z.Gender == 0).Count(),
                CountBoys = x.Students.Select(y => y.Student).Where(z => (int)z.Gender == 1).Count(),
                StudentsIds = x.Students.Select(zz => zz.StudentId).ToList(),
                StudentsImagesXXS = x.Students.Select(zz => zz.Student).Select(zzz => zzz.ImageXXS),
                TeachersIds = x.Teachers.Select(zz => zz.TeacherId).ToList(),
                TeachersImagesXXS = x.Teachers.Select(zz => zz.Teacher).Select(zzz => zzz.ImageXXS),
            });
        }

        public ClubFullServiceModel GetClubById(int id)
        {
            var clubProfileFullById = this.db.Clubs.Where(z => z.Id == id).Select(x => new ClubFullServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                ImageM = x.ImageM,
                Description = x.Description,
                DateOfEstablishment = x.DateOfEstablishment,
                CountStudents = x.Students.Count,
                CountGirls = x.Students.Select(y => y.Student).Where(z => (int)z.Gender == 0).Count(),
                CountBoys = x.Students.Select(y => y.Student).Where(z => (int)z.Gender == 1).Count(),
                StudentsIds = x.Students.Select(zz => zz.StudentId).ToList(),
                StudentsImagesXXS = x.Students.Select(zz => zz.Student).Select(zzz => zzz.ImageXXS),
                TeachersIds = x.Teachers.Select(zz => zz.TeacherId).ToList(),
                TeachersImagesXXS = x.Teachers.Select(zz => zz.Teacher).Select(zzz => zzz.ImageXXS),
            });

            return clubProfileFullById.FirstOrDefault();
        }

        public int GetCountAllClubs()
        {
            return this.db.Clubs.Count();
        }

        public int GetCountAllStudentsInClubs()
        {
            int test = this.db.Clubs.Select(x => x.Students.Count()).ToList().Sum();

            return test;
        }

        public int GetCountAllTeachersInClubs()
        {
            int test = this.db.Clubs.Select(x => x.Teachers.Count()).ToList().Sum();

            return test;
        }
    }
}
