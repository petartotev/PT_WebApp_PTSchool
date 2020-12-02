using System;

namespace PTSchool.Web.Models.Class
{
    public class ClassFullViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public string Description { get; set; }


        //public TeacherLightViewModel MasterTeacher { get; set; }

        //public IEnumerable<StudentLightViewModel> Students { get; set; }

        public int CountStudents { get; set; }
        public int CountGirls { get; set; }
        public int CountBoys { get; set; }
    }
}
