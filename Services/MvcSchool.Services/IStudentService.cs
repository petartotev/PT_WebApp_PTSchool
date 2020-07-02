using MvcSchool.Services.Models.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvcSchool.Services
{
    public interface IStudentService
    {     
        IEnumerable<StudentProfileFullServiceModel> GetAllStudentProfilesFull(int page = 1);
        IEnumerable<StudentProfileFullServiceModel> GetAllStudentProfilesFullOrdered(int orderMethod, int ascending1OrDescending2);

        IEnumerable<StudentProfileFullServiceModel> GetAllStudentProfilesFullByGender(int gender);
        IEnumerable<StudentProfileFullServiceModel> GetAllStudentProfilesFullByGenderOrdered(int gender, int orderMethod, int ascending1OrDescending2);

        IEnumerable<StudentProfileFullServiceModel> GetAllStudentProfilesFullByYear(int year);
        IEnumerable<StudentProfileFullServiceModel> GetAllStudentProfilesFullByYearOrdered(int year, int orderMethod, int ascending1OrDescending2);

        IEnumerable<StudentProfileFullServiceModel> GetAllStudentProfilesFullByClass(int classId);
        IEnumerable<StudentProfileFullServiceModel> GetAllStudentProfilesFullByClassOrdered(int classId, int orderMethod, int ascending1OrDescending2);

        IEnumerable<StudentProfileFullServiceModel> GetAllStudentProfilesFullByClub(int clubId);
        IEnumerable<StudentProfileFullServiceModel> GetAllStudentProfilesFullByClubOrdered(int clubId, int orderMethod, int ascending1OrDescending2);

        IEnumerable<StudentProfileFullServiceModel> GetAllStudentProfilesFullByDateOfBirthToday();
        IEnumerable<StudentProfileFullServiceModel> GetAllStudentProfilesFullByDateOfBirthTodayOrdered(int orderMethod, int ascending1OrDescending2);

        StudentProfileFullServiceModel GetStudentProfileFullById(int studentId);
    }
}
