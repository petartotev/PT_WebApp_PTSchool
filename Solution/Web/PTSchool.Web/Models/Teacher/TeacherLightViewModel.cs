using PTSchool.Web.Models.Abstracts;
using System;

namespace PTSchool.Web.Models.Teacher
{
    public class TeacherLightViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }

        public bool IsHeadTeacher { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsBanned { get; set; }
    }
}
