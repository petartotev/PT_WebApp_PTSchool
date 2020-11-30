using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Data.Models
{
    public class TeacherClass
    {
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public int ClassId { get; set; }

        public Class Class { get; set; }
    }
}
