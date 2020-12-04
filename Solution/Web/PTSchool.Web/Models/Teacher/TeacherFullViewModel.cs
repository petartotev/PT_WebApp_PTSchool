using PTSchool.Web.Models.Abstracts;
using PTSchool.Web.Models.Class;
using PTSchool.Web.Models.Club;
using PTSchool.Web.Models.Subject;
using System;
using System.Collections.Generic;

namespace PTSchool.Web.Models.Teacher
{
    public class TeacherFullViewModel : PersonEntity
    {      
        public double AverageMark { get; set; }
        public double AverageNote { get; set; }

        public bool IsHeadTeacher { get; set; }

        public DateTime DateEmployed { get; set; }
        public DateTime DateCareerStart { get; set; }        

        public ClassLightViewModel ClassMastered { get; set; }

        //public IEnumerable<ClassLightViewModel> Classes { get; set; }

        public IEnumerable<ClubLightViewModel> Clubs { get; set; }

        public IEnumerable<SubjectLightViewModel> Subjects { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsBanned { get; set; }
    }
}
