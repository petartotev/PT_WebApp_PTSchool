using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PTSchool.Data;
using PTSchool.Services.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSchool.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        public const int PageSize = 18;

        private readonly PTSchoolDbContext db;
        private readonly IMapper mapper;
        public TeacherService(PTSchoolDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TeacherLightServiceModel>> GetAllTeachersLightByPageAsync(int page = 1)
        {
            var teachers = await this.db.Teachers
                .Where(x => x.IsDeleted == false)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                //.Include(x => x.Classes)
                //.Include(x => x.ClassMastered)
                //.Include(x => x.Clubs)
                //.Include(x => x.Subjects)
                //.Include(x => x.Marks)
                //.Include(x => x.Notes)
                .ToListAsync();

            return this.mapper.Map<IEnumerable<TeacherLightServiceModel>>(teachers);
        }

        public async Task<TeacherFullServiceModel> GetTeacherFullByIdAsync(Guid id)
        {
            ValidateTeacherId(id);
            ValidateIfTeacherIsDeleted(id);

            var teacher = await this.db.Teachers
                .Include(x => x.ClassMastered)
                .Include(x => x.Marks)
                .Include(x => x.Notes)
                .Include(x => x.Clubs)
                .ThenInclude(clubTeacher => clubTeacher.Club)
                .Include(x => x.Subjects)
                .ThenInclude(subjectTeacher => subjectTeacher.Subject)
                .FirstOrDefaultAsync(x => x.Id == id);

            return this.mapper.Map<TeacherFullServiceModel>(teacher);
        }

        public async Task<bool> DeleteTeacherByIdAsync(Guid id)
        {
            ValidateTeacherId(id);
            ValidateIfTeacherIsDeleted(id);

            var teacherToDelete = await this.db.Teachers.FindAsync(id);
            teacherToDelete.IsDeleted = true;
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<TeacherFullServiceModel> UpdateTeacherAsync(TeacherFullServiceModel teacher)
        {
            ValidateTeacherId(teacher.Id);
            ValidateIfTeacherIsDeleted(teacher.Id);
            ValidateIfInputStringIsNotNullOrEmpty(teacher.FirstName);
            ValidateIfInputStringIsNotNullOrEmpty(teacher.MiddleName);
            ValidateIfInputStringIsNotNullOrEmpty(teacher.LastName);

            var teacherInDb = await db.Teachers.FindAsync(teacher.Id);

            teacherInDb.FirstName = teacher.FirstName;
            teacherInDb.MiddleName = teacher.MiddleName;
            teacherInDb.LastName = teacher.LastName;
            teacherInDb.Description = teacher.Description;
            teacherInDb.Image = teacher.Image;
            teacherInDb.Address = teacher.Address;
            teacherInDb.Email = teacher.Email;
            teacherInDb.Phone = teacher.Phone;
            teacherInDb.PhoneEmergency = teacher.PhoneEmergency;
            await db.SaveChangesAsync();

            var teacherInDbUpdated = await this.db.Teachers
                .Include(x => x.ClassMastered)
                .Include(x => x.Marks)
                .Include(x => x.Notes)
                .Include(x => x.Clubs)
                .ThenInclude(clubTeacher => clubTeacher.Club)
                .Include(x => x.Subjects)
                .ThenInclude(subjectTeacher => subjectTeacher.Subject)
                .FirstOrDefaultAsync(x => x.Id == teacher.Id);

            return this.mapper.Map<TeacherFullServiceModel>(teacherInDbUpdated);
        }

        public int GetPageSize()
        {
            int pageSizeToGet = PageSize;
            return pageSizeToGet;
        }

        public int GetTotalCount()
        {
            return this.db.Teachers.Count();
        }

        private void ValidateTeacherId(Guid id)
        {
            if (!db.Teachers.Any(x => x.Id == id))
            {
                throw new ArgumentException("No Teacher with such id.");
            }
        }

        private void ValidateIfTeacherIsBanned(Guid id)
        {
            if (db.Teachers.First(x => x.Id == id).IsDeleted)
            {
                throw new ArgumentException("Teacher is banned.");
            }
        }

        private void ValidateIfTeacherIsDeleted(Guid id)
        {
            if (db.Teachers.First(x => x.Id == id).IsDeleted)
            {
                throw new ArgumentException("Teacher is deleted.");
            }
        }

        private void ValidateIfInputStringIsNotNullOrEmpty(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Name of a Teacher cannot be null or empty.");
            }
        }
    }
}
