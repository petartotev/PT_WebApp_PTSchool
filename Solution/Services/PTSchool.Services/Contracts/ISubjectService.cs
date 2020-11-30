using PTSchool.Services.Models.Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Services
{
    public interface ISubjectService
    {
        IEnumerable<SubjectServiceModel> GetAllSubjectProfilesFull();

        SubjectServiceModel GetSubjectProfileFullById(int id);
    }
}
