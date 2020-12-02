using PTSchool.Services.Contracts;
using PTSchool.Services.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSchool.Services.Implementations
{
    public interface ITeacherService : IPageable
    {
        Task<IEnumerable<TeacherLightServiceModel>> GetAllTeachersAsync(int page = 1);

        Task<TeacherFullServiceModel> GetTeacherByIdAsync(Guid id);
    }
}
