using PTSchool.Services.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Services.Implementations
{
    public interface ITeacherService
    {    
        IEnumerable<TeacherServiceModel> GetAllTeacherProfilesFull(int page = 1);        

        TeacherServiceModel GetTeacherProfileFullById(int id);

        int GetTotalTeachersCount();

        int GetPageCountSizing();
    }
}
