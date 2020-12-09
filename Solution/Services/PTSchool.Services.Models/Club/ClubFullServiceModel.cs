using PTSchool.Services.Models.Student;
using PTSchool.Services.Models.Teacher;
using System;
using System.Collections.Generic;

namespace PTSchool.Services.Models.Club
{
    public class ClubFullServiceModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public DateTime DateEstablished { get; set; }

        public string Email { get; set; }

        public IEnumerable<StudentLightServiceModel> Students { get; set; }

        public IEnumerable<TeacherLightServiceModel> Teachers { get; set; }

        public int CountStudents { get; set; }
        public int CountGirls { get; set; }
        public int CountBoys { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsUnlisted { get; set; }

        public Dictionary<ClubLightServiceModel, float> ClubsRecommendedByMLNet { get; set; }
    }
}
