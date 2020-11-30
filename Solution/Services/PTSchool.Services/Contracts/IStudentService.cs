using PTSchool.Services.Models.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Services
{
    public interface IStudentService
    {     
        IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFull(int page = 1);
        IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullOrdered(int orderMethod, int ascending1OrDescending2);

        IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullByGender(int gender);
        IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullByGenderOrdered(int gender, int orderMethod, int ascending1OrDescending2);

        IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullByYear(int year);
        IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullByYearOrdered(int year, int orderMethod, int ascending1OrDescending2);

        IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullByClass(int classId);
        IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullByClassOrdered(int classId, int orderMethod, int ascending1OrDescending2);

        IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullByClub(int clubId);
        IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullByClubOrdered(int clubId, int orderMethod, int ascending1OrDescending2);

        IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullByDateOfBirthToday();
        IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullByDateOfBirthTodayOrdered(int orderMethod, int ascending1OrDescending2);

        StudentFullServiceModel GetStudentProfileFullById(int studentId);
    }
}
