using System;

namespace PTSchool.Data.Models
{
    public class SubjectClass
    {
        public Guid ClassId { get; set; }
        public Class Class { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}