using MvcSchool.Services.Models.Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvcSchool.Services
{
    public interface ISubjectService
    {
        IEnumerable<SubjectProfileFullServiceModel> GetAllSubjectProfilesFull();

        SubjectProfileFullServiceModel GetSubjectProfileFullById(int id);
    }
}
