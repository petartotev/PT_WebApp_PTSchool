using PTSchool.Services.Models.Class;
using PTSchool.Services.Models.Teacher;
using System;
using System.Collections.Generic;

namespace PTSchool.Services.Models.Subject
{
    public class SubjectFullServiceModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public IEnumerable<ClassLightServiceModel> Classes { get; set; }

        public IEnumerable<TeacherLightServiceModel> Teachers { get; set; }
    }
}
