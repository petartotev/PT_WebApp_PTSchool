using PTSchool.Services.Models.Subject;
using System.Collections.Generic;

namespace PTSchool.Services
{
    public interface ISubjectService
    {
        IEnumerable<SubjectServiceModel> GetAllSubjects();

        SubjectServiceModel GetSubjectById(int id);
    }
}
