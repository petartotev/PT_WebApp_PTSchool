using MvcSchool.Services.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvcSchool.Services.Implementations
{
    public interface ITeacherService
    {    
        IEnumerable<TeacherProfileFullServiceModel> GetAllTeacherProfilesFull(int page = 1);        

        TeacherProfileFullServiceModel GetTeacherProfileFullById(int id);

        int GetTotalTeachersCount();

        int GetPageCountSizing();
    }
}
