using System;

namespace PTSchool.Data.Models
{
    public class TeacherClass
    {
        public Guid ClassId { get; set; }
        public Class Class { get; set; }

        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
