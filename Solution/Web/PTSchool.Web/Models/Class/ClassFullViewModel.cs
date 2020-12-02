using PTSchool.Web.Models.Abstracts;
using PTSchool.Web.Models.Student;
using PTSchool.Web.Models.Teacher;
using System.Collections.Generic;

namespace PTSchool.Web.Models.Class
{
    public class ClassFullViewModel : BaseEntity
    {
        public int CountStudents { get; set; }
        public int CountGirls { get; set; }
        public int CountBoys { get; set; }

        public TeacherLightViewModel MasterTeacher { get; set; }

        public IEnumerable<StudentLightViewModel> Students { get; set; }
    }
}
