using PTSchool.Services.Models.Class;
using PTSchool.Services.Models.Club;
using PTSchool.Services.Models.Subject;
using System;
using System.Collections.Generic;

namespace PTSchool.Services.Models.Teacher
{
    public class TeacherFullServiceModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string Gender { get; set; }

        public double AverageMark { get; set; }

        public double AverageNote { get; set; }

        public bool IsHeadTeacher { get; set; }

        public int Age { get; set; }
        public DateTime DateBirth { get; set; }
        public DateTime DateEmployed { get; set; }
        public DateTime DateCareerStart { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhoneEmergency { get; set; }

        public ClassLightServiceModel ClassMastered { get; set; }

        public IEnumerable<ClubLightServiceModel> Clubs { get; set; }

        //public IEnumerable<ClubLightServiceModel> Classes { get; set; }

        public IEnumerable<SubjectLightServiceModel> Subjects { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsBanned { get; set; }
    }
}
