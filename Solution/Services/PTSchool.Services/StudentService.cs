﻿using Microsoft.EntityFrameworkCore;
using PTSchool.Data;
using PTSchool.Services.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PTSchool.Services.Implementations
{
    public class StudentService : IStudentService
    {        
        private readonly MvcSchoolDbContext db;

        public StudentService(MvcSchoolDbContext db)
        {
            this.db = db;
        }
                
        public IEnumerable<StudentFullServiceModel> GetAllStudents(int page = 1)
        {
            var allStudentProfilesFull = this.db
                .Students                
                .Select(stdnt => new StudentFullServiceModel
            {
                Id = stdnt.Id,
                FirstName = stdnt.FirstName,
                MiddleName = stdnt.MiddleName,
                LastName = stdnt.LastName,
                Gender = stdnt.Gender.ToString(),
                DateOfBirth = stdnt.DateOfBirth,
                Age = (DateTime.Today - stdnt.DateOfBirth).Days / 365,
                Address = stdnt.Address,
                Email = stdnt.Email,
                Phone = stdnt.Phone,
                ClassId = stdnt.ClassId,
                ClassImageXXS = stdnt.Class.ImageXXS,
                ClassMasterId = stdnt.Class.ClassMasterTeacherId,
                ClassMasterImageXXS = stdnt.Class.ClassMasterTeacher.ImageXXS,
                ClubsIds = stdnt.Clubs.Select(x => x.ClubId).ToList(),
                ClubsImagesXXS = stdnt.Clubs.Select(x => x.Club.ImageXXS).ToList(),
                ParentsIds = stdnt.Parents.Select(x => x.Parent.Id).ToList(),
                ParentsImagesXXS = stdnt.Parents.Select(x => x.Parent.ImageXXS).ToList(),
                AverageScore = stdnt.Marks.Select(x => (double)x.ValueMark).Average(),
                AverageBehavior = stdnt.Notes.Where(x => (double)x.StatusNote != 1).Select(x => (double)x.StatusNote).Average(),
                IsSchoolCouncilMember = stdnt.IsSchoolCouncilMember,
                AboutMe = stdnt.AboutMe,
                ImageXS = stdnt.ImageXS,
            });

            return allStudentProfilesFull;
        }

        public IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullOrdered(int orderMethod, int ascending1OrDescending2)
        {
            var allStudentProfilesFull = GetAllStudents();

            var allStudentProfilesFullOrdered = OrderBy(orderMethod, ascending1OrDescending2, allStudentProfilesFull);

            return allStudentProfilesFullOrdered;
        }


        public IEnumerable<StudentFullServiceModel> GetAllStudentsByClassId(int id)
        {
            var allStudentProfilesFullByClass = db.Students.Where(x => x.Class.Id == id).Select(stdnt => new StudentFullServiceModel
            {
                Id = stdnt.Id,
                FirstName = stdnt.FirstName,
                MiddleName = stdnt.MiddleName,
                LastName = stdnt.LastName,
                Gender = stdnt.Gender.ToString(),
                DateOfBirth = stdnt.DateOfBirth,
                Age = (DateTime.Today - stdnt.DateOfBirth).Days / 365,
                Address = stdnt.Address,
                Email = stdnt.Email,
                Phone = stdnt.Phone,
                ClassId = stdnt.ClassId,
                ClassImageXXS = stdnt.Class.ImageXXS,
                ClassMasterId = stdnt.Class.ClassMasterTeacherId,
                ClassMasterImageXXS = stdnt.Class.ClassMasterTeacher.ImageXXS,
                ClubsIds = stdnt.Clubs.Select(x => x.ClubId).ToList(),
                ClubsImagesXXS = stdnt.Clubs.Select(x => x.Club.ImageXXS).ToList(),
                ParentsIds = stdnt.Parents.Select(x => x.Parent.Id).ToList(),
                ParentsImagesXXS = stdnt.Parents.Select(x => x.Parent.ImageXXS).ToList(),
                AverageScore = stdnt.Marks.Select(x => (double)x.ValueMark).Average(),
                AverageBehavior = stdnt.Notes.Where(x => (double)x.StatusNote != 1).Select(x => (double)x.StatusNote).Average(),
                IsSchoolCouncilMember = stdnt.IsSchoolCouncilMember,
                AboutMe = stdnt.AboutMe,
                ImageXS = stdnt.ImageXS,
            });

            return allStudentProfilesFullByClass;
        }

        public IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullByClassOrdered(int id, int orderMethod, int ascending1OrDescending2)
        {
            var allStudentProfilesFullByClass = GetAllStudentsByClassId(id);

            var allStudentProfilesFullByClassOrdered = OrderBy(orderMethod, ascending1OrDescending2, allStudentProfilesFullByClass);

            return allStudentProfilesFullByClassOrdered;
        }


        public IEnumerable<StudentFullServiceModel> GetAllStudentsByClubId(int id)
        {
            var allStudentProfilesFullByClub = db.Clubs.Where(x => x.Id == id).FirstOrDefault().Students.Select(y => y.Student).Select(stdnt => new StudentFullServiceModel
            {
                Id = stdnt.Id,
                FirstName = stdnt.FirstName,
                MiddleName = stdnt.MiddleName,
                LastName = stdnt.LastName,
                Gender = stdnt.Gender.ToString(),
                DateOfBirth = stdnt.DateOfBirth,
                Age = (DateTime.Today - stdnt.DateOfBirth).Days / 365,
                Address = stdnt.Address,
                Email = stdnt.Email,
                Phone = stdnt.Phone,
                ClassId = stdnt.ClassId,
                ClassImageXXS = stdnt.Class.ImageXXS,
                ClassMasterId = stdnt.Class.ClassMasterTeacherId,
                ClassMasterImageXXS = stdnt.Class.ClassMasterTeacher.ImageXXS,
                ClubsIds = stdnt.Clubs.Select(x => x.ClubId).ToList(),
                ClubsImagesXXS = stdnt.Clubs.Select(x => x.Club.ImageXXS).ToList(),
                ParentsIds = stdnt.Parents.Select(x => x.Parent.Id).ToList(),
                ParentsImagesXXS = stdnt.Parents.Select(x => x.Parent.ImageXXS).ToList(),
                AverageScore = stdnt.Marks.Select(x => (double)x.ValueMark).Average(),
                AverageBehavior = stdnt.Notes.Where(x => (double)x.StatusNote != 1).Select(x => (double)x.StatusNote).Average(),
                IsSchoolCouncilMember = stdnt.IsSchoolCouncilMember,
                AboutMe = stdnt.AboutMe,
                ImageXS = stdnt.ImageXS,
            });

            return allStudentProfilesFullByClub;
        }

        public IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullByClubOrdered(int id, int orderMethod, int ascending1OrDescending2)
        {
            var allStudentProfilesFullByClub = GetAllStudentsByClubId(id);

            var allStudentProfilesFullByClubOrdered = OrderBy(orderMethod, ascending1OrDescending2, allStudentProfilesFullByClub);

            return allStudentProfilesFullByClubOrdered;
        }


        public IEnumerable<StudentFullServiceModel> GetAllStudentsThatHaveBirthdayToday()
        {
            var allStudentProfilesFullByDateOfBirthToday = db.Students.Where(x => x.DateOfBirth.Month == DateTime.UtcNow.Month).Where(y => y.DateOfBirth.Day == DateTime.UtcNow.Day).Select(stdnt => new StudentFullServiceModel
            {
                Id = stdnt.Id,
                FirstName = stdnt.FirstName,
                MiddleName = stdnt.MiddleName,
                LastName = stdnt.LastName,
                Gender = stdnt.Gender.ToString(),
                DateOfBirth = stdnt.DateOfBirth,
                Age = (DateTime.Today - stdnt.DateOfBirth).Days / 365,
                Address = stdnt.Address,
                Email = stdnt.Email,
                Phone = stdnt.Phone,
                ClassId = stdnt.ClassId,
                ClassImageXXS = stdnt.Class.ImageXXS,
                ClassMasterId = stdnt.Class.ClassMasterTeacherId,
                ClassMasterImageXXS = stdnt.Class.ClassMasterTeacher.ImageXXS,
                ClubsIds = stdnt.Clubs.Select(x => x.ClubId).ToList(),
                ClubsImagesXXS = stdnt.Clubs.Select(x => x.Club.ImageXXS).ToList(),
                ParentsIds = stdnt.Parents.Select(x => x.Parent.Id).ToList(),
                ParentsImagesXXS = stdnt.Parents.Select(x => x.Parent.ImageXXS).ToList(),
                AverageScore = stdnt.Marks.Select(x => (double)x.ValueMark).Average(),
                AverageBehavior = stdnt.Notes.Where(x => (double)x.StatusNote != 1).Select(x => (double)x.StatusNote).Average(),
                IsSchoolCouncilMember = stdnt.IsSchoolCouncilMember,
                AboutMe = stdnt.AboutMe,
                ImageXS = stdnt.ImageXS,
            });

            return allStudentProfilesFullByDateOfBirthToday;
        }

        public IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullByDateOfBirthTodayOrdered(int orderMethod, int ascending1OrDescending2)
        {
            var allStudentProfilesFullByDateOfBirthToday = GetAllStudentsThatHaveBirthdayToday();

            var allStudentProfilesFullByDateOfBirthTodayOrdered = OrderBy(orderMethod, ascending1OrDescending2, allStudentProfilesFullByDateOfBirthToday);

            return allStudentProfilesFullByDateOfBirthTodayOrdered;
        }


        public IEnumerable<StudentFullServiceModel> GetAllStudentsByGender(int gender)
        {
            var allStudentProfilesFullByGender = db.Students.Where(x => (int)x.Gender == gender).Select(stdnt => new StudentFullServiceModel
            {
                Id = stdnt.Id,
                FirstName = stdnt.FirstName,
                MiddleName = stdnt.MiddleName,
                LastName = stdnt.LastName,
                Gender = stdnt.Gender.ToString(),
                DateOfBirth = stdnt.DateOfBirth,
                Age = (DateTime.Today - stdnt.DateOfBirth).Days / 365,
                Address = stdnt.Address,
                Email = stdnt.Email,
                Phone = stdnt.Phone,
                ClassId = stdnt.ClassId,
                ClassImageXXS = stdnt.Class.ImageXXS,
                ClassMasterId = stdnt.Class.ClassMasterTeacherId,
                ClassMasterImageXXS = stdnt.Class.ClassMasterTeacher.ImageXXS,
                ClubsIds = stdnt.Clubs.Select(x => x.ClubId).ToList(),
                ClubsImagesXXS = stdnt.Clubs.Select(x => x.Club.ImageXXS).ToList(),
                ParentsIds = stdnt.Parents.Select(x => x.Parent.Id).ToList(),
                ParentsImagesXXS = stdnt.Parents.Select(x => x.Parent.ImageXXS).ToList(),
                AverageScore = stdnt.Marks.Select(x => (double)x.ValueMark).Average(),
                AverageBehavior = stdnt.Notes.Where(x => (double)x.StatusNote != 1).Select(x => (double)x.StatusNote).Average(),
                IsSchoolCouncilMember = stdnt.IsSchoolCouncilMember,
                AboutMe = stdnt.AboutMe,
                ImageXS = stdnt.ImageXS,
            });

            return allStudentProfilesFullByGender;
        }

        public IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullByGenderOrdered(int gender, int orderMethod, int ascending1OrDescending2)
        {
            var allStudentProfilesFullByGender = GetAllStudentsByGender(gender);

            var allStudentProfilesFullByGenderOrdered = OrderBy(orderMethod, ascending1OrDescending2, allStudentProfilesFullByGender);

            return allStudentProfilesFullByGenderOrdered;
        }


        public IEnumerable<StudentFullServiceModel> GetAllStudentsByYear(int year)
        {
            var allStudentProfilesFullByYear = db.Students.Where(x => x.Class.Name.StartsWith(year.ToString())).Select(stdnt => new StudentFullServiceModel
            {
                Id = stdnt.Id,
                FirstName = stdnt.FirstName,
                MiddleName = stdnt.MiddleName,
                LastName = stdnt.LastName,
                Gender = stdnt.Gender.ToString(),
                DateOfBirth = stdnt.DateOfBirth,
                Age = (DateTime.Today - stdnt.DateOfBirth).Days / 365,
                Address = stdnt.Address,
                Email = stdnt.Email,
                Phone = stdnt.Phone,
                ClassId = stdnt.ClassId,
                ClassImageXXS = stdnt.Class.ImageXXS,
                ClassMasterId = stdnt.Class.ClassMasterTeacherId,
                ClassMasterImageXXS = stdnt.Class.ClassMasterTeacher.ImageXXS,
                ClubsIds = stdnt.Clubs.Select(x => x.ClubId).ToList(),
                ClubsImagesXXS = stdnt.Clubs.Select(x => x.Club.ImageXXS).ToList(),
                ParentsIds = stdnt.Parents.Select(x => x.Parent.Id).ToList(),
                ParentsImagesXXS = stdnt.Parents.Select(x => x.Parent.ImageXXS).ToList(),
                AverageScore = stdnt.Marks.Select(x => (double)x.ValueMark).Average(),
                AverageBehavior = stdnt.Notes.Where(x => (double)x.StatusNote != 1).Select(x => (double)x.StatusNote).Average(),
                IsSchoolCouncilMember = stdnt.IsSchoolCouncilMember,
                AboutMe = stdnt.AboutMe,
                ImageXS = stdnt.ImageXS,
            });

            return allStudentProfilesFullByYear;
        }

        public IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullByYearOrdered(int year, int orderMethod, int ascending1OrDescending2)
        {
            var allStudentProfilesFullByYear = GetAllStudentsByYear(year);

            var allStudentProfilesFullByYearOrdered = OrderBy(orderMethod, ascending1OrDescending2, allStudentProfilesFullByYear);

            return allStudentProfilesFullByYearOrdered;
        }


        public static IEnumerable<StudentFullServiceModel> OrderBy(int orderMethod, int ascending1OrDescending2, IEnumerable<StudentFullServiceModel> allStudentProfilesFull)
        {
            switch (orderMethod)
            {
                case 1: //BY FIRST NAME
                    if (ascending1OrDescending2 == 1) // ASC
                    {
                        allStudentProfilesFull = allStudentProfilesFull.OrderBy(x => x.FirstName);
                    }
                    else if (ascending1OrDescending2 == 2) // DESC
                    {
                        allStudentProfilesFull = allStudentProfilesFull.OrderByDescending(x => x.FirstName);
                    }
                    break;
                case 2: //BY LAST NAME
                    if (ascending1OrDescending2 == 1) // ASC
                    {
                        allStudentProfilesFull = allStudentProfilesFull.OrderBy(x => x.LastName);
                    }
                    else if (ascending1OrDescending2 == 2) // DESC
                    {
                        allStudentProfilesFull = allStudentProfilesFull.OrderByDescending(x => x.LastName);
                    }
                    break;
                case 3: //BY AGE
                    if (ascending1OrDescending2 == 1) // ASC
                    {
                        allStudentProfilesFull = allStudentProfilesFull.OrderBy(x => x.DateOfBirth);
                    }
                    else if (ascending1OrDescending2 == 2) // DESC
                    {
                        allStudentProfilesFull = allStudentProfilesFull.OrderByDescending(x => x.DateOfBirth);
                    }
                    break;
                case 4: //BY AVERAGE SCORE
                    if (ascending1OrDescending2 == 1) // ASC
                    {
                        allStudentProfilesFull = allStudentProfilesFull.OrderBy(x => x.AverageScore);
                    }
                    else if (ascending1OrDescending2 == 2) // DESC
                    {
                        allStudentProfilesFull = allStudentProfilesFull.OrderByDescending(x => x.AverageScore);
                    }
                    break;
                case 5: //BY AVERAGE BEHAVIOR
                    if (ascending1OrDescending2 == 1) // ASC
                    {
                        allStudentProfilesFull = allStudentProfilesFull.OrderBy(x => x.AverageBehavior);
                    }
                    else if (ascending1OrDescending2 == 2) // DESC
                    {
                        allStudentProfilesFull = allStudentProfilesFull.OrderByDescending(x => x.AverageBehavior);
                    }
                    break;
                case 6: //BY CLASS
                    if (ascending1OrDescending2 == 1) // ASC
                    {
                        allStudentProfilesFull = allStudentProfilesFull.OrderBy(x => x.ClassId);
                    }
                    else if (ascending1OrDescending2 == 2) // DESC
                    {
                        allStudentProfilesFull = allStudentProfilesFull.OrderByDescending(x => x.ClassId);
                    }
                    break;
                case 7: //BY DATEMONTHDAY
                    if (ascending1OrDescending2 == 1) // ASC
                    {
                        allStudentProfilesFull = allStudentProfilesFull.OrderBy(x => x.DateOfBirth.Month).ThenBy(x => x.DateOfBirth.Day);
                    }
                    else if (ascending1OrDescending2 == 2) // DESC
                    {
                        allStudentProfilesFull = allStudentProfilesFull.OrderByDescending(x => x.ClassId);
                    }
                    break;
                
                default:
                    break;
            }

            var allStudentProfilesFullOrdered = allStudentProfilesFull;

            return allStudentProfilesFullOrdered;
        }


        public StudentFullServiceModel GetStudentById(int studentId)
        {
            var studentProfileFullById = db.Students.Where(x => x.Id == studentId).Select(stdnt => new StudentFullServiceModel
            {
                Id = stdnt.Id,
                FirstName = stdnt.FirstName,
                MiddleName = stdnt.MiddleName,
                LastName = stdnt.LastName,
                Gender = stdnt.Gender.ToString(),
                DateOfBirth = stdnt.DateOfBirth,
                Age = (DateTime.Today - stdnt.DateOfBirth).Days / 365,
                Address = stdnt.Address,
                Email = stdnt.Email,
                Phone = stdnt.Phone,
                ClassId = stdnt.ClassId,
                ClassImageXXS = stdnt.Class.ImageXXS,
                ClassMasterId = stdnt.Class.ClassMasterTeacherId,
                ClassMasterImageXXS = stdnt.Class.ClassMasterTeacher.ImageXXS,
                ClubsIds = stdnt.Clubs.Select(x => x.ClubId).ToList(),
                ClubsImagesXXS = stdnt.Clubs.Select(x => x.Club.ImageXXS).ToList(),
                ParentsIds = stdnt.Parents.Select(x => x.Parent.Id).ToList(),
                ParentsImagesXXS = stdnt.Parents.Select(x => x.Parent.ImageXXS).ToList(),
                AverageScore = stdnt.Marks.Select(x => (double)x.ValueMark).Average(),
                AverageBehavior = stdnt.Notes.Where(x => (double)x.StatusNote != 1).Select(x => (double)x.StatusNote).Average(),
                IsSchoolCouncilMember = stdnt.IsSchoolCouncilMember,
                AboutMe = stdnt.AboutMe,
                ImageM = stdnt.ImageM,
            });

            return studentProfileFullById.FirstOrDefault();
        }        
    }
}
