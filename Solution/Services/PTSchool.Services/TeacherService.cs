using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PTSchool.Data;
using PTSchool.Data.Models;
using PTSchool.Services.Contracts;
using PTSchool.Services.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Services
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
            teacherInDb.Image = teacher.Image;
            teacherInDb.Description = teacher.Description;
            teacherInDb.Address = teacher.Address;
            teacherInDb.Email = teacher.Email;
            teacherInDb.Phone = teacher.Phone;
            teacherInDb.PhoneEmergency = teacher.PhoneEmergency;

            await SetDefaultImagePathIfImagePathIsNull(teacherInDb);
            await SetDefaultDescriptionIfDescriptionIsNull(teacherInDb);

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

        public async Task<TeacherFullServiceModel> CreateTeacherAsync(TeacherFullServiceModel teacher)
        {
            ValidateIfInputStringIsNotNullOrEmpty(teacher.FirstName);
            ValidateIfInputStringIsNotNullOrEmpty(teacher.MiddleName);
            ValidateIfInputStringIsNotNullOrEmpty(teacher.LastName);
            ValidateIfInputStringIsNotNullOrEmpty(teacher.Email);
            ValidateIfInputStringIsNotNullOrEmpty(teacher.Phone);
            ValidateIfInputStringIsNotNullOrEmpty(teacher.PhoneEmergency);
            ValidateIfInputStringIsNotNullOrEmpty(teacher.Address);
            ValidateIfDateIsNotNull(teacher.DateBirth);

            Teacher teacherToAddInDb = this.mapper.Map<Teacher>(teacher);

            await SetDefaultImagePathIfImagePathIsNull(teacherToAddInDb);
            await SetDefaultDescriptionIfDescriptionIsNull(teacherToAddInDb);

            await this.db.Teachers.AddAsync(teacherToAddInDb);
            await db.SaveChangesAsync();

            Teacher teacherAddedInDb = await this.db.Teachers.FirstOrDefaultAsync(x => x.FirstName == teacher.FirstName && x.MiddleName == teacher.MiddleName && x.LastName == teacher.LastName);
            return this.mapper.Map<TeacherFullServiceModel>(teacherAddedInDb);
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

        private async Task<string> SetDefaultImagePathIfImagePathIsNull(Teacher teacher)
        {
            if (teacher.Image is null)
            {
                string imagePathDefault = $"/images/teachers/default.jpg";
                teacher.Image = imagePathDefault;
                await db.SaveChangesAsync();
            }

            return teacher.Image;
        }

        private async Task<string> SetDefaultDescriptionIfDescriptionIsNull(Teacher teacher)
        {
            if (string.IsNullOrEmpty(teacher.Description))
            {
                string subjectDefault = $"{teacher.LastName} is a teacher that is part of the PTSchool community. {teacher.LastName} is keen on science, literature and spreading knowledge and skills among the students of the school.";
                teacher.Description = subjectDefault;
                await db.SaveChangesAsync();
            }

            return teacher.Description;
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

        private void ValidateIfDateIsNotNull(DateTime date)
        {
            if (date == default(DateTime))
            {
                throw new ArgumentException("Date cannot be default.");
            }
        }
    }
}
