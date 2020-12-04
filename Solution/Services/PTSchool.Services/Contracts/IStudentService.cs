using PTSchool.Services.Contracts;
using PTSchool.Services.Models.Student;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSchool.Services
{
    public interface IStudentService : IPageable
    {
        Task<IEnumerable<StudentLightServiceModel>> GetAllStudentsLightByPageAsync(int page = 1);

        Task<StudentFullServiceModel> GetStudentFullByIdAsync(Guid id);

        Task<IEnumerable<StudentFullServiceModel>> GetAllStudentCouncilMembersAsync();

        Task<bool> DeleteStudentByIdAsync(Guid id);
    }
}
