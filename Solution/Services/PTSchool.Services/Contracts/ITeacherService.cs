using PTSchool.Services.Models.Teacher;
using System.Collections.Generic;

namespace PTSchool.Services.Implementations
{
    public interface ITeacherService
    {
        IEnumerable<TeacherServiceModel> GetAllTeachers(int page = 1);

        TeacherServiceModel GetTeacherById(int id);

        int GetCountTotalTeachers();

        int GetPageCountSizing();
    }
}
