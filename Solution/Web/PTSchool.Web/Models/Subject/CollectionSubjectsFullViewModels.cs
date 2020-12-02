using PTSchool.Web.Models.Abstracts;
using System.Collections.Generic;

namespace PTSchool.Web.Models.Subject
{
    public class CollectionSubjectsFullViewModels : PageableCollection
    {
        public IEnumerable<SubjectLightViewModel> Subjects { get; set; }
    }
}
