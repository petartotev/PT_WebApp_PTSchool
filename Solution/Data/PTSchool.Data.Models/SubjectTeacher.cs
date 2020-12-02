using System;

namespace PTSchool.Data.Models
{
    public class SubjectTeacher
    {
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
