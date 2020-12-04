using PTSchool.Web.Models.Abstracts;
using PTSchool.Web.Models.Student;
using PTSchool.Web.Models.Teacher;
using System;
using System.Collections.Generic;

namespace PTSchool.Web.Models.Club
{
    public class ClubFullViewModel : BaseEntity
    {
        public DateTime DateEstablished { get; set; }

        public string Email { get; set; }

        public int CountStudents { get; set; }
        public int CountGirls { get; set; }
        public int CountBoys { get; set; }

        public IEnumerable<StudentLightViewModel> Students { get; set; }

        public IEnumerable<TeacherLightViewModel> Teachers { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsUnlisted { get; set; }
    }
}
