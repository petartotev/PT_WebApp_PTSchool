using System;

namespace PTSchool.Web.Models.Club
{
    public class ClubFullViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public DateTime DateEstablished { get; set; }

        public string Email { get; set; }

        //public IEnumerable<StudentLightViewModel> Students { get; set; }

        //public IEnumerable<TeacherLightViewModel> Teachers { get; set; }

        public int CountStudents { get; set; }
        public int CountGirls { get; set; }
        public int CountBoys { get; set; }
    }
}
