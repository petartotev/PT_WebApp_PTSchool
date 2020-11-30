using PTSchool.Data;
using PTSchool.Services.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTSchool.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        public const int PageCountSize = 20;

        private readonly MvcSchoolDbContext db;

        public TeacherService(MvcSchoolDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<TeacherServiceModel> GetAllTeacherProfilesFull(int page = 1)
        {

            var allTeacherProfilesFull =  this.db
                .Teachers
                .Skip((page - 1) * PageCountSize)
                .Take(PageCountSize)
                .Select(x => new TeacherServiceModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                ClassMasteredId = x.ClassMastered.Id,
                //ClassMasteredName = x.ClassMastered.Name,
                ClassMasteredImageXXS = x.ClassMastered.ImageXXS,
                ClubsMasteredIds = x.Clubs.Select(y => y.ClubId),
                //ClubsMasteredNames = x.Clubs.Select(y => y.Club.Name),
                ClubsMasteredImagesXXS = x.Clubs.Select(y => y.Club.ImageXXS),
                SubjectsIds = x.Subjects.Select(y => y.SubjectId),
                //SubjectsNames = x.Subjects.Select(y => y.Subject.Name),
                SubjectsImagesXXS = x.Subjects.Select(y => y.Subject.ImageXXS),
                Gender = x.Gender.ToString(),
                DateOfBirth = x.DateOfBirth,
                Age = (DateTime.Today - x.DateOfBirth).Days / 365,
                AverageMark = x.Marks.Where(y => y.TeacherId == x.Id).Select(z => (int)z.ValueMark).Average(),
                Address = x.Address,
                Email = x.Email,
                Phone = x.Phone,
                PhoneEmergency = x.PhoneEmergency,
                DateOfCareerStart = x.DateOfCareerStart,
                DateOfEmployment = x.DateOfEmployment,
                AboutMe = x.AboutMe,
                ImageXS = x.ImageXS,
            });

            return allTeacherProfilesFull;
        }

        public TeacherServiceModel GetTeacherProfileFullById(int id)
        {
            var teacherProfileFullById = this.db.Teachers.Where(x => x.Id == id).Select(x => new TeacherServiceModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                ClassMasteredId = x.ClassMastered.Id,
                //ClassMasteredName = x.ClassMastered.Name,
                ClassMasteredImageXXS = x.ClassMastered.ImageXXS,
                ClubsMasteredIds = x.Clubs.Select(y => y.ClubId),
                //ClubsMasteredNames = x.Clubs.Select(y => y.Club.Name),
                ClubsMasteredImagesXXS = x.Clubs.Select(y => y.Club.ImageXXS),
                SubjectsIds = x.Subjects.Select(y => y.SubjectId),
                //SubjectsNames = x.Subjects.Select(y => y.Subject.Name),
                SubjectsImagesXXS = x.Subjects.Select(y => y.Subject.ImageXXS),
                Gender = x.Gender.ToString(),
                DateOfBirth = x.DateOfBirth,
                Age = (DateTime.Today - x.DateOfBirth).Days / 365,
                AverageMark = x.Marks.Where(y => y.TeacherId == x.Id).Select(z => (int)z.ValueMark).Average(),
                Address = x.Address,
                Email = x.Email,
                Phone = x.Phone,
                PhoneEmergency = x.PhoneEmergency,
                DateOfCareerStart = x.DateOfCareerStart,
                DateOfEmployment = x.DateOfEmployment,
                AboutMe = x.AboutMe,
                ImageM = x.ImageM,
            });

            return teacherProfileFullById.FirstOrDefault();
        }        

        public int GetTotalTeachersCount()
        {
            return this.db.Teachers.Count();
        }

        public int GetPageCountSizing()
        {
            int pageCountSize = PageCountSize;

            return pageCountSize;
        }
    }
}
