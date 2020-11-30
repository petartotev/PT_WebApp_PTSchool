using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Data.Models
{
    public class SubjectClass
    {
        public int SubjectId { get; set; }
        public Subject Subject {get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}