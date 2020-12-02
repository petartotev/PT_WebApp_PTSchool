using PTSchool.Web.Models.Abstracts;
using System.Collections.Generic;

namespace PTSchool.Web.Models.Teacher
{
    public class CollectionTeachersLightViewModels : PageableCollection
    {
        public IEnumerable<TeacherLightViewModel> Teachers { get; set; }
    }
}
