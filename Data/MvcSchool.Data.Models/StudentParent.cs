using System;
using System.Collections.Generic;
using System.Text;

namespace MvcSchool.Data.Models
{
    public class StudentParent
    {
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int ParentId { get; set; }

        public Parent Parent { get; set; }
    }
}
