using PTSchool.Services.Models.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Web.Models.Subject
{
    public class CollectionSubjectsFullViewModels
    {
        public IEnumerable<SubjectServiceModel> AllSubjectsFull { get; set; }
    }
}
