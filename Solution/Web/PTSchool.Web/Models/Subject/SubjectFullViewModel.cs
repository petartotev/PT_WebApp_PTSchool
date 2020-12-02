using PTSchool.Services.Models.Subject;
using PTSchool.Web.Models.Class;
using PTSchool.Web.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Web.Models.Subject
{
    public class SubjectFullViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public string Description { get; set; }

        //public IEnumerable<ClassLightViewModel> Classes { get; set; }

        //public IEnumerable<TeacherLightViewModel> Teachers { get; set; }
    }
}
