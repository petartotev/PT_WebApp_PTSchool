using PTSchool.Web.Models.Class;
using PTSchool.Web.Models.Club;
using PTSchool.Web.Models.Mark;
using PTSchool.Web.Models.Note;
using PTSchool.Web.Models.Parent;
using PTSchool.Web.Models.Teacher;
using System;
using System.Collections.Generic;

namespace PTSchool.Web.Models.Student
{
    public class StudentFullViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string Gender { get; set; }

        public double AverageScore { get; set; }

        public double AverageBehavior { get; set; }

        public bool IsSchoolCouncilMember { get; set; }

        public int Age { get; set; }
        public DateTime DateBirth { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public ClassLightViewModel Class { get; set; }

        public TeacherLightViewModel ClassMaster { get; set; }

        public IEnumerable<MarkLightViewModel> Marks { get; set; }

        public IEnumerable<NoteLightViewModel> Notes { get; set; }

        public IEnumerable<ClubLightViewModel> Clubs { get; set; }

        public IEnumerable<ParentLightViewModel> Parents { get; set; }
    }
}
