using PTSchool.Services.Models.Student;
using System;
using System.Collections.Generic;

namespace PTSchool.Services.Models.Parent
{
    public class ParentFullServiceModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string Gender { get; set; }

        public string Occupation { get; set; }

        public int Age { get; set; }
        public DateTime DateBirth { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public IEnumerable<StudentLightServiceModel> Students { get; set; }
    }
}
