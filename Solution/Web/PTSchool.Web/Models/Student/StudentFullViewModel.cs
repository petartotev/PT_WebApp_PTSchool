using PTSchool.Web.Models.Abstracts;
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
    public class StudentFullViewModel : PersonEntity
    {
        public double AverageScore { get; set; }
        public double AverageBehavior { get; set; }

        public int NumberInClass { get; set; }

        public string Status { get; set; }

        public bool IsSchoolCouncilMember { get; set; }

        public ClassLightViewModel Class { get; set; }

        public TeacherLightViewModel ClassMaster { get; set; }

        public IEnumerable<MarkLightViewModel> Marks { get; set; }

        public IEnumerable<NoteLightViewModel> Notes { get; set; }

        public IEnumerable<ClubLightViewModel> Clubs { get; set; }

        public IEnumerable<ParentLightViewModel> Parents { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsBanned { get; set; }
    }
}
