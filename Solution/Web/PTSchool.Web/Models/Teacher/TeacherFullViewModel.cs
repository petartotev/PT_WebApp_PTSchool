using System;

namespace PTSchool.Web.Models.Teacher
{
    public class TeacherFullViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string Gender { get; set; }

        public double AverageMark { get; set; }

        public bool IsHeadTeacher { get; set; }

        public int Age { get; set; }
        public DateTime DateBirth { get; set; }
        public DateTime DateEmployed { get; set; }
        public DateTime DateCareerStart { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhoneEmergency { get; set; }

        //public ClassLightViewModel ClassMastered { get; set; }

        //public IEnumerable<ClubLightViewModel> Clubs { get; set; }

        //public IEnumerable<SubjectLightViewModel> Subjects { get; set; }
    }
}
