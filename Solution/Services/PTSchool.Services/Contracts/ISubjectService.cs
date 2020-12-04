using PTSchool.Services.Contracts;
using PTSchool.Services.Models.Subject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSchool.Services
{
    public interface ISubjectService : IPageable
    {
        Task<IEnumerable<SubjectLightServiceModel>> GetAllSubjectsLightByPageAsync(int page = 1);

        Task<SubjectFullServiceModel> GetSubjectFullByIdAsync(Guid id);

        Task<bool> DeleteSubjectByIdAsync(Guid id);

        Task<SubjectFullServiceModel> UpdateSubjectAsync(SubjectFullServiceModel subject);
    }
}
