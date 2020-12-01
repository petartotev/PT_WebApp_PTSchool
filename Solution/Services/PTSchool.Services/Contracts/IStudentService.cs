using PTSchool.Services.Models.Student;
using System.Collections.Generic;

namespace PTSchool.Services
{
    public interface IStudentService
    {
        IEnumerable<StudentFullServiceModel> GetAllStudents(int page = 1);
        IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullOrdered(int orderMethod, int ascending1OrDescending2);

        IEnumerable<StudentFullServiceModel> GetAllStudentsByGender(int gender);
        IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullByGenderOrdered(int gender, int orderMethod, int ascending1OrDescending2);

        IEnumerable<StudentFullServiceModel> GetAllStudentsByYear(int year);
        IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullByYearOrdered(int year, int orderMethod, int ascending1OrDescending2);

        IEnumerable<StudentFullServiceModel> GetAllStudentsByClassId(int classId);
        IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullByClassOrdered(int classId, int orderMethod, int ascending1OrDescending2);

        IEnumerable<StudentFullServiceModel> GetAllStudentsByClubId(int clubId);
        IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullByClubOrdered(int clubId, int orderMethod, int ascending1OrDescending2);

        IEnumerable<StudentFullServiceModel> GetAllStudentsThatHaveBirthdayToday();
        IEnumerable<StudentFullServiceModel> GetAllStudentProfilesFullByDateOfBirthTodayOrdered(int orderMethod, int ascending1OrDescending2);

        StudentFullServiceModel GetStudentById(int studentId);
    }
}
