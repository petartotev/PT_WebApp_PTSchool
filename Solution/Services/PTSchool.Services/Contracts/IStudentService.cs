using PTSchool.Services.Contracts;
using PTSchool.Services.Models.Student;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSchool.Services
{
    public interface IStudentService : IPageable
    {
        Task<IEnumerable<StudentLightServiceModel>> GetAllStudentsAsync(int page = 1);

        Task<StudentFullServiceModel> GetStudentByIdAsync(Guid id);
    }
}
