using PTSchool.Services.Contracts;
using PTSchool.Services.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSchool.Services.Implementations
{
    public interface ITeacherService : IPageable
    {
        Task<IEnumerable<TeacherLightServiceModel>> GetAllTeachersLightByPageAsync(int page = 1);

        Task<TeacherFullServiceModel> GetTeacherFullByIdAsync(Guid id);
    }
}
