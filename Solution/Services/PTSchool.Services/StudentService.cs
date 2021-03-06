﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PTSchool.Data;
using PTSchool.Data.Models;
using PTSchool.Data.Models.Enums;
using PTSchool.Services.Contracts;
using PTSchool.Services.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Services
{
    public class StudentService : IStudentService
    {
        private const int PageSize = 18;

        private readonly PTSchoolDbContext db;
        private readonly IMapper mapper;

        public StudentService(PTSchoolDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<StudentLightServiceModel>> GetAllStudentsLightByPageAsync(int page = 1)
        {
            var students = await this.db.Students
                .Where(x => x.IsDeleted == false)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                //.Include(x => x.Class)
                //.Include(x => x.Clubs)
                //.Include(x => x.Marks)
                //.Include(x => x.Notes)
                //.Include(x => x.Parents)
                .ToListAsync();

            return this.mapper.Map<IEnumerable<StudentLightServiceModel>>(students);
        }

        public async Task<StudentFullServiceModel> GetStudentFullByIdAsync(Guid id)
        {
            ValidateStudentId(id);
            ValidateIfStudentIsDeleted(id);

            var student = await db.Students
                .Include(x => x.Class)
                .Include(x => x.Marks)
                .Include(x => x.Notes)
                .Include(x => x.Parents)
                .ThenInclude(studentParent => studentParent.Parent)
                .Include(x => x.Clubs)
                .ThenInclude(clubStudent => clubStudent.Club)
                .FirstOrDefaultAsync(x => x.Id == id);

            return this.mapper.Map<StudentFullServiceModel>(student);
        }

        public async Task<IEnumerable<StudentFullServiceModel>> GetAllStudentCouncilMembersAsync()
        {
            var students = await db.Students
                .Include(x => x.Class)
                .Include(x => x.Marks)
                .Include(x => x.Notes)
                .Include(x => x.Parents)
                .ThenInclude(studentParent => studentParent.Parent)
                .Include(x => x.Clubs)
                .ThenInclude(clubStudent => clubStudent.Club)
                .Where(x => x.IsSchoolCouncilMember == true)
                .ToListAsync();

            var result = this.mapper.Map<IEnumerable<StudentFullServiceModel>>(students);
            return result;
        }

        public async Task<bool> DeleteStudentByIdAsync(Guid id)
        {
            ValidateStudentId(id);
            ValidateIfStudentIsDeleted(id);

            var studentToDelete = await this.db.Students.FindAsync(id);
            studentToDelete.IsDeleted = true;
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<StudentFullServiceModel> UpdateStudentAsync(StudentFullServiceModel student)
        {
            ValidateStudentId(student.Id);
            ValidateIfStudentIsDeleted(student.Id);
            ValidateIfInputStringIsNotNullOrEmpty(student.FirstName);
            ValidateIfInputStringIsNotNullOrEmpty(student.MiddleName);
            ValidateIfInputStringIsNotNullOrEmpty(student.LastName);

            var studentInDb = await db.Students.FindAsync(student.Id);

            studentInDb.FirstName = student.FirstName;
            studentInDb.MiddleName = student.MiddleName;
            studentInDb.LastName = student.LastName;
            studentInDb.Description = student.Description;
            studentInDb.Image = student.Image;
            studentInDb.Address = student.Address;
            studentInDb.Email = student.Email;
            studentInDb.Phone = student.Phone;
            await db.SaveChangesAsync();

            var studentInDbUpdated = await db.Students
                .Include(x => x.Class)
                .Include(x => x.Marks)
                .Include(x => x.Notes)
                .Include(x => x.Parents)
                .ThenInclude(studentParent => studentParent.Parent)
                .Include(x => x.Clubs)
                .ThenInclude(clubStudent => clubStudent.Club)
                .FirstOrDefaultAsync(x => x.Id == student.Id);

            return this.mapper.Map<StudentFullServiceModel>(studentInDbUpdated);
        }

        public async Task<StudentFullServiceModel> CreateStudentAsync(StudentFullServiceModel student)
        {
            ValidateIfInputStringIsNotNullOrEmpty(student.FirstName);
            ValidateIfInputStringIsNotNullOrEmpty(student.MiddleName);
            ValidateIfInputStringIsNotNullOrEmpty(student.LastName);
            ValidateIfInputStringIsNotNullOrEmpty(student.Email);
            ValidateIfInputStringIsNotNullOrEmpty(student.Phone);
            ValidateIfInputStringIsNotNullOrEmpty(student.Address);
            ValidateIfDateIsNotNull(student.DateBirth);

            Class classOfThisStudent = await this.db.Classes.FirstOrDefaultAsync(x => x.Id == student.Class.Id);

            Student studentToAddInDb = new Student
            {
                FirstName = student.FirstName,
                MiddleName = student.MiddleName,
                LastName = student.LastName,
                IsBanned = false,
                IsDeleted = false,
                Class = classOfThisStudent,
                ClassId = classOfThisStudent.Id,
                Status = (EnumStatusStudent)Enum.Parse(typeof(EnumStatusStudent), student.Status),
                IsSchoolCouncilMember = student.IsSchoolCouncilMember,
                Address = student.Address,
                Email = student.Email,
                Phone = student.Phone,
                DateBirth = student.DateBirth,
                Description = student.Description,
                Gender = (EnumGender)Enum.Parse(typeof(EnumGender), student.Gender),
                Image = student.Image,
                NumberInClass = student.NumberInClass,
            };

            await SetDefaultImagePathIfImagePathIsNull(studentToAddInDb);
            await SetDefaultDescriptionIfDescriptionIsNull(studentToAddInDb);

            await this.db.Students.AddAsync(studentToAddInDb);
            await db.SaveChangesAsync();

            Student studentAddedInDb = await this.db.Students.FirstOrDefaultAsync(x => x.FirstName == student.FirstName && x.MiddleName == student.MiddleName && x.LastName == student.LastName);
            return this.mapper.Map<StudentFullServiceModel>(studentAddedInDb);
        }

        public int GetPageSize()
        {
            int pageSizeToGet = PageSize;
            return pageSizeToGet;
        }

        public int GetTotalCount()
        {
            return this.db.Students.Count();
        }


        private async Task<string> SetDefaultImagePathIfImagePathIsNull(Student student)
        {
            if (student.Image is null)
            {
                string imagePathDefault = $"/images/students/default.jpg";
                student.Image = imagePathDefault;
                await db.SaveChangesAsync();
            }

            return student.Image;
        }

        private async Task<string> SetDefaultDescriptionIfDescriptionIsNull(Student student)
        {
            if (string.IsNullOrEmpty(student.Description))
            {
                string subjectDefault = $"{student.FirstName} is a student that is part of the PTSchool community. Likes sports, studying and singing songs of joy.";
                student.Description = subjectDefault;
                await db.SaveChangesAsync();
            }

            return student.Description;
        }

        private void ValidateStudentId(Guid id)
        {
            if (!db.Students.Any(x => x.Id == id))
            {
                throw new ArgumentException("No Student with such id.");
            }
        }

        private void ValidateIfStudentIsBanned(Guid id)
        {
            if (db.Students.First(x => x.Id == id).IsDeleted)
            {
                throw new ArgumentException("Student is banned.");
            }
        }

        private void ValidateIfStudentIsDeleted(Guid id)
        {
            if (db.Students.First(x => x.Id == id).IsDeleted)
            {
                throw new ArgumentException("Student is deleted.");
            }
        }

        private void ValidateIfInputStringIsNotNullOrEmpty(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Name of a Student cannot be null or empty.");
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
