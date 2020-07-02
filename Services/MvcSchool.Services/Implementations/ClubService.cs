using AutoMapper;
using MvcSchool.Data;
using MvcSchool.Data.Models;
using MvcSchool.Services.Models.Club;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MvcSchool.Services.Implementations
{
    public class ClubService : IClubService
    {
        private readonly MvcSchoolDbContext db;

        public ClubService(MvcSchoolDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<ClubProfileFullServiceModel> GetAllClubProfilesFull()
        {
            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<Club, ClubProfileFullServiceModel>();
            //});
            //var mapper = config.CreateMapper();
            //var clubDataModel = this.db.Clubs;
            //var clubServiceModel = mapper.Map<IEnumerable<ClubProfileFullServiceModel>>(clubDataModel);
            //return clubServiceModel;

            return this.db.Clubs.Select(x => new ClubProfileFullServiceModel
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

        public int GetAllClubsCount()
        {
            return this.db.Clubs.Count();
        }

        public int GetAllClubsStudentsCount()
        {
            int test = this.db.Clubs.Select(x => x.Students.Count()).ToList().Sum();

            return test;
        }

        public int GetAllClubsTeachersCount()
        {
            int test = this.db.Clubs.Select(x => x.Teachers.Count()).ToList().Sum();

            return test;
        }

        public ClubProfileFullServiceModel GetClubProfileFullById(int id)
        {
            var clubProfileFullById = this.db.Clubs.Where(z => z.Id == id).Select(x => new ClubProfileFullServiceModel
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
    }
}
