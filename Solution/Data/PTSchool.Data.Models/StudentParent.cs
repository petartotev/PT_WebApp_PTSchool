using System;

namespace PTSchool.Data.Models
{
    public class StudentParent
    {
        public Guid ParentId { get; set; }
        public Parent Parent { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
