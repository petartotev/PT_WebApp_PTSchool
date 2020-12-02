using PTSchool.Web.Models.Abstracts;
using PTSchool.Web.Models.Class;
using PTSchool.Web.Models.Teacher;
using System.Collections.Generic;

namespace PTSchool.Web.Models.Subject
{
    public class SubjectFullViewModel : BaseEntity
    {
        public IEnumerable<ClassLightViewModel> Classes { get; set; }

        public IEnumerable<TeacherLightViewModel> Teachers { get; set; }
    }
}
