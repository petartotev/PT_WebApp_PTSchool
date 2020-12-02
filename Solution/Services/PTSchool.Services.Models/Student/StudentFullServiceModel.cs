using PTSchool.Services.Models.Class;
using PTSchool.Services.Models.Club;
using PTSchool.Services.Models.Mark;
using PTSchool.Services.Models.Note;
using PTSchool.Services.Models.Parent;
using PTSchool.Services.Models.Teacher;
using System;
using System.Collections.Generic;

namespace PTSchool.Services.Models.Student
{
    public class StudentFullServiceModel
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

        public ClassLightServiceModel Class { get; set; }

        public TeacherLightServiceModel ClassMaster { get; set; }

        public IEnumerable<MarkLightServiceModel> Marks { get; set; }

        public IEnumerable<NoteLightServiceModel> Notes { get; set; }

        public IEnumerable<ClubLightServiceModel> Clubs { get; set; }

        public IEnumerable<ParentLightServiceModel> Parents { get; set; }
    }
}
